namespace MiddlewaresDemo
{
    public class Request_ID_Generator
    {
        RequestDelegate _next;
        public Request_ID_Generator(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {

            var requestid = Guid.NewGuid().ToString();
            context.Response.OnStarting(() => {
                context.Response.Headers.Add("X-Request-ID", requestid);
                return Task.CompletedTask;
                });
            context.Items["RequestId"] = requestid;
            await _next(context);
        
        }
    }
}
