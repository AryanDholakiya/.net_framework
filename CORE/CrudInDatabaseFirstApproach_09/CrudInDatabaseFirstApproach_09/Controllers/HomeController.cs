using System.Diagnostics;
using CrudInDatabaseFirstApproach_09.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudInDatabaseFirstApproach_09.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CrudInDbFirstApproachContext context;

        public HomeController(ILogger<HomeController> logger, CrudInDbFirstApproachContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var data = context.Students.ToList();
            return View(data);
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
