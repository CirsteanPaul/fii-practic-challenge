using System;
using hackatonBackend.ProjectServices.Services.Users;

namespace hackatonBackend.WebApi.Models
{
	public class UserModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public PositionRole? PositionRole { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
    }
}

