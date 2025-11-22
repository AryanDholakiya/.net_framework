using JQueryAndAjaxCRUD2.Data;
using JQueryAndAjaxCRUD2.Models;
using JQueryAndAjaxCRUD2.Repositories;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace JQueryAndAjaxCRUD2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //NOTE:This we added for the email sending process.
            builder.Services.AddSingleton<EmailService>();

            builder.Services.AddScoped<IEmailService, EmailService>(); 

            builder.Services.AddDbContext<EmpData>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"));
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
                pattern: "{controller=AllEmp}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
