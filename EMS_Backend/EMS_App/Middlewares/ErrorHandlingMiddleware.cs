using Newtonsoft.Json;
using System.Net;
using Utilities.Constants;
using Utilities.Exceptions;

namespace EMS_App.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate requestDelegate, ILoggerFactory logger) 
        {
            _requestDelegate = requestDelegate;
            _logger = logger.CreateLogger<ErrorHandlingMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (CustomException exception)
            {
                await HandleCustomeExceptions(context, exception);
            }
            catch (Exception ex)
            {
                await HandleDefaultExceptions(context, ex);
            }
        }

        private async Task HandleCustomeExceptions(HttpContext context, CustomException exception)
        {
            _logger.LogError($"Custom Exception, Name => {exception.GetType().Name},  Method => {context.Request?.Method}, Url => {context.Request?.Path.Value}, Message => {exception.Message}");
            
            await SendErrorResponse(context.Response, exception.StatusCode, exception.ErrorResponse);
        }

        private async Task HandleDefaultExceptions(HttpContext context, Exception exception)
        {
            _logger.LogError($"Default Exception, Name => {exception.GetType().Name},  Method => {context.Request?.Method}, Url => {context.Request?.Path.Value}, Message => {exception.Message}");
            
            await SendErrorResponse(context.Response, HttpStatusCode.InternalServerError, new Error(Constant.CustomExceptions.CustomExceptionMessage));
        }

        private async Task SendErrorResponse(HttpResponse response, HttpStatusCode statusCode, Error message)
        {
            try
            {
                response.ContentType = "application/json";
                response.StatusCode = (int)statusCode;
                await response.WriteAsync(JsonConvert.SerializeObject(message)).ConfigureAwait(false);
            }
            catch
            {
                _logger.LogError($"Unble to write message to the Response {message}");
            }
        }
    }
}
