using _02_CrudApi_Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _02_CrudApi_Frontend.Controllers
{
    public class StudentsController : Controller
    {
        private readonly string ApiUrl = "https://localhost:44317/api/Students/";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<ActionResult> AllStudents()
        {
            List<Student> students = new List<Student>();
            var res = await client.GetAsync(ApiUrl + "StudentList");

            if(res.IsSuccessStatusCode)
            {
                string result = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                students = data;  //data.ToList();
            }
            return View(students);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Student student)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            var res = await client.PostAsync(ApiUrl + "Create",content);

            if (res.IsSuccessStatusCode)
            {
                var result = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject(result);
                return RedirectToAction("AllStudents");
            }
            return View(student);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var res = await client.GetAsync(ApiUrl + $"{id}");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Student>(data);

                if(result != null)
                {
                    return View(result);
                }
            }
            return HttpNotFound("Record not found!");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id,Student student)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            var response = await client.PutAsync(ApiUrl + $"{id}", content);

            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Student>(data);

                return RedirectToAction("AllStudents");
            }

            return HttpNotFound();
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id,Student student)
        {
            var response = await client.DeleteAsync(ApiUrl + $"{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AllStudents");
            }
            return HttpNotFound();
        }
    }
}