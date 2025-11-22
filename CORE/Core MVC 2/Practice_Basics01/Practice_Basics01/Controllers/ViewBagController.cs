using Microsoft.AspNetCore.Mvc;

namespace Practice_Basics01.Controllers
{
    [Route("[controller]")]
    public class ViewBagController : Controller
    {
        [Route("")]  //ahi juo jo aa add nai krisu to https://localhost:7052/ViewBag ma error avse. How?
        //[Route("[action]")]
        public IActionResult Index()
        {
            ViewBag.Bag1 = "ViewBag 1.";
            ViewBag.Bag2 = DateTime.Now.ToShortDateString();

            ViewBag.Bag3Arr = new string[]
            {
                "Dinesh", "vinesh", "pritesh"
            };

            ViewBag.Bag4Arr = new List<string>
            {
                 "Cricket", "Football", "VolleyBall", "Hockey"
            }; 

            return View();
        }
    }
}
