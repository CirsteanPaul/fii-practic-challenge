using System.ComponentModel.DataAnnotations;

namespace hackatonBackend.WebApi.Models.Authentication
{
    public sealed class RegisterRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        public short? Role { get; set; }
    }
}
