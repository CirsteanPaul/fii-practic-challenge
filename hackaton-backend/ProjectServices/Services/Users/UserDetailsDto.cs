﻿using System;
namespace hackatonBackend.ProjectServices.Services.Users
{
	public class UserDetailsDto
	{
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}

