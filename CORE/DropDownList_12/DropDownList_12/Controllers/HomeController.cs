using System.Diagnostics;
using DropDownList_12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DropDownList_12.Controllers
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
            List<SelectListItem> JobRole = new()
            {
                new SelectListItem {Value="React",Text="React Developer"},
                new SelectListItem {Value="Angular",Text="Angular Developer"},
                new SelectListItem {Value=".net",Text=".net Developer"},
            };

            ViewBag.JobRole = JobRole;
            return View();
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
