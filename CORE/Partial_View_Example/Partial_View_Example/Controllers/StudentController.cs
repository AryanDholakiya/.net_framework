using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Partial_View_Example.data;
using Partial_View_Example.Models;

namespace Partial_View_Example.Controllers
{
    public class StudentController : Controller
    {
        private readonly DbContextfile _context;

        public StudentController(DbContextfile Context)
        {
            _context = Context;
        }

        public IActionResult Index()
        {
            var students = _context.users.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //return View(_context.users.Where(user => user.SId == id).FirstOrDefault()); //this will also work
            var FindUser = _context.users.Find(id);
            return View(FindUser);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var findUser = _context.users.Find(id);
            _context.users.Remove(findUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
