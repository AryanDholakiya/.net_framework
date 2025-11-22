using Microsoft.AspNetCore.Mvc;
using TagHelpers_DemoProject05.Models;
//we have to add this if we want to use the Model. it will be added automatically when we write the UserModel() and give ENTER.

namespace TagHelpers_DemoProject05.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("~/")]
        [Route("~/Home")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserModel());
        }
        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = $"Person {model.Name} registered SuccessFully 👍";
                return RedirectToAction("Contact", "Home");
            }
           
            return View("Index", model);
        }
    }
}
