using _06_JWT2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace _06_JWT2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class ProtectedController : ControllerBase
    {
        private readonly context _context;

        public ProtectedController(context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetData")]
        public async Task<IActionResult> GetData()
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            return Ok($"Hello {username}, Data is Secured!");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll() //https://localhost:7192/api/Protected/GetAll
        {
            var users = await _context.users.ToListAsync();
            return Ok(users);
        }
    }
}
