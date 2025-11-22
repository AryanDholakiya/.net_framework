using System.Diagnostics;
using LoginFormWithSession.Data;
using LoginFormWithSession.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LoginFormWithSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _userperson;

        public HomeController(ILogger<HomeController> logger, MyDbContext Userperson)
        {
            _logger = logger;
            _userperson = Userperson;
        }

        public IActionResult Index()
        {
            var totalUsers =  _userperson.users.ToList();
            return View(totalUsers);
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var MyUser = _userperson.users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (MyUser != null)
            {
                HttpContext.Session.SetString("UserSession", MyUser.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login Failed!";
            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        //------register

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User person)
        {
            if (ModelState.IsValid)
            {
                await _userperson.users.AddAsync(person);
                await _userperson.SaveChangesAsync();
                TempData["Success"]= "Registered Successfully!";
                return RedirectToAction("Index");
            }

            return View();
        }









        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
