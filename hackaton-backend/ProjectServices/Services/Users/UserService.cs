using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectServices.Exceptions;
using hackatonBackend.ProjectServices.Mappers;
using hackatonBackend.ProjectServices.Services.Common.Auth;

namespace hackatonBackend.ProjectServices.Services.Users
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork unitOfWork;

		public UserService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public UserDto GetDetails(int? userId)
		{
			if (!userId.HasValue)
			{
				throw new AuthorizationException("You're not logged in");
			}

			var user = unitOfWork.Users.GetUserById(userId.Value);

			if (user is null)
			{
				throw new EntityNotFoundException(userId.Value, typeof(User));
			}

			return user.ToDto();
		}

        public void ChangeDetails(int? userId, UserDto userDto)
		{
			if (!userId.HasValue)
			{
				throw new AuthorizationException("You're not logged in");
            }

			if (userDto is null)
			{
				return;
			}

			var user = unitOfWork.Users.GetUserById(userId.Value);

			if (!string.IsNullOrEmpty(userDto.Avatar))
			{
				user.Avatar = userDto.Avatar;
			}

			if (!string.IsNullOrEmpty(userDto.Description))
			{
				user.Description = userDto.Description;
			}

			if(userDto.PositionRole is not null)
			{
				user.PositionRole = (short)userDto.PositionRole;
			}
			// verify if userDto is null if not change data

			unitOfWork.Users.Update(user);
			unitOfWork.SaveChanges();
		}
    }
}

