using System.Net;
using Utilities.Constants;

namespace Utilities.Exceptions
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public Error ErrorResponse { get; set; }

        public CustomException()
        {
            ErrorResponse = new Error();
        }

        public CustomException(Error error, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError) : this ()
        {
            StatusCode = httpStatusCode;
            ErrorResponse = error;
        }

        public CustomException(string message = Constant.CustomExceptions.CustomExceptionMessage, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError) : this ()
        {
            StatusCode = httpStatusCode;
            ErrorResponse.Message = message;
        }

        public override string Message =>   ErrorResponse.Message != string.Empty ? $"Exception => {ErrorResponse.Message}, StatusCode => {StatusCode} " : base.Message;
    }
}
