using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PET_PlatForm.Data;
using PET_PlatForm.Models;

namespace PET_PlatForm.Controllers
{
    public class PetController : Controller
    {
        private readonly PetData _petContext;

        public PetController(PetData petContext)
        {
            _petContext = petContext;
        }
        public async Task<IActionResult> PetIndex()
        {
            var PetList = await _petContext.AvailablePets.ToListAsync();
            return View(PetList);   //to prevent the NullReference Exception.
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(availablePets pet)
        {
            if (ModelState.IsValid)
            {
                _petContext.AvailablePets.Add(pet);
                _petContext.SaveChanges();
                return RedirectToAction("PetIndex","Pet");
            }

            return View();
        }

    }
}
