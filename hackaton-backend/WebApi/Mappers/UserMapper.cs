using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectServices.Services.Common.Auth;
using hackatonBackend.ProjectServices.Services.Users;
using hackatonBackend.WebApi.Models;

namespace hackatonBackend.WebApi.Mappers
{
	public static class UserMapper
	{
        public static UserDetailsModel ToApiModel(this UserDto dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new UserDetailsModel
            {
                Id = dto.Id,
                Avatar = ImageMapper.AddPrefixToImage(dto.Avatar),
                Facebook = dto.Facebook,
                Linkedin = dto.Linkedin,
                Username = dto.Username,
                PositionRole = dto.PositionRole,
                Role = dto.Role,
                Description = dto.Description,
                Email = dto.Email,
                Name = dto.Name,
                Password = dto.Password
            };
        }

        public static UserModel ToApiUserModel(this UserDto dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new UserModel
            {
                Id = dto.Id,
                Avatar = ImageMapper.AddPrefixToImage(dto.Avatar),
                PositionRole = dto.PositionRole,
                Description = dto.Description,
                Name = dto.Name,
            };
        }

        public static UserDto ToDto(this UserDetailsModel model)
        {
            if (model is null)
            {
                return null;
            }

            return new UserDto
            {
                Username = model.Username,
                Avatar = model.Avatar,
                Facebook = model.Facebook,
                Linkedin = model.Linkedin,
                PositionRole = model.PositionRole,
                Description = model.Description,
                Email = model.Email,
                Name = model.Name,
                Password = model.Password
            };
        }
    }
}

