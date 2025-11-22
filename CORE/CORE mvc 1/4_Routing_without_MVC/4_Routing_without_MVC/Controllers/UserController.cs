using Microsoft.AspNetCore.Mvc;

namespace _4_Routing_without_MVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
// Must change the name of the Controller if its name is like: "UserController1" . 
//change it to: "UserController". otherwise it will be problamatic during routing time.