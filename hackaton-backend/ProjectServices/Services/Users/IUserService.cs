using System;
using hackatonBackend.ProjectServices.Services.Common.Auth;

namespace hackatonBackend.ProjectServices.Services.Users
{
	public interface IUserService
	{
        UserDto GetDetails(int? userId);
    }
}

