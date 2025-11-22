using _02_CRUDFrontend_using_WebAppi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Text;
using System.Text.Json.Serialization;

namespace _02_CRUDFrontend_using_WebAppi.Controllers
{
    public class StudentController : Controller
    {
        private string ApiURL = "https://localhost:7006/api/StudentApi";
        private HttpClient client = new HttpClient();


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Student> students = new List<Student>();

            // API ના GetStudents એન્ડપોઇન્ટ પર વિનંતી
            HttpResponseMessage response = await client.GetAsync(ApiURL + "/AllStudents"); //client.GetAsync(ApiURL) sends a GET request to the given API URL.

            if (response.IsSuccessStatusCode) // jo response Ok(200) aave to 
            {
                string result = await response.Content.ReadAsStringAsync(); //body ne string form ma read krse and ek j variable ma store krse
                var data = JsonConvert.DeserializeObject<List<Student>>(result); // we have to add the nugetPackage for jsonconvert //DeserializeObject means convert the json data into the raw text or in string format

                //ReadAsStringAsync() એ ફક્ત તે ટેક્સ્ટ ને string તરીકે વાંચે છે.JSON પોતે string જ હોય છે.કારણ કે API થી data text માં આવે છે.C# માં object તરીકે ઉપયોગ કરવા, પહલા string લેવી પડે પછી object માં convert(deserialize) કરવું પડે

                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }






        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            string studentData = JsonConvert.SerializeObject(student); //convert the raw data into the json format
            StringContent content = new StringContent(studentData, Encoding.UTF8, "application/json");
            //StringContent is used to send data in the HTTP request body
            HttpResponseMessage response = await client.PostAsync(ApiURL + "/Add_Student", content); //note the difference with the client.GetAsync

            if(response.IsSuccessStatusCode)
            {
                TempData["insertMessage"] = "Student Added Successfully!";
                return RedirectToAction("Index");
            }

            return BadRequest("Something went wrong!"); 
        }





        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync(ApiURL + "/student/" + id);
            if (response.IsSuccessStatusCode)
            {
                string resultOfresponse = await response.Content.ReadAsStringAsync();
                var responsInstring = JsonConvert.DeserializeObject<Student>(resultOfresponse);
                //<Student> means aapne data ne kya type ma convert krva 6 te

                if (responsInstring != null)
                {
                    return View(responsInstring);
                }
            }

            return NotFound("something went wrong!");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            string EditedData = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(EditedData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(ApiURL + "/Edit_Student/" + student.grNumber, content);//NOTE: PutAsyc

            if(response.IsSuccessStatusCode)
            {
                TempData["UpdateMessage"] = "Student Updated Successfully!";
                return RedirectToAction("index");
            }

            return View(student);
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(ApiURL + "/DeleteStudent/" + id);

            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteMessage"] = "Record Deleted Successfully!";
                return RedirectToAction("index");
            }

            return NotFound("something went wrong!");
        }



    }
}
