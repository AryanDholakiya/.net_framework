using first_Core_MVC.data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace first_Core_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //this is for the join the database
            builder.Services.AddDbContext<MyContext>(option =>  option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

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
                pattern: "{controller=StudentData}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
