using Invoice_Task_AspNetCoreMVC_.Data;
using Invoice_Task_AspNetCoreMVC_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Task_AspNetCoreMVC_.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly DataContext _userContext;

        public InvoiceController(DataContext UserContext)
        {
            _userContext = UserContext;
        }
        public IActionResult Index()
        {
            //var totalUser = _userContext.users.ToList();
            var totalUser = _userContext.users
                                      .Include(u => u.Products)
                                      .ToList();
            return View(totalUser);
        }
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CreateUser([FromBody] Users user) //here we have to take "Users"
        {
            //if (ModelState.IsValid)
            //{
            //    _userContext.users.Add(user);
            //    _userContext.SaveChanges();
            //    return Json(new { success = true, message = "User saved successfully!" }); // here we have to write "return" first.
            //}
            //return Json(new { success = false, message = "User saved faild!" });


            if (user == null)
                return Json(new { success = false, message = "Customer Not Found!" });

            // server-side validation (basic)
            if (string.IsNullOrWhiteSpace(user.UserName))
                return Json(new { success = false, message = "UserName is required." });

            // EF will insert user and related products if the Products are attached to user.Products
            _userContext.users.Add(user);
            await _userContext.SaveChangesAsync();

            return Json(new { success = true, message = "User saved successfully!", userId = user.UserId });
        }



        public IActionResult Delete(int id)
        {
            var user = _userContext.users.Include(u => u.Products).FirstOrDefault(u => u.UserId == id); ;
            if (user != null)
            {
                _userContext.users.Remove(user);
                _userContext.SaveChanges();
            }

            
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var data = _userContext.users.FirstOrDefault(u => u.UserId == id);
            ViewBag.products = _userContext.products.Where(u => u.CustomerId == id).Select(x => new
            {
                x.PId, //check product is already exist or not
                x.CustomerId,
                x.PPrice,
                x.PName,
                x.PQuantity,
                x.Total
            }).ToList();
            return View(data);
        }

        [HttpPost]
        public JsonResult Edit([FromBody] Users user)
        {

            _userContext.users.Update(user);
             _userContext.SaveChanges();

            return Json(new { success = true, message = "User saved successfully!", userId = user.UserId });
        }

        [HttpPost]
        public JsonResult DeleteProduct([FromBody] Product product)
        {

            _userContext.products.Remove(product);
            _userContext.SaveChanges();

            return Json(new { success = true, message = "User saved successfully!", userId = product.PId });
        }

    }
}
