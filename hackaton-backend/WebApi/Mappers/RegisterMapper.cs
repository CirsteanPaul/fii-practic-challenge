using hackatonBackend.WebApi.Models.Authentication;
using hackatonBackend.ProjectServices.Services.Common.Auth;
using hackatonBackend.ProjectServices.Services.Users;

namespace hackatonBackend.WebApi.Mappers
{
    public static class RegisterMapper
    {
        public static RegisterDto ToDto(this RegisterRequest model)
        {
            if (model is null)
            {
                return null;
            }

            return new RegisterDto
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                Role = (Role?)model.Role
            };
        }
    }
}
