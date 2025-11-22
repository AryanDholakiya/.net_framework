using Microsoft.AspNetCore.Mvc;

namespace _04_DapperApi_Frontend.Controllers
{
    public class PersonsController : Controller
    {
        private HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            return View();
        }

    }
}
