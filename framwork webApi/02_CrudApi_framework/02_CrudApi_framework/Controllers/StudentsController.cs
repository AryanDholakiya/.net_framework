//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Description;
//using _02_CrudApi_framework.Models;

//namespace _02_CrudApi_framework.Controllers
//{
//    public class StudentsController : ApiController
//    {
//        private StudentContext db = new StudentContext();

//        // GET: api/Students
//        public IQueryable<StudentsModel> Getstudents()
//        {
//            return db.students;
//        }

//        // GET: api/Students/5
//        [ResponseType(typeof(StudentsModel))]
//        public IHttpActionResult GetStudentsModel(int id)
//        {
//            StudentsModel studentsModel = db.students.Find(id);
//            if (studentsModel == null)
//            {
//                return NotFound();
//            }

//            return Ok(studentsModel);
//        }

//        // PUT: api/Students/5
//        [ResponseType(typeof(void))]
//        public IHttpActionResult PutStudentsModel(int id, StudentsModel studentsModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != studentsModel.Id)
//            {
//                return BadRequest();
//            }

//            db.Entry(studentsModel).State = EntityState.Modified;

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!StudentsModelExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/Students
//        [ResponseType(typeof(StudentsModel))]
//        public IHttpActionResult PostStudentsModel(StudentsModel studentsModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.students.Add(studentsModel);
//            db.SaveChanges();

//            return CreatedAtRoute("DefaultApi", new { id = studentsModel.Id }, studentsModel);
//        }

//        // DELETE: api/Students/5
//        [ResponseType(typeof(StudentsModel))]
//        public IHttpActionResult DeleteStudentsModel(int id)
//        {
//            StudentsModel studentsModel = db.students.Find(id);
//            if (studentsModel == null)
//            {
//                return NotFound();
//            }

//            db.students.Remove(studentsModel);
//            db.SaveChanges();

//            return Ok(studentsModel);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool StudentsModelExists(int id)
//        {
//            return db.students.Count(e => e.Id == id) > 0;
//        }
//    }
//}