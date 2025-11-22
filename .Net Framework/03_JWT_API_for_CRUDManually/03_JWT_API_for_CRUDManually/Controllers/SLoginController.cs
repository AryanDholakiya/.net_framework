using _03_JWT_API_for_CRUDManually.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace _03_JWT_API_for_CRUDManually.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SLoginController : ControllerBase
    {
        private readonly context _context;

        public SLoginController(context context)
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
        [Route("AllStudents")]
        public async Task<IActionResult> getAll()
        {
            var students = await _context.students.ToListAsync();
            return Ok(students);
        }
    }
}
