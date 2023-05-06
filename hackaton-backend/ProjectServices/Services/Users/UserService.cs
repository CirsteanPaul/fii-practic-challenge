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
	}
}

