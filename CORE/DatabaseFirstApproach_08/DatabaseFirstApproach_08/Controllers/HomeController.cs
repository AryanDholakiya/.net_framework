using System.Diagnostics;
using DatabaseFirstApproach_08.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseFirstApproach_08.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KennelContext context;

        public HomeController(ILogger<HomeController> logger, KennelContext context) //KennelContext context add this here , put cursor on "context" and press "ctrl + ." --> select "create and assign field."
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var data = context.Persons.ToList();
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
