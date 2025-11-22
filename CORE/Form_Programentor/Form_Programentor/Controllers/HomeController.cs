using System.Diagnostics;
using Form_Programentor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Form_Programentor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public string Details(int id, string name) //only for understanding
        //{
        //    return "id is:"+id+", name is:"+name;   
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        //form ni value get krva [httpPost] ni help thi manage kray 
        //how to bind the model data and get after submission.

        //[HttpPost]
        //public string Index(Employee e) //Employee e means Employee model Class ni bdhi value "e" OBJECT ma store thse.
        //    //Employee model class ne use krva teno nameSpace _ViewImports.cshtml ma store hoy chhe.
        //{
        //    if (ModelState.IsValid)
        //    {
        //    return $"Name:{ e.Name}\nGender:{e.Gender}\nAge:{e.Age}\nDesignation:{e.Designation}\nSalary:{e.Salary}" ;
        //    }
        //    return View("Index", e);
        //}

        [HttpPost]
        public IActionResult Index(Employee e)
        {
            if (ModelState.IsValid)
            {
                TempData["successfully"] = $"{e.Name} is added SuccessFully.";
                return View("Privacy","Home");
            }
            return View("Index", e);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
