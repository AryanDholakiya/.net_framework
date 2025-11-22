using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MIgration_CodeFirstApproach_07.Models;

namespace MIgration_CodeFirstApproach_07.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentDbContext studentDB;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(StudentDbContext studentDB)
        {
            this.studentDB = studentDB;
        }
        public IActionResult Index()
        {
            var stdData = studentDB.students.ToList();
            return View(stdData);
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
