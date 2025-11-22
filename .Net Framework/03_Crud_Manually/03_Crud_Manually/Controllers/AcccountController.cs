//using _03_Crud_Manually.Models;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.UI.WebControls;
//using static System.Net.WebRequestMethods;

//namespace _03_Crud_Manually.Controllers
//{
//    public class AcccountController : Controller
//    {
//        private string ApiUrl = "localhost:7156/api/";
//        private HttpClient client = new HttpClient();

//        [HttpGet]
//        public ActionResult Login()
//        {
//            return View();
//        }


//        [HttpPost]
//        public async Task<ActionResult> Login(Student student)
//        {
//            var jsonData = JsonConvert.SerializeObject(student);
//            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
//            var response = await client.PostAsync(ApiUrl + "JWTtoken/Login", content);

//            if (response.IsSuccessStatusCode)
//            {
//                var result = await response.Content.ReadAsStringAsync();
//                dynamic data = JsonConvert.DeserializeObject(result);

//                string token = data.token;

//                Session["jwtToken"] = token;
//                return RedirectToAction("dashboard");
//            }
//            TempData["error"] = "Invalid userName or Password";
//            return RedirectToAction("Register");
//        }


//        [HttpGet]
//        public ActionResult Register()
//        {
//            return View();
//        }


//        [HttpGet]
//        public async Task<ActionResult> dashboard()
//        {
//            var token = Session["jwtToken"] as string;

//            if (token == null)
//            {
//                return RedirectToAction("Login");
//            }

//            var client = new HttpClient();
//            client.DefaultRequestHeaders.Authorization =
//                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

//            List<Student> studentList = new List<Student>();
//            var response = await client.GetAsync(ApiUrl + "SLogin/AllStudents");

//            if (response.IsSuccessStatusCode)
//            {
//                string result = await response.Content.ReadAsStringAsync();
//                var data = JsonConvert.DeserializeObject<List<Student>>(result);

//                if (data != null)
//                {
//                    studentList = data;
//                }
//            }
//            return View(studentList);
//        }
//    }
//}