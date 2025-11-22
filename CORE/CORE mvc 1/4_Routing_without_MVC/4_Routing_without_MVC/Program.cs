using Microsoft.AspNetCore.Mvc;

namespace _4_Routing_without_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //step 2:
            builder.Services.AddControllersWithViews(); // except this line our views will be not showable.
            var app = builder.Build();

            //step 1:
            //app.MapGet("/", () => "Hello World!");      //we have to comment this line otherwise our view will not be visible. after this step we have to add a line before the builder.build(). 


            //step 3:
            //app.MapDefaultControllerRoute(); //this will only calls the home controller and it's index() method at first time.

            //this is called convention based routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{Controller=Home}/{action=Index}/{id?}" //we can change here to controller= Home
                );





            //Attribute Based Routing:
            //for attribute based routing we have to add first the 2 things:
            //1. Builder.Services.AddControllersWithViews();
            //2. app.MapControllers();

            app.MapControllers();


            app.Run();
        }
    }
}
