using AjaxWithJQuery.Data;
using AjaxWithJQuery.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxWithJQuery.Controllers
{
    public class EmpInfoController : Controller
    {
        private readonly Empcontext empcontext;

        public EmpInfoController(Empcontext empcontext)
        {
            this.empcontext = empcontext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult EmpList()
        {
            var data = this.empcontext.Employees.ToList();
            return Json(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(Employees employees)
        {
            this.empcontext.Employees.Add(employees);
            empcontext.SaveChanges();
            return Json(employees);
        }

        public IActionResult Edit(int id)
        {
            var record = this.empcontext.Employees.Find(id);
            return View(record);
        }

        [HttpPost]
        public JsonResult Edit(Employees employees)
        {
            this.empcontext.Employees.Update(employees);
            empcontext.SaveChanges();
            return Json(employees);
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var record =  this.empcontext.Employees.Find(Id);
            this.empcontext.Employees.Remove(record);
            empcontext.SaveChanges();
            return Json(Id);
        }
    }
}
