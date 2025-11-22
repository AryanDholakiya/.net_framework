using _05_JWT_frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace _05_JWT_frontend.Controllers
{
    //public class LoginModel
    //{
    //    public string? Username { get; set; }
    //    public string? Password { get; set; }
    //}

    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("JWToken")))
            {
                return RedirectToAction("SecuredData");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var client = _httpClientFactory.CreateClient("ApiClient");

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/JWT/login", content); // API call

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                // Response માંથી Token Extract કરો
                var tokenResponse = JsonSerializer.Deserialize<Dictionary<string, string>>(responseContent);
                var token = tokenResponse?["tocken"];

                if (!string.IsNullOrEmpty(token))
                {
                    // JWT ને સેશનમાં સ્ટોર કરો
                    HttpContext.Session.SetString("JWToken", token);
                    return RedirectToAction("SecuredData", "Home");
                }
            }

            // નિષ્ફળતાના કિસ્સામાં
            ModelState.AddModelError(string.Empty, "Invalid Username or Password or API error.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // સેશનમાંથી ટોકન દૂર કરો
            HttpContext.Session.Remove("JWToken");
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult SecuredData()
        {
            return View();
        }


    }
}
