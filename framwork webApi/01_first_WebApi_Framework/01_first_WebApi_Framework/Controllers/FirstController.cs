using _01_first_WebApi_Framework.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace _01_first_WebApi_Framework.Controllers
{
    [RoutePrefix("api/First")]
    public class FirstController : ApiController
    {
        private static List<First_framework> _students = new List<First_framework>
        {
           new First_framework{Id=1, Name="Anjali", Branch="Computer science"},
           new First_framework{Id=2, Name="naganjali", Branch="Information Technology"},
           new First_framework{Id=3, Name="Gitanjali", Branch="Information Technology"},
        };

        [HttpGet]
        [Route("AllStudents")]
        public IHttpActionResult Geet()
        {
            return Ok(_students);
        }

        [HttpGet]
        [Route("student/{id}", Name = "StudentById")]
        public IHttpActionResult GetById(int id)
        {
            var student = _students.Find(s => s.Id == id);
            if (student == null)
            {
                return BadRequest();
            }
            return Ok(student);
        }

        [HttpPost]
        [Route("student/create")]
        [ResponseType(typeof(First_framework))] //a no mukie to bhi chale. it just gives information to swagger and other developers like us that , this api will give specified type of data.
        public IHttpActionResult create([FromBody] First_framework model)
        {
            if (ModelState.IsValid)
            {
                model.Id = _students.Max(s => s.Id) + 1;
                _students.Add(model);
                //return Ok(model);
                return CreatedAtRoute("StudentById", new { id = model.Id }, model);
                //CreatedAtRoute e "StudentById" route ma jse aa new id aapse etle e api call thse ane res aapse.
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public IHttpActionResult Edit(int id, [FromBody] First_framework model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var existing = _students.Find(s => s.Id == id);
            existing.Name = model.Name;
            existing.Branch = model.Branch;

            if(existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult delete(int id)
        {
            var existed = _students.Find(s => s.Id == id);
            _students.Remove(existed);

            return Ok();
        }

    }
}
