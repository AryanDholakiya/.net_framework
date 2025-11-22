using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session_10.Models;
using Microsoft.AspNetCore.Http;

namespace Session_10.Controllers
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
            HttpContext.Session.SetString("Name", "ABCDEFGH");
            return View();
        }

        public IActionResult About()
        {
            ViewBag.SessData = HttpContext.Session.GetString("Name");
            return View();
        }
        public IActionResult Details()
        {
            ViewBag.SessData = HttpContext.Session.GetString("Name");
            return View();
        }
        public IActionResult LogoutSession()
        {
            HttpContext.Session.Remove("Name");
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
