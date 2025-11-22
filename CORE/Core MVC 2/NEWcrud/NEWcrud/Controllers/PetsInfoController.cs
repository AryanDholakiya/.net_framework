using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEWcrud.Data;
using NEWcrud.Models;
using NuGet.Packaging;
using System.Collections;
using System.Drawing;

namespace NEWcrud.Controllers
{
    public class PetsInfoController : Controller
    {
        private readonly Petsdiary _DbContext; //DB સાથે કામ કરવા માટેનો DbContext ફીલ્ડ
                                               //Petsdiary na bdha data ahiya use krva mate we have to write this line.
        private readonly IWebHostEnvironment _hostEnvironment;

        public PetsInfoController(Petsdiary dbContext, IWebHostEnvironment hostEnvironment)
        {
            _DbContext = dbContext;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allpets = _DbContext.pets.Include(x => x.petCountries).ToList();
            return View(allpets);
        }

        [HttpGet]
        public IActionResult CreatePet()//this is for showing the default table data which is already in db.
        {
            var countries = _DbContext.PetCountries.ToList();
            var countryList = new SelectList(countries, "CountryId", "countryName");
            ViewBag.CountryList = countryList;
            return View();
        }

        [HttpPost]
        //this is for the checkboxes or hobbies.. string[] hobby bring the selected checkbox's value here with it...it uses the "name" attribute to check checkbox is selected or not.
        public async Task<IActionResult> CreatePet(PetCreate pet, string[] hobby)
        {
            if (pet.file != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(pet.file.FileName);
                string extension = Path.GetExtension(pet.file.FileName);
                pet.PetPhoto = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images", pet.PetPhoto);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await pet.file.CopyToAsync(fileStream);
                }
            }
            var Newpet = new Pet
            {
                petName = pet.petName,
                petAge = pet.petAge,
                petGender = pet.petGender,
                petAdoptedDate = pet.petAdoptedDate,
                petBreed = pet.petBreed,
                Hobbies = string.Join(", ", hobby),
                PetCountryId = pet.PetCountryId,
                PetPhoto = pet.PetPhoto
            };

            if (ModelState.IsValid)
            {
                pet.Hobbies = string.Join(", ", hobby);
                _DbContext.pets.Add(Newpet);  // note here "Add"
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pet);
        }


        [HttpGet]
        public IActionResult EditPet(int Id)
        {


            var selectedPet = _DbContext.pets.Where(pet => pet.petId == Id).FirstOrDefault();
            var countries = _DbContext.PetCountries.ToList();
            var countryList = new SelectList(countries, "CountryId", "countryName", selectedPet.PetCountryId);
            ViewBag.CountryList = countryList;
            return View(selectedPet);
        }

        [HttpPost]
        public async Task<IActionResult> EditPet(Pet pet, string[] hobby) //this for edit hobbies section also
        {
            if (pet.file != null)
            {
                // Delete the old photo
                if (!string.IsNullOrEmpty(pet.PetPhoto))
                {
                    var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", pet.PetPhoto);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(pet.file.FileName);
                string extension = Path.GetExtension(pet.file.FileName);
                pet.PetPhoto = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images", pet.PetPhoto);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await pet.file.CopyToAsync(fileStream);
                }
            }
            if (ModelState.IsValid)
            {
                pet.Hobbies = string.Join(", ", hobby);
                _DbContext.pets.Update(pet);  //note here "Update"
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
          return View(pet);

        }


        [HttpGet]
        public IActionResult DeletePet(int Id)
        {
            return View(_DbContext.pets.Where(pet => pet.petId == Id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult DeletePet(Pet pet)
        {
            _DbContext.pets.Remove(pet);  //note here "delete"
            _DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
