using System;
using System.ComponentModel.DataAnnotations;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectServices.Constants;
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
			if(!string.IsNullOrEmpty(userDto.Username))
			{
                var existingUser = unitOfWork.Users.GetUserByUsername(userDto.Username);

                if (existingUser is not null)
                {
                    throw new BusinessException(ErrorCodes.GenericRegisterError,
                        "Username already in use");
                }
				else
				{ user.Username = userDto.Username;}
            }
			if(!string.IsNullOrEmpty(userDto.Name))
			{ 
				user.Name = userDto.Name;
			}
            bool IsValidEmail(string email)
            {
                return new EmailAddressAttribute().IsValid(email);
            }
            if (!string.IsNullOrEmpty (userDto.Email))
			{
                if (!IsValidEmail(userDto.Email))
                {
                    throw new BusinessException(ErrorCodes.GenericRegisterError,
                        "Invalid email address");
                }
				else 
					user.Email= userDto.Email;
            }
			if(!string.IsNullOrEmpty (userDto.Linkedin))
			{
				user.Linkedin = userDto.Linkedin;
			}
			if (!string.IsNullOrEmpty (userDto.Facebook))
			{ 
				user.Facebook = userDto.Facebook;
			}
			// verify if userDto is null if not change data

			unitOfWork.Users.Update(user);
			unitOfWork.SaveChanges();
		}
    }
}

