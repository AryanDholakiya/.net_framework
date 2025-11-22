using InvoiceProject_Using_PartialView.Data;
using InvoiceProject_Using_PartialView.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InvoiceProject_Using_PartialView.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly DataContext _context;

        public InvoiceController(DataContext Context)
        {
            _context = Context;
        }

        public IActionResult Index()
        {
            var customers = _context.customers.ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return Json(new { success = false, message = "Customer not Found!" });
            }
            if (string.IsNullOrWhiteSpace(customer.CustomerName))
                return Json(new { success = false, message = "UserName is required and it should not contains the whitespace." });

            _context.customers.Add(customer);
            await _context.SaveChangesAsync();

            return Json(new { success = true, Message = "Customer saved", customerId = customer.CustomerId });
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var findCustormer = _context.customers.Find(id); // aani pachhal include nai lage etle use ny thse

            //var findCustormer = _context.customers.Include(p => p.Products).FirstOrDefault(c => c.CustomerId == id);
            var findCustomer = _context.customers.Include(p => p.Products).Where(c => c.CustomerId == id).FirstOrDefault();// 2 mathi gme te use thy ske...

            //customer ni total products remove krva
            //if (findCustomer != null)
            //{
            //    _context.products.RemoveRange(findCustomer.Products);
            //    _context.customers.Remove(findCustomer);
            //    _context.SaveChanges();
            //}

            _context.products.RemoveRange(findCustomer.Products);
            _context.customers.Remove(findCustomer);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            // we have to add this line in edit.cshtml if we use belowed approach and then we have to run foreach on "products" instead of "Product[]" : //--> var products = @Html.Raw(JsonSerializer.Serialize(ViewBag.products));
            
            var findCustomer = _context.customers.FirstOrDefault(c => c.CustomerId == id);
            ViewBag.products = _context.products.Where(p => p.CustomerId == id).Select(p => new
            {
                p.CustomerId,
                p.ProdctId,
                p.ProductName,
                p.ProductQuantity,
                p.ProductPrice,
                p.TotalAmount
            }).ToList();
            return View(findCustomer);
        }

        [HttpPost]
        public async Task<JsonResult> Edit([FromBody]Customer customer)
        {
            if (customer == null)
            {
                return Json(new { success = false, message = "Customer not Found!" });
            }
            if (string.IsNullOrWhiteSpace(customer.CustomerName))
                return Json(new { success = false, message = "UserName is required and it should not contains the whitespace." });

            _context.customers.Update(customer);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Customer Edited!"});
        }


        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] Product product)
        {
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return Json(new { success = true, Message = "Customer Deleted!", CustomerId = product.ProdctId });
        }
    }
}
