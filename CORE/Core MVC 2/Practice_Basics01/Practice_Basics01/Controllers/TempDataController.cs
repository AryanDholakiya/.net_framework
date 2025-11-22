using Microsoft.AspNetCore.Mvc;

namespace Practice_Basics01.Controllers
{
    [Route("[Controller]")]
    public class TempDataController : Controller
    {
        [Route("")]
        [Route("[action]")]
        public IActionResult Index()
        {
            ViewData["VData1"] = "ViewData Example";
            ViewBag.ViewBag = "ViewBag Example";
            TempData["TempData"] = "TempData Example";

            string[] arr = { "raju", "kaju", "baju" };
            TempData["TempArray"] = arr;

            TempData.Keep();

               
            return View();
        }

        [Route("[action]")]
        public IActionResult About()
        {
            TempData.Keep();
            return View();
        }

        [Route("[action]")]
        public IActionResult Contact()
        {
            TempData.Keep();
            return View();
        }

    }
}
