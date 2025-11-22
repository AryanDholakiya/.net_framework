using Microsoft.AspNetCore.Mvc;

namespace _6_Map_Method_Routing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); //ViewResult, PartialViewResult, JsonResult
        }
    }
}
