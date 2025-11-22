using JQueryAndAjaxCRUD2.Data;
using JQueryAndAjaxCRUD2.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JQueryAndAjaxCRUD2.Controllers
{
    public class AllEmpController : Controller
    {
        private readonly EmpData _context;

        public AllEmpController(EmpData context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult EmpList()
        {
            //var data = _context.Employyee.ToList();
            //return Json(data);
            var data = _context.Employyee.Select(e => new
            {
                e.empId,
                e.empName,
                e.empEmail,
                e.EmpSalary,
                empPhoto = e.empPhoto!=null ? Convert.ToBase64String(e.empPhoto) : ""
            }).ToList();
           
            return Json(data);
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(EmpModel emp, IFormFile Photo)
        {
            if (Photo != null)
            {
                using (var ms = new MemoryStream()) //MemoryStream creates a temporary memory storage
                {
                    Photo.CopyToAsync(ms); //CopyToAsync(ms) copies the uploaded file into that memory.
                    emp.empPhoto = ms.ToArray(); //ms.ToArray() converts the file into byte array (binary data).
                }
            }
            _context.Employyee.Add(emp);
            _context.SaveChanges();
            return Json(emp);
        }



        public IActionResult Edit(int id)
        {
            var record = _context.Employyee.Find(id);
            if (record.empPhoto == null)
            {
                ViewBag.NullImage = "Image Not Found!";
                return View(record);
            }
            else
            {
                record.photoForEdit = Convert.ToBase64String(record.empPhoto);
            }
            return View(record);
        }

        [HttpPost]
        public JsonResult Edit(EmpModel emp, IFormFile Photo)
        {
            if (Photo != null)
            {
                using (var ms = new MemoryStream()) //MemoryStream creates a temporary memory storage
                {
                    Photo.CopyToAsync(ms); //CopyToAsync(ms) copies the uploaded file into that memory.
                    emp.empPhoto = ms.ToArray(); //ms.ToArray() converts the file into byte array (binary data).
                }
            }
            _context.Employyee.Update(emp);
            _context.SaveChanges();
            return Json(emp);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var record = _context.Employyee.Find(id);
            _context.Employyee.Remove(record);
            _context.SaveChanges();
            return Json(id);
        }
    }
}
