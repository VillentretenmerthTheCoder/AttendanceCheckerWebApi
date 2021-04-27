using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AttendanceCheckerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return StudentPersistency.Get();
        }


        // GET by ID
        [HttpGet("{id}", Name = "GetStudents")]
        public Student Get(string id)
        {
            return StudentPersistency.Get(id);
        }

        // POST
        [HttpPost]
        public void Post([FromBody] Student value)
        {
            StudentPersistency.Post(value);
        }

        // PUT
        [HttpPut]
        [Route("{id}")]
        public void Put(string id, [FromBody] Student value)
        {
            StudentPersistency.Put(StudentPersistency.Get(id).Student_id.ToString(), value);
        }

        // DELETE
        [HttpDelete]
        [Route("{id}")]
        public void Delete(string id)
        {
            StudentPersistency.Delete(id);
        }
    }
}
