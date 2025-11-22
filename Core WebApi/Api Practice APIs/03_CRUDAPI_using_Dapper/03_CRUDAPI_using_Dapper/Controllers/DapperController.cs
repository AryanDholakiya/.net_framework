using _03_CRUDAPI_using_Dapper.Models;
using _03_CRUDAPI_using_Dapper.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _03_CRUDAPI_using_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperController : ControllerBase
    {
        private readonly IPersonRepository _repo;

        public DapperController(IPersonRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("AllPerson")]
        public async Task<IActionResult> AllPersonList()
        {
            var totalPersons = await _repo.GetAllAsync();
            return Ok(totalPersons);
        }
        [HttpGet]
        [Route("PersonById/{id}")]
        public async Task<IActionResult> PersonById(int id)
        {
            var Person = await _repo.GetById(id);
            return Ok(Person);
        }


        [HttpPut]
        [Route("AddPerson")]
        public async Task<IActionResult> AddPerson([FromBody]Person person)
        {
            var Personadded = await _repo.Add(person);
            return Ok("person added successfully!");
        }




        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> UpdateStudent([FromBody] Person person)
        {
            var FindPerson = await _repo.GetById(person.Id);
            if (FindPerson == null)
            {
                return NotFound("student data not found!");
            }
            await _repo.Edit(person);
            return Ok("Person updated successfully!");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {

            await _repo.Delete(id);
            return Ok("student deleted successfully!");
        }
    }
}
