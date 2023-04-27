using System.Collections.Generic;
using hackatonBackend.ProjectServices.Constants;
using hackatonBackend.ProjectServices.Exceptions;

namespace HackBackend.Web.Exceptions
{
    public class InvalidModelException : BaseException
    {
        public IDictionary<string, string[]> Errors { get; }

        public InvalidModelException() : base(ErrorCodes.GenericInvalidApiModel) 
        {
            Errors = new Dictionary<string, string[]>();
        }

        public InvalidModelException(string message) : base(ErrorCodes.GenericInvalidApiModel, message)
        {
            Errors = new Dictionary<string, string[]>();
        }

        public InvalidModelException(ErrorCodes code) : base(code)
        {
            Errors = new Dictionary<string, string[]>();
        }

        public InvalidModelException(ErrorCodes code, string message) : base(code, message)
        {
            Errors = new Dictionary<string, string[]>();
        }

        public InvalidModelException(string message, IDictionary<string, string[]> errors) : base(ErrorCodes.GenericInvalidApiModel, message)
        {
            Errors = errors;
        }

        public InvalidModelException(ErrorCodes code, string message, IDictionary<string, string[]> errors) : base(code, message)
        {
            Errors = errors;
        }
    }
}
