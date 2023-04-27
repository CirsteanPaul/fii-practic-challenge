using hackatonBackend.WebApi.Models.Authentication;
using hackatonBackend.ProjectServices.Services.Common.Auth;

namespace hackatonBackend.WebApi.Mappers
{
    public static class RegisterMapper
    {
        public static RegisterDto ToDto(this RegisterRequest model)
        {
            if(model is null)
            {
                return null;
            }

            return new RegisterDto
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
            };
        }
    }
}
