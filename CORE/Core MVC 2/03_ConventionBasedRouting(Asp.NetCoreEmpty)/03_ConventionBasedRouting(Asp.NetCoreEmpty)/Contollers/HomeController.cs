using Microsoft.AspNetCore.Mvc;

namespace _03_ConventionBasedRouting_Asp.NetCoreEmpty_.Contollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
