using Microsoft.AspNetCore.Mvc;

namespace _5_Routing_Without_MVC_2_Attribute_Routing_.Controllers
{
    //Understanding : 5 -- other understandings are in EmployeeController

    [Route("Home")] // Jo apne "Home" route ne ahiya aa rite define kri daie to aagal bija routes ma kse
                    // [Route("Home/otherpage") lkhvane bdle  [Route("otherpage")] lkhi skay.


    //understanding 6 -- give tocken name instead of [Route("Home")].

    [Route("[Controller]/[action]")] //here the "[Controller]" is the tocken.
    public class HomeController : Controller
    {
        //[Route("")]
        [Route("~/")] //: jyare aapne default route [Route("Home")] HomeController class ni bahar define krri daisu tyre [Route("")] work nai kre that time we have to use [Route("~/")]
        [Route("~/Home")] // [Route("[Controller]/[action]")] mate.. aa nhi hoi ane khali controller na name ma o/p na aave
        //[Route("Home")]
        //[Route("Home/HomePage")]
        [Route("HomePage")]
        //[Route("[action]")] tocken controller ni bajuma aapi deidhu hovathi jroor nathi ahi aapvani
        public IActionResult HomePage()
        {
            return View();
        }


        //[Route("Home/Index")]
        [Route("Index")]
        //[Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }   


        //[Route("Home/DashBoard")]
        [Route("DashBoard")]
        //[Route("[action]")]
        public IActionResult DashBoard()
        {
            return View();
        }   
    }
}
