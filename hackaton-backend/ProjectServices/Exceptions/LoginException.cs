using hackatonBackend.ProjectServices.Constants;
using System;

namespace hackatonBackend.ProjectServices.Exceptions
{
    public class LoginException : BaseException
    {
        public LoginException(string message) : base(ErrorCodes.GenericAuthenticationError, message)
        {
        }
    }
}
