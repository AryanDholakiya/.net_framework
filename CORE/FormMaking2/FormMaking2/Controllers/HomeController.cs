using System.Diagnostics;
using FormMaking2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormMaking2.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("~/")]
        [Route("~/Home")]
        public IActionResult First()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Index()
        {
            return View(); // we can also write : return View(new Employees());
        }

        [HttpPost]
        public IActionResult Register(Employees Emp)
        {
            if (ModelState.IsValid)
            {
                TempData["successFull"] = $"Employee {Emp.Name} Registered";
                return RedirectToAction("EmpRecord", "Home");
            }

            return View("Index",Emp);
        }

        public IActionResult EmpRecord()
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
