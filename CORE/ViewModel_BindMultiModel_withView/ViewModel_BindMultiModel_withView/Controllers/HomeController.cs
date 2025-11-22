using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModel_BindMultiModel_withView.Models;

namespace ViewModel_BindMultiModel_withView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentInfoContext _context;
        private readonly EmployeeInfoContext _empContext;

        public HomeController(ILogger<HomeController> logger, StudentInfoContext context, EmployeeInfoContext EmpContext)
        {
            _logger = logger;
            _context = context;
            _empContext = EmpContext;
        }

       

        public IActionResult Index()
        {
            var studentData = _context.Students.ToList();
            var EmployeeData = _empContext.Employees.ToList();

            SchoolViewModel SCM = new SchoolViewModel(); //Note this --> we have to write it here.
            SCM.MyStudents = studentData;
            SCM.MyEmployees = EmployeeData;

            return View(SCM);
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
