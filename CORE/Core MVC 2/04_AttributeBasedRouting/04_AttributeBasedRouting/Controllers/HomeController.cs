using Microsoft.AspNetCore.Mvc;

namespace _04_AttributeBasedRouting.Controllers
{
    public class HomeController : Controller
    {
        [Route("")] // ""(empty) means url ma kai nai hse tyare aa view run thase pela.
        [Route("Home")]
        [Route("Home/Index")]  //means 3 mathi koi bhi route hse to ema nicheni index method run thse.
        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("Home/GetId/{Id?}")] // note that how we defined the route of this parameterized actlon method. //if we dont enter the id then default value "0" will appear because of "?"
        public int GetId(int? id) //we can make our parameter NULLABLE using "?"
        {
            return id ?? 1; // "??" -- means NULL COALESES operator. --> that means, if id = null then 1 will be printed instead of null.
        }
    }
}
