
namespace MiddlewaresDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //REGISTER SERVICES---dependency injection

            var app = builder.Build();
            
            //app.Use(async (context, next) => {
            //    Console.WriteLine("M1:BEfore the request");
            //    await next();
            //    Console.WriteLine("M1:After response");
            
            //});

            //app.Use(async (context, next) => {
            //    Console.WriteLine("M2:BEfore the request");
            //    await next();
            //    Console.WriteLine("M2:After response");

            //});

            ////Any middleware stops calling "next", it is short circuit, stop the pipeline by NOT calling next
            //app.Run(async context  =>{
            //    Console.WriteLine("M3:Handling the request");
                
            //    await context.Response.WriteAsync("Hello from pipeline");

            //});



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddleware<Request_ID_Generator>();
            //app.UseGlobalExceptionHandling();//Register using class  OR
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
