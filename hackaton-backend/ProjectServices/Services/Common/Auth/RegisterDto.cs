using hackatonBackend.ProjectServices.Services.Users;

namespace hackatonBackend.ProjectServices.Services.Common.Auth
{
    public sealed class RegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role? Role { get; set; }
    }
}
