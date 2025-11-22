using Microsoft.AspNetCore.Mvc;

namespace _04_AttributeBasedRouting.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
