using System;
namespace hackatonBackend.ProjectServices.Services.Users
{
	public interface IUserService
	{
        UserDetailsDto GetDetails(int? userId);
    }
}

