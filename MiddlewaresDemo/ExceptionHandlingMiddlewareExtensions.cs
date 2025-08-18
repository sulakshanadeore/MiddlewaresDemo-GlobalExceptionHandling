using System.Runtime.CompilerServices;

namespace MiddlewaresDemo
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        //Extending the functionality of IApplicationbuilder to work with exception
        //Configuring Application Exception pipeline is done by IApplicationBuilder
        //And as we are extending the functionality of IApplicationbuilder, we write the class and method both
        //as "public static"
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }

}
