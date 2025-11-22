using Microsoft.AspNetCore.Mvc;

namespace Practice_Basics01.Controllers
{
    [Route("[controller]/[action]")]
    public class ViewDataController : Controller
    {
        [Route("")]
        [Route("~/")]
        [Route("~/ViewData")]
        public IActionResult Index()
        {
            //passing data from controller to view: 1) ViewData
            ViewData["data1"] = "Passed the data from Controller to View using ViewData['key']";
            ViewData["data2"] = 1;
            ViewData["data3"] = DateTime.Now.ToShortDateString();

            //pass the array using ViewData[]
            string[] arr = { "raju", "shyam", "babu" };
            ViewData["data4array"] = arr;

            //ViewData["Array"] = new string[]  // we cna pass the array like this way also
            //{
            //    "ajay", "sanjay", "Vijay"
            //};


            //pass the list (generic or non-gen) using ViewData[]
            ViewData["List"] = new List<string>
            {
                "Cricket", "Football", "VolleyBall", "Hockey"
            }; //semicolon is neccessary


            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

    }
}
