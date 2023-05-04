using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectServices.Services.Users;

namespace hackatonBackend.ProjectServices.Mappers
{
	public static class UserMapper
	{
		public static UserDetailsDto ToDto(this User entity)
		{
			if (entity is null)
			{
				return null;
			}

			return new UserDetailsDto
			{
				Id = entity.Id,
				Avatar = entity.Avatar,
				Email = entity.Email,
				Name = entity.Name,
				Password = entity.Password
			};
		}

		public static User ToEntity(this UserDetailsDto dto)
		{
            if (dto is null)
            {
                return null;
            }

            return new User
            {
                Id = dto.Id,
                Avatar = dto.Avatar,
                Email = dto.Email,
                Name = dto.Name,
                Password = dto.Password
            };
        }
	}
}

