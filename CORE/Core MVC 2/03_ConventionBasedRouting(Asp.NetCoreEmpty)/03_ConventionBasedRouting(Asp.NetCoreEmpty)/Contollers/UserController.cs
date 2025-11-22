using Microsoft.AspNetCore.Mvc;

namespace _03_ConventionBasedRouting_Asp.NetCoreEmpty_.Contollers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public int Details(int id) // note that here IAction result will replaced by "int"
        {
            return id; 
        }
    }
}
