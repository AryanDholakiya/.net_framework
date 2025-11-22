using System.Diagnostics;
using Bind_DropDownList_With_Db_13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bind_DropDownList_With_Db_13.Controllers
{
    public class HomeController : Controller
    {
        private readonly BindDropDownListContext context;

        public HomeController(BindDropDownListContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var pets = this.context.Pets.Include(x => x.Country).ToList();
            return View(pets);
        }
        public IActionResult Create()
        {
            var countries = context.PetCountries.ToList();
            var countryList = new SelectList(countries, "Id", "Countries");
            ViewBag.CountryList = countryList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pet pet)
        {
            this.context.Pets.Add(pet);
            this.context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
