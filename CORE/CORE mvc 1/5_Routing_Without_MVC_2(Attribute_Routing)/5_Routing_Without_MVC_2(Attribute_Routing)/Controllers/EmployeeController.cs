using Microsoft.AspNetCore.Mvc;

namespace _5_Routing_Without_MVC_2_Attribute_Routing_.Controllers
{
    public class EmployeeController : Controller
    {
        [Route("Employee")]
        public IActionResult Index()
        {
            return View();
        }


        //Understanding : 1

        //this is called Attribute based routing.
        //to achieve this we have to add the     => Builder.Serrvices.AddCntrollersWithViews()  &
        //=> app.MapControllers();  in the Program.cs file.


        [Route("Employee/EmpId")]
        public IActionResult AllEmpIDs() //Understanding : 4
        {
            return View("~/Views/Employee/Index.cshtml");
        }
        //aapne koi IActionrsult ni method uppr jo Route define krie 6ie to IActionMethod nu koi pn name rakhie e ene kai leva deva nai. but the thing is jyare e route url ma enter krisu tyare route nicheni IActionResult  ni method no view return krse.
        //parantu name changed hovathi tene aapel method no view ni mle so, it will give an error.
        //then we have to define the the path of that View manually in "return View() with ~ symbol at starting.;





        //Undestanding : 2
        [Route("Employee/EmpId/{id?}")]
        public int Details(int? id)
        {
            return id ?? 1;   //if id==0 then 1 will be ruturn //Understanding : 3
        }
    }
}
