namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error"); // this is middleware to handle error
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection(); //This is middleware
            app.UseStaticFiles();  //This is middleware : aa middleware static files use krvani allowance aape chhe. ex : wwwroot ma rhel image folder mathi image no use krvani allowance.

            app.UseRouting();  //This is middleware

            app.UseAuthorization();  //This is middleware

            app.MapControllerRoute(
                name: "DefaultRoute", //we can changed the name. to "DefaultRoute" from "default". but can' remmove this "name" field.
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
