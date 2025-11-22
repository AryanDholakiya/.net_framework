namespace _5_Routing_Without_MVC_2_Attribute_Routing_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            //app.MapDefaultControllerRoute();
            //app.MapGet("/", () => "Hello World!");

            app.MapControllers();

            app.Run();
        }
    }
}
