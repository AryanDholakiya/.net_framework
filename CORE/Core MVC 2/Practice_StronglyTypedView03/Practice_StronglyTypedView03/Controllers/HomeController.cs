using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Practice_StronglyTypedView03.Models;

namespace Practice_StronglyTypedView03.Controllers
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
            var person = new Person
            {
                Id = 1,
                Name = "helloworld",
                //Age = "age" // see this is the use of stronlgy typed data, it show the compile time error if we do the mistake;
            };
            return View(person);
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
