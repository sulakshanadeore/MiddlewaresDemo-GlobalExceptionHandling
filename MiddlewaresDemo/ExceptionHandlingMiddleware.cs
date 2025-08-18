using System.Net;
using System.Text.Json;

namespace MiddlewaresDemo
{
    public class ExceptionHandlingMiddleware
    {
        RequestDelegate _next;
        ILogger<ExceptionHandlingMiddleware> _logger;


        public ExceptionHandlingMiddleware(RequestDelegate next,ILogger<ExceptionHandlingMiddleware> logger)
        {
        _next=next;
            _logger=logger;
        }

      public  async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorresponse = new {

                    StatusCodeFromServer = context.Response.StatusCode,
                    MessageFromServer = "Something went wrong",
                    DetailedMessageError = ex.Message
                };

                var json=JsonSerializer.Serialize(errorresponse);
                await context.Response.WriteAsync(json);    

            }
        }
    }
}
