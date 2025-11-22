using _03_JWT_API_for_CRUDManually.Data;
using _03_JWT_API_for_CRUDManually.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _03_JWT_API_for_CRUDManually.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTtokenController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly context _context;

        public JWTtokenController(IConfiguration config, context context)
        {
            _config = config;
            _context = context;
        }

        private string GenerateToken(string studentName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // ક્લેમ્સ (Payload) ઉમેરો
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, studentName),
                new Claim(ClaimTypes.Name, studentName),
                //new Claim(ClaimTypes.Role, "User") // રોલ ઉમેર્યો
            };

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddHours(1), // 1 કલાકમાં સમાપ્ત
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Login login)
        {
            var student = _context.students.FirstOrDefault(s => s.LoginStudentName == login.LoginStudentName && s.Password == login.Password);

            if(student == null)
            {
                return Unauthorized();
            }

            var tokenstring = GenerateToken(login.LoginStudentName);
            return Ok(new {token = tokenstring});
        }


        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] Login register)
        {
            _context.students.Add(register);
            _context.SaveChanges();
            return Ok(register);
        }
    }
}
