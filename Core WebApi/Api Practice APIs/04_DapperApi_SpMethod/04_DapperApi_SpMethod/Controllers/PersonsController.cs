using _04_DapperApi_SpMethod.Models;
using _04_DapperApi_SpMethod.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace _04_DapperApi_SpMethod.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepo _repo;

        public PersonsController(IPersonRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("AllPersons")]
        public async Task<IActionResult> Peoples()
        {
            var AllPersons = await _repo.GetAll();
            return Ok(AllPersons);
        }

        [HttpGet]
        [Route("FindPerson/{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var findPerson = await _repo.GetById(id);
            if(findPerson == null)
            {
                return BadRequest($"Person with Id {id} not found.");
            }
            return Ok(findPerson);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] Person person)
        {
            if(person == null)
            {
                return BadRequest("Invalid person data received.");
            }
            await _repo.Add(person);
            return Ok("Person added!");
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] Person person)
        {
            var findstudent = await _repo.GetById(person.Id);
            if(findstudent == null)
            {
                return NotFound();
            }
            await _repo.Edit(person);
            return Ok("Edited successfully!");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var findPerson = await _repo.GetById(id);
            if (findPerson == null)
            {
                NotFound();
            }
            await _repo.Delete(id);
            return Ok("deleted successfully!");
        }
    }
}
