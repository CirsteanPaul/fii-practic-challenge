using hackatonBackend.ProjectData.Entities;

namespace hackatonBackend.ProjectServices.Services.Common.Auth
{
    public interface IAuthService
    {
        string LoginUser(string username, string password);
        void RegisterUser(RegisterDto dto);
    }
}
