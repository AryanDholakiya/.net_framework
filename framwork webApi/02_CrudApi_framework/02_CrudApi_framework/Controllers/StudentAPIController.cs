using _02_CrudApi_framework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace _02_CrudApi_framework.Controllers
{
    [RoutePrefix("api/Students")]
    public class StudentAPIController : ApiController
    {
        private readonly StudentContext _db = new StudentContext();

        //public StudentAPIController(StudentContext db) //we can do directly as shown upper side
        //{
        //    _db = db;
        //}


        [HttpGet]
        [Route("StudentList",Name ="AllStudents")]
        [ResponseType(typeof(IEnumerable<StudentsModel>))]
        public IHttpActionResult StudentList()
        {
            var students = _db.students.ToList();
            return Ok (students);
        }


        //{id:int} -> The API URL must contain a value for id.And that value must be an integer.>ex: /api/student/5
        [HttpGet]
        [Route("{id:int}",Name ="GetStudentById")]
        [ResponseType(typeof(StudentsModel))]
        public IHttpActionResult GetById(int id)
        {
            //var find_student = _db.students.Where(s => s.Id == id).FirstOrDefault();
            //var find_student = _db.students.FirstOrDefault(s => s.Id == id);
            var find_student = _db.students.Find(id); // only valid for primary key
            if(find_student == null)
            {
                return BadRequest($"Student with Id:{id} Not available!");
            }
            return Ok(find_student);
        }

        [HttpPost]
        [Route("Create",Name ="CreateStudent")]
        [ResponseType (typeof(StudentsModel))]
        public IHttpActionResult Create([FromBody] StudentsModel student)
        {
            if (ModelState.IsValid)
            {
                _db.students.Add(student);
                _db.SaveChanges();
                return CreatedAtRoute("AllStudents", new { id = student.Id }, student);//AllStudents aa route ma jse data laine.> new { id = student.Id } passes the newly created student's Id to that route, >student is type of data
               //return Ok(student)
            }
            return Ok(student);
        }

        [HttpPut]
        [Route("{id:int}", Name="EditStudent")]
        [ResponseType(typeof(StudentsModel))]
        public IHttpActionResult Edit(int id, [FromBody]StudentsModel student)
        {
            if(ModelState.IsValid)
            {
                var find_Student = _db.students.Find(id);

                if(find_Student == null)
                {
                    return BadRequest();
                }
                //_db.Entry(student).State = EntityState.Modified; //NOTE: aam krvu hoi to find _student remove kro
                find_Student.Name = student.Name;
                find_Student.Branch = student.Branch;
                find_Student.Mobile = student.Mobile;
                _db.SaveChanges();
                return Ok(find_Student);
            }
            return Ok(student);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var find_student = _db.students.Find(id);
            if (find_student == null)
            {
                return NotFound();
            }

            _db.students.Remove(find_student);
            _db.SaveChanges();
            return Ok("Student Record Deleted!");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
