using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProtectedController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            return Ok($"Hello {username}, there is secure data!");
        }

        [HttpGet("admin-data")]
        [Authorize(Roles = "Admin")] // ફક્ત 'Admin' રોલ માટે
        public IActionResult GetAdminData()
        {
            return Ok("Only admins can see this!");
        }
    }
}
