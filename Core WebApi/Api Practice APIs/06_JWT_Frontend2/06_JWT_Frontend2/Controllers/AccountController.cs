using _06_JWT_Frontend2.Models;
using JsonConverter.Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json;
using NuGet.Common;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace _06_JWT_Frontend2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        //private string ApiURL = "https://localhost:7192/api/";
        //private HttpClient client = new HttpClient();

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory; //// 👉 HttpClient used for API call
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var tocken = HttpContext.Session.GetString("jwtTocken"); //Tocken vgr api call j nai thse

            if (tocken == null)
            {
                return RedirectToAction("Login");
            }

            var client = _httpClientFactory.CreateClient();

            // 👉 Add JWT token in request header //This is neccessary
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tocken);

            List<LoginModel> users = new List<LoginModel>();
            var response = await client.GetAsync("https://localhost:7192/api/Protected/GetAll");
            //https://localhost:7192/api/Protected/GetAll

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<LoginModel>>(result);

                if (data != null)
                {
                    users = data;
                }
            }

            return View(users);
        }

        [HttpGet]
        public IActionResult Login()
        {

            var tockenExist = HttpContext.Session.GetString("jwtTocken"); //Tocken vgr api call j nai thse

            if (tockenExist != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(model); //need to add the JsonConvert.NewtoSoft package first.
            //serialize means: convert the string data into jsonData.

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7192/api/JWTtocken/Login", content);
            //'https://localhost:7192/api/JWTtocken/Login

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(result);
                //why we had taken "dynamic"? >>> deserializeObject means that : converts a JSON string into a dynamic C# object.//dynamic keyword means the type is decided at runtime.
                // ahi result ma aappne aavu kaik mle as example:
                //{ 
                //    "token": "abc123",
                //    "username": "aryan"
                //}

                //so after deserialize we can access properties directly like: data.token , data.username


                string tocken = data.tocken;

                HttpContext.Session.SetString("jwtTocken", tocken); //NOTE: This is the main thing 

                return RedirectToAction("Dashboard");
            }
            TempData["error"] = "Invalid userName or Password";
            return RedirectToAction("Register");
        }


    }
}
