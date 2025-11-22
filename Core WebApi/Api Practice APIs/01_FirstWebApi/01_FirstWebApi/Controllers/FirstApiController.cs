using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01_FirstWebApi.Controllers
{
    [Route("api/[controller]")] //req Url: https://localhost:7266/api/FirstApi   
    [ApiController]
    public class FirstApiController : ControllerBase
    {
        public List<string> fruits = new List<string>
        {
            "mango", "pineApple", "grapes", "banana"
        };

        [HttpGet]
        public List<string> getFruits()
        {
            return fruits;
        }

        //This is neccessary to give bcz if we don't give then after seeing the url application got confuse for which method it has to call
        [HttpGet("{id}")]//req Url: https://localhost:7266/api/FirstApi/1
        public string getFruitById(int id) //note the "string" dataType here.
        {
            return fruits.ElementAt(id);
        }
    }
}
