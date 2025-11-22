namespace _03_ConventionBasedRouting_Asp.NetCoreEmpty_
{
    //Convention based routing achieve krva nichena steps follow krva.
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews(); //step-2 : we have to register this service after we have to Build our application as we builded  in belowed line.

            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!"); // step-1: remove/Comment this line first

            //app.MapDefaultControllerRoute(); //step-3: this will only call the home contoller's index() action method...//--> if we want to use the other controller at the first time then we have to the       

            //app.MapControllerRoute(name: " ", pattern: "{Controller= } / {action= } / {id? }")


            //Convention based Routing:
            //this will contain 2 parameters : name and pattern
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=user}/{action=index}/{id?}"  //note that {controller=Home} or etc ma space hovi joie nahi. otherwise it will not run as per the requirement.
            );


            app.Run();
        }
    }
}
