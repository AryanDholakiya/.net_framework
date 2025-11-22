using _01_MyFirstAspDotNetCoreMvc_Project.Models;
using Microsoft.AspNetCore.Mvc;
namespace _01_MyFirstAspDotNetCoreMvc_Project.Controllers
{
    public class StudentDataController : Controller
    {
        List<Student> StudentList = new List<Student>()
        {
            new Student{StudentName = "Student1", StudentRollNo = 1, StudentEmail = "student1@gmail.com"},
            new Student{StudentName = "student2", StudentRollNo = 2, StudentEmail = "student2@gmail.com"}
        };

        //public IActionResult Index()  //aa method static na hoi ske, overloaded no hovi joie, public j hoy.
        //{
        //    return View();
        //}

        //show the list students
        public IActionResult ListStudent(Student? student)  
        {
            if (student != null)
            {
                StudentList.Add(student);
            }
            return View(StudentList);
        }




        //create new user
        public IActionResult CreateNewStudent()
        {
            return View();
        }

        //create new user
        [HttpPost]
        public IActionResult CreateNewStudent(Student student)
        {
           
            return RedirectToAction("ListStudent", student);
        }


        //Edit 
        //public IActionResult Edit(int rollNo)
        //{
        //    var Student = StudentList.Find(s => s.StudentRollNo == rollNo);
        //    return View(Student);
        //}
    }
}
