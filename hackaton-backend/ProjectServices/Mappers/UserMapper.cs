using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectServices.Services.Common.Auth;
using hackatonBackend.ProjectServices.Services.Users;

namespace hackatonBackend.ProjectServices.Mappers
{
	public static class UserMapper
	{
		public static UserDto ToDto(this User entity)
		{
			if (entity is null)
			{
				return null;
			}

			return new UserDto
			{
				Id = entity.Id,
				Avatar = entity.Avatar,
				Facebook = entity.Facebook,
				Linkedin = entity.Linkedin,
				Role = (Role)entity.Role,
				PositionRole = (PositionRole)entity.PositionRole,
				Description = entity.Description,
				Email = entity.Email,
				Name = entity.Name,
				Password = entity.Password
			};
		}

		public static User ToEntity(this UserDto dto)
		{
            if (dto is null)
            {
                return null;
            }

            return new User
            {
                Id = dto.Id,
                Avatar = dto.Avatar,
                Facebook = dto.Facebook,
                Linkedin = dto.Linkedin,
                Role = (short)dto.Role,
                PositionRole = (short)dto.PositionRole,
                Description = dto.Description,
                Email = dto.Email,
                Name = dto.Name,
                Password = dto.Password
            };
        }
	}
}

