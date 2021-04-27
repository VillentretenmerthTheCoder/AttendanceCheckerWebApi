using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;
using AttendanceCheckerWebApi.Persistency;

namespace AttendanceCheckerWebApi.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class TeachersController : ControllerBase
        {
            // GET
            [HttpGet]
            public IEnumerable<Teacher> Get()
            {
                return TeachersPersistency.Get();
            }


            // GET by ID
            [HttpGet("{id}", Name = "GetTeachers")]
            public Teacher Get(string id)
            {
                return TeachersPersistency.Get(id);
            }

            // POST
            [HttpPost]
            public void Post([FromBody] Teacher value)
            {
                TeachersPersistency.Post(value);
            }

            // PUT
            [HttpPut]
            [Route("{id}")]
            public void Put(string id, [FromBody] Teacher value)
            {
                TeachersPersistency.Put(TeachersPersistency.Get(id).Teacher_id.ToString(), value);
            }

            // DELETE
            [HttpDelete]
            [Route("{id}")]
            public void Delete(string id)
            {
                TeachersPersistency.Delete(id);
            }
        }
    
}
