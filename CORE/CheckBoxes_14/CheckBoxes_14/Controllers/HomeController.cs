using System.Diagnostics;
using CheckBoxes_14.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheckBoxes_14.Controllers
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
            var model = new CheckModel()
            {
                AcceptTerms = false,

                CheckBoxes = new List<CheckBoxOption>
                {
                  new CheckBoxOption()
                  {
                       Text = "Cricket",
                       ValueOfCheck = "Cricket",
                  },
                  new CheckBoxOption()
                  {
                      
                       Text = "Hockey",
                       ValueOfCheck = "Hockey",
                  },
                  new CheckBoxOption()
                  {
                      
                       Text = "Football",
                       ValueOfCheck = "Football",
                  }
                }
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CheckModel data)
        {
            var result = data.AcceptTerms;
            var selected = data.CheckBoxes.Where(x => x.IscheckedOrNot).Select(x => x.ValueOfCheck).ToList();
            if (result)
            {
                TempData["AcceptedTerms"] = string.Join(",", selected);
                return RedirectToAction(nameof(Privacy));
            }

            // If not accepted, reload checkboxes again without belowed code it will give error
            data.CheckBoxes = new List<CheckBoxOption>
            {
                 new CheckBoxOption { Text = "Cricket", ValueOfCheck = "Cricket" },
                 new CheckBoxOption { Text = "Hockey", ValueOfCheck = "Hockey" },
                 new CheckBoxOption { Text = "Football", ValueOfCheck = "Football" }
            };

            return View(data);
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
