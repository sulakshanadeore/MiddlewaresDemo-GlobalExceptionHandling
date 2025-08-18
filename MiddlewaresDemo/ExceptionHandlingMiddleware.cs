using MiddlewaresDemo.Models;
using System.Net;
using System.Text.Json;

namespace MiddlewaresDemo
{
    public class ExceptionHandlingMiddleware
    {
        RequestDelegate _next;
        ILogger<ExceptionHandlingMiddleware> _logger;
        ILogger<EmployeeNotFoundExceptionException> _emplogger;


        public ExceptionHandlingMiddleware(RequestDelegate next,ILogger<ExceptionHandlingMiddleware> logger, ILogger<EmployeeNotFoundExceptionException> emplogger  )
        {
            _next = next;
            _logger = logger;
            _emplogger = emplogger;
        }

        public  async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EmployeeNotFoundExceptionException ex)
            {
                _emplogger.LogError(ex, "Employee exception");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.NoContent;

                var errorresponse1 = new
                {

                    StatusCodeFromServer = context.Response.StatusCode,
                    MessageFromServer = "Check EmployeeID you entered",
                    DetailedMessageError = ex.Message
                };

                var json = JsonSerializer.Serialize(errorresponse1);
                await context.Response.WriteAsync(json);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorresponse = new
                {

                    StatusCodeFromServer = context.Response.StatusCode,
                    MessageFromServer = "Something went wrong",
                    DetailedMessageError = ex.Message
                };

                var json = JsonSerializer.Serialize(errorresponse);
                await context.Response.WriteAsync(json);

            }
        }
    }
}
