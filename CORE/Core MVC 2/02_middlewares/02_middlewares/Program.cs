namespace _02_middlewares
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!"); // MapGet is basically a middleware. 

            //creating our own middleware
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("This Message is showing from Custom Middleware!");
            //});

            //remember that app.Run() only runs the First middleware output. so we have to use the       app.Use(parameter 1 , parameter 1).
           

            app.Use(async (first, next) =>
            {
                await first.Response.WriteAsync("This is the middleware 1. \n");
                await next(first); //this is for call the second middleware.
            });

            app.Run(async(context) =>
            {
                await context.Response.WriteAsync("This is the middleware 2.");
            });




            app.Run();
        }
    }
}
