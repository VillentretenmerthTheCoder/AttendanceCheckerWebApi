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
        public class CoursesController : ControllerBase
        {
            // GET
            [HttpGet]
            public IEnumerable<Course> Get()
            {
                return CoursesPersistency.Get();
            }


            // GET by ID
            [HttpGet("{id}", Name = "GetCourses")]
            public Course Get(string id)
            {
                return CoursesPersistency.Get(id);
            }

            // POST
            [HttpPost]
            public void Post([FromBody] Course value)
            {
                CoursesPersistency.Post(value);
            }

            // PUT
            [HttpPut]
            [Route("{id}")]
            public void Put(string id, [FromBody] Course value)
            {
                CoursesPersistency.Put(CoursesPersistency.Get(id).Course_id.ToString(), value);
            }

            // DELETE
            [HttpDelete]
            [Route("{id}")]
            public void Delete(string id)
            {
                CoursesPersistency.Delete(id);
            }
        }
    
}
