using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using stronglyTyped_PartialView_16.Models;

namespace stronglyTyped_PartialView_16.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Bata Shoes", Description = "Best in Comfort shoes.", Price=2100, Image = "~/Images/shoe.jpeg"},


                new Product() { Id = 2, Name = "RayBan Glasses", Description = "View the World with Shine.", Price=2100, Image = "~/Images/Glaass.jpeg"},

                new Product() { Id = 1, Name = "Bata Shoes", Description = "Best in market.", Price=2100, Image = "~/Images/watch.jpeg" }
            };
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
