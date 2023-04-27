using hackatonBackend.WebApi.Controllers;
using Microsoft.AspNetCore.Builder;

namespace hackatonBackend.WebApi.Configuration
{
    public static class ExceptionHandling
    {
        public static readonly ExceptionHandlerOptions Options;

        static ExceptionHandling()
        {
            Options = new ExceptionHandlerOptions()
            {
                ExceptionHandlingPath = ErrorsController.ErrorHandlingRoute,
                AllowStatusCode404Response = true
            };
        }
    }
}
