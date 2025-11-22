using Microsoft.EntityFrameworkCore;
using ViewModel_BindMultiModel_withView.Models;

namespace ViewModel_BindMultiModel_withView
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<StudentInfoContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("myconnectionstring"));
            });

            builder.Services.AddDbContext<EmployeeInfoContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("AnotherCString"));
            });

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
