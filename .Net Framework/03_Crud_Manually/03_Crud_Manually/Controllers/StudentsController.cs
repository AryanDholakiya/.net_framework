using _03_Crud_Manually.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_Crud_Manually.Controllers
{
    [RoutePrefix("Students")]
    public class StudentsController : Controller
    {
        private string ApiUrl = "https://localhost:7156/api/";
        private HttpClient client = new HttpClient();
        //private readonly ApplicationException _db;
        //public StudentsController(ApplicationException db)
        //{
        //    _db = db;
        //}
        private readonly ApplicationDbContext db = new ApplicationDbContext(); //we can write like this also

        [HttpGet]
        [Route("studentList")]
        public ActionResult Index()
        {
            var token = Session["jwtToken"] as string;

            if (token == null)
            {
                return RedirectToAction("Login");
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var students = db.students.ToList();
            return View(students);
        }

        [HttpGet]
        public JsonResult Search(string search)
        {
            var students = db.students.AsQueryable(); //AsQueryable thi where jevi conditions maari skay.
            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(s => s.FullName.Contains(search) || s.Email.Contains(search));
                //if()20
                //{

                //}
            }
            return Json(students.ToList(), JsonRequestBehavior.AllowGet);
            //ASP.NET MVC(Framework) માં જ્યારે તમે controller માંથી JSON return કરો છો ત્યારે GET request વડે JSON return કરવાની permission by default નહીં આપે. so we have to use the "JsonRequestBehavior.AllowGet".

            //we can also use the [HttpPost]--> then we have to remove the "JsonRequestBehavior.AllowGet" from here here and do change in view's :-> type: 'GET', to POST
        }

        [Route("CreateStudent")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Branch = new List<SelectListItem>()
            {
                new SelectListItem{Text = "Information Technology", Value="Information Technology"},
                new SelectListItem{Text = "Computer Engineering", Value="Computer Engineering"},
                new SelectListItem{Text = "Aeronotical Engineering", Value="Aeronotical Engineering"},
                new SelectListItem{Text = "Mechanical Engineering", Value="Mechanical Engineering"}
            };
            //why we make SelectListItem here and then pass it to view? --> see create view

            return View();
        }

        [Route("CreateStudent")] //Post method ma pn same route aapvu neccessary chhe bcz jyare form submit thse tyare teni pase koi route j nhi hse
        //let suppose aapne nthi aapta route to aa method mate route handle krse convention based routing. hve issue e thse jyare convention based route create thse to te kai "Students/Create" prakarnu hse but aapnu form je route ne submit thyu te route "Students/CreateStudent" nu httu tethi error aavse
        [HttpPost]
        public ActionResult CreateStudent(Student student, HttpPostedFileBase photoFile)
        {
            if (ModelState.IsValid && photoFile.ContentLength > 0)
            {
                //using(var ms = new MemoryStream()) 
                //{
                //    photoFile.InputStream.CopyTo(ms);
                //    student.Photo = ms.ToArray();
                //}
                //using ensures that the object(MemoryStream) is automatically disposed (released from memory) when the code block finishes.
                //Method - 2
                using (var binaryReader = new BinaryReader(photoFile.InputStream))
                {
                    student.Photo = binaryReader.ReadBytes(photoFile.ContentLength);
                }

                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [Route("EditStudent")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Paticular_student = db.students.Find(id);
            if (Paticular_student == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> branches = new List<SelectListItem>()
            {
                new SelectListItem{Text = "Information Technology", Value="Information Technology", Selected = Paticular_student.Branch == "Information Technology"},
                new SelectListItem{Text = "Computer Engineering", Value="Computer Engineering", Selected = Paticular_student.Branch == "Computer Engineering"},
                new SelectListItem{Text = "Aeronotical Engineering", Value="Aeronotical Engineering", Selected = Paticular_student.Branch == "Aeronotical Engineering"},
                new SelectListItem{Text = "Mechanical Engineering", Value="Mechanical Engineering", Selected = Paticular_student.Branch == "Mechanical Engineering"}
            };

            ViewBag.Branch = branches;

            return View(Paticular_student);
        }



        [Route("EditStudent")]
        [HttpPost]
        public ActionResult EditStudent(Student student, HttpPostedFileBase photoFile)
        {
            if (photoFile != null && photoFile.ContentLength > 0)
            {
                using (var ms = new MemoryStream())
                {
                    photoFile.InputStream.CopyTo(ms);
                    student.Photo = ms.ToArray();
                }
            }

           // string selectedBranch = student.Branch;//THIS IS THE NECCESSARY FOR SHOW THE SELECTED ITEM IN DROPDOWN

            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Paticular_student = db.students.Find(id);
            if (Paticular_student == null)
            {
                return HttpNotFound();
            }
            db.students.Remove(Paticular_student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        //---------jwt

        [Route("~/")]
        public ActionResult Root()  // aani jroor khali login page pr url https://localhost:44389/Students/Login btavva levu pdyu bcz by first load prr aavu route aam krya vina nai dekhase
        {
            return RedirectToAction("Login");
        }


        [Route("Login")]
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["jwtToken"] != null)
            {
                return RedirectToAction("Index");
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel login)
        {
            var jsonData = JsonConvert.SerializeObject(login);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ApiUrl + "JWTtoken/Login", content);
            //https://localhost:7156/api/JWTtoken/Login      localhost:7156/api/JWTtoken/Login

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(result);

                string token = data.token;

                Session["jwtToken"] = token;
                return RedirectToAction("Index");
            }
            TempData["error"] = "Invalid userName or Password. Please Register First.";
            return RedirectToAction("Login");
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Register(LoginModel login)
        {
            var JsonData = JsonConvert.SerializeObject(login);
            var content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var sending = await client.PostAsync(ApiUrl + "JWTtoken/Register", content); //'https://localhost:7156/api/JWTtoken/Register

            if (sending.IsSuccessStatusCode)
            {
                TempData["Registered"] = "Registered Successfully!";
            }

            return RedirectToAction("Login");
        }

    }
}