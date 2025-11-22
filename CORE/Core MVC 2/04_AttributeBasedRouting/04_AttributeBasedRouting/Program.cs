namespace _04_AttributeBasedRouting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            //below we can see the Convention based routing.

            //app.MapControllerRoute(
            //    name: "Default",
            //    pattern: "{Controller=Home}/{action=index}/{id?}"
            //    );



            //Attribute based routing:
            app.MapControllers(); //just add this line for the attribute based routing and go to the contoller page

            app.Run();
        }
    }
}
