using Ai_CRUD.Data;
using Ai_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Ai_CRUD.Controllers
{
    public class UserImagesController : Controller
    {
        private readonly AppDbContext _DbContext; //Data folder mathi j _DbContext aave : "AppDbContext"

        public UserImagesController(AppDbContext dbContext) // this is the dependency injection
        {
            _DbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person, IFormFile Photo)//if we give IFormFile "PhotoFile" then in modelstate.isvalid --> Photo will give false.
        {
            if (ModelState.IsValid)
            {
                if(Photo != null)
                {   
                    using (var ms = new MemoryStream()) //MemoryStream creates a temporary memory storage
                    {
                        await Photo.CopyToAsync(ms); //CopyToAsync(ms) copies the uploaded file into that memory.
                        person.Photo = ms.ToArray(); //ms.ToArray() converts the file into byte array (binary data).
                    }
                }
                _DbContext.Add(person);//Adds the person object (with all details + photo binary) into EF Core’s tracking system (ready to insert into DB).
                await _DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }


        public async Task<IActionResult> Index()
        {
            var persons = await _DbContext.Persons.ToListAsync(); // without await below line will show error
            return View(persons ?? new List<Person>());  //if you given [Required] then this line prevents the NullReference Exception.
        }
    }
}
