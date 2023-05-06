using System;
using hackatonBackend.ProjectServices.Services.Users;

namespace hackatonBackend.WebApi.Models
{
    public class UserDetailsModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Role? Role { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public PositionRole? PositionRole { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}

