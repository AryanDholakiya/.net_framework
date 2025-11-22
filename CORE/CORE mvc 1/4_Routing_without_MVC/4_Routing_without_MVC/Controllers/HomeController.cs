using Microsoft.AspNetCore.Mvc;

namespace _4_Routing_without_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //creating the another view in HomeController
        public IActionResult About()
        {
            return View();
        }

        public int Id(int id)
        {
            return id;
        }

        //try to change the route like : https://localhost:7272/Home/Id/3
    }
}
