using hackatonBackend.ProjectServices.Constants;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.WebApi.Extensions
{
    public static class ProblemDetailsExtensions
    {
        public static void AddErrorCode(this ProblemDetails problemDetails, string code)
        {
            problemDetails.Extensions.Add("code", code);
        }

        public static void AddErrorCode(this ProblemDetails problemDetails, ErrorCodes code)
        {
            problemDetails.Extensions.Add("code", code);
        }

        public static void AddEntityId(this ProblemDetails problemDetails, int id)
        {
            problemDetails.Extensions.Add("entityId", id);
        }
    }
}
