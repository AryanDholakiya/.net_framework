using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2_Employee_Crud_using_Database.Data;
using _2_Employee_Crud_using_Database.Models;

namespace _2_Employee_Crud_using_Database.Controllers
{
    public class EmpModelsController : Controller
    {
        private readonly MyContext _context;

        public EmpModelsController(MyContext context)
        {
            _context = context;
        }

        // GET: EmpModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.employees.ToListAsync());
        }

        // GET: EmpModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empModel = await _context.employees
                .FirstOrDefaultAsync(m => m.empId == id);
            if (empModel == null)
            {
                return NotFound();
            }

            return View(empModel);
        }

        // GET: EmpModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("empId,empName,empEmail,EmpSalary")] EmpModel empModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empModel);
        }

        // GET: EmpModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empModel = await _context.employees.FindAsync(id);
            if (empModel == null)
            {
                return NotFound();
            }
            return View(empModel);
        }

        // POST: EmpModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("empId,empName,empEmail,EmpSalary")] EmpModel empModel)
        {
            if (id != empModel.empId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpModelExists(empModel.empId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empModel);
        }

        // GET: EmpModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empModel = await _context.employees
                .FirstOrDefaultAsync(m => m.empId == id);
            if (empModel == null)
            {
                return NotFound();
            }

            return View(empModel);
        }

        // POST: EmpModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empModel = await _context.employees.FindAsync(id);
            if (empModel != null)
            {
                _context.employees.Remove(empModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpModelExists(int id)
        {
            return _context.employees.Any(e => e.empId == id);
        }
    }
}
