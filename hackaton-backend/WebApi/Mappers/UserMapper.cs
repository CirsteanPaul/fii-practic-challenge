﻿using System;
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
                PositionRole = dto.PositionRole,
                Role = dto.Role,
                Description = dto.Description,
                Email = dto.Email,
                Name = dto.Name,
                Password = dto.Password
            };
        }
    }
}
