using first_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace first_Core_MVC.Controllers
{
    public class ABCController : Controller
    {
        List<User> listusers = new List<User>()
            {
                new User{ Id = 1, Name = "abcd", Email = "abcd@gmail.com", Password = "abcd123" },
                new User{ Id = 2, Name = "efgh", Email = "efh@gmail.com", Password = "efh321" }
            };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult usrlist(User? user, int? id)
        {
            if (user.Name != null)
            {
                var finduser = listusers.Find(x => x.Id == id);
                if (finduser != null)
                {
                    finduser.Name = user.Name;
                    finduser.Email = user.Email;
                    finduser.Password = user.Password;
                }
                else
                {
                    listusers.Add(user);
                }
            }
            if (id != 0)
            {
                var finduser = listusers.Find(x => x.Id == id);
                listusers.Remove(finduser);
            }
            return View(listusers);
        }
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(User user)
        {
            return RedirectToAction("usrlist", new { User = user, Id = 0 });
        }
        public IActionResult edit(int id)
        {
            var finduser = listusers.Find(x => x.Id == id);
            return View(finduser);
        }

        [HttpPost]
        public IActionResult edit(User user)
        {
            return RedirectToAction("usrlist", new { User = user, Id = user.Id });
        }
        public IActionResult delete(int id)
        {

            return RedirectToAction("usrlist", new { User = Empty, Id = id });
        }


    }
}
