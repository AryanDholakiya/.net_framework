using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud.Controllers
{
    public class EmpInfoController : Controller
    {
        private readonly MyDbContext _dbContext; 
        public EmpInfoController(MyDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        [HttpGet]
        public IActionResult Index()
        {
           
            return View(_dbContext.employees.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _dbContext.employees.Add(employee);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(_dbContext.employees.Where(emp => emp.EmpId == Id).FirstOrDefault());
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
           
            _dbContext.employees.Update(employee);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            if (Id > 0)
            {
                var delete = _dbContext.employees.Where(emp => emp.EmpId == Id).FirstOrDefault();
                _dbContext.employees.Remove(delete);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
