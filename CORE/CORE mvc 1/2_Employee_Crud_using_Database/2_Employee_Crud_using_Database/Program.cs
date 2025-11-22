using _2_Employee_Crud_using_Database.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _2_Employee_Crud_using_Database
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            //these lines should be added for the database attachment
            builder.Services.AddDbContext<MyContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=EmpModels}/{action=Index}/{id?}");




            //creating middleware

            

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("welCome to asp.net core mvc project!");
            //});

            //this will run every page request 


            //if we creates the middleware using the "app.Run" and create the multiple middlewares using the "app.Run" then only the first "app.Run()" middleware will exuecutes , second one will not.
            //we have to use the "app.Use()" to create multiple middleware. "app.Use(context, next)" takes to parameters

            app.Use(async (context,next) =>
            {
                await context.Response.WriteAsync("welCome to asp.net core mvc project! \n");
                await next(context);
            });
            app.Use(async (another, next) =>
            {
                await another.Response.WriteAsync("middlware 2! \n");
                await next(another);
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Last middleware!");
            });

            //note: order of middleware is very important


            app.Run();
        }
    }
}
