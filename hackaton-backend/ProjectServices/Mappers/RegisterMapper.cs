using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectServices.Services.Common.Auth;

namespace hackatonBackend.ProjectServices.Mappers
{
    public static class RegisterMapper
    {
        public static User ToEntity(this RegisterDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Email = userDto.Email
            };
        }
    }
}
