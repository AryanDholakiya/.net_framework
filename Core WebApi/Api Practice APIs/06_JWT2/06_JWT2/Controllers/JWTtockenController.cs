using _06_JWT2.Data;
using _06_JWT2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _06_JWT2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTtockenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly context _context;

        public JWTtockenController(IConfiguration configuration, context context)
        {
            _configuration = configuration;
            _context = context;
        }

        private object GenerateJwtToken(string userName)//this is our payload//Note the object here.
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // ક્લેમ્સ (Payload) ઉમેરો
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userName),
                new Claim(ClaimTypes.Name, userName),
                //new Claim(ClaimTypes.Role, "User") // રોલ ઉમેર્યો
            };

            // ટોકન ડિસ્ક્રિપ્ટર બનાવો
            var token = new JwtSecurityToken(
                issuer:null,
                audience: null,
                claims: null,
                expires: DateTime.Now.AddHours(1), // 1 કલાકમાં સમાપ્ત
                signingCredentials: credentials);

            // ટોકન પરત કરો
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var User = _context.users.FirstOrDefault(u => u.UserName == login.UserName && u.Password == login.Password);

            if(User == null)
            {
                return Unauthorized();
            }
            var tockenString = GenerateJwtToken(login.UserName);
            return Ok(new { tocken = tockenString });
        }

       
    }
}
