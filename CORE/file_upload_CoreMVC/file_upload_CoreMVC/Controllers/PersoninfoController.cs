using file_upload_CoreMVC.Data;
using file_upload_CoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace file_upload_CoreMVC.Controllers
{
    public class PersoninfoController : Controller
    {
        private readonly PersonData _DbContext;

        public PersoninfoController(PersonData dbContext)
        {
            _DbContext = dbContext;
        }

        public IActionResult Index()
        {
            var peopleList = _DbContext.person.ToList();
            return View(peopleList);
        }
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(Person file)
        {
            if(ModelState.IsValid)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.PersonImgFile.CopyToAsync(memoryStream);
                    file.personImg = memoryStream.ToArray();
                }

                _DbContext.person.Add(file);
                await _DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(file);
        }

      
        public IActionResult DisplayImage(int id)
        {
            var person = _DbContext.person.Find(id);
            if (person == null || person.personImg == null)
            {
                return NotFound();
            }
            return File(person.personImg, "image/jpeg"); 
        }



    }
}
