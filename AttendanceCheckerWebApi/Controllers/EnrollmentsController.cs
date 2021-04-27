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
        public class EnrollmentsController : ControllerBase
        {
            // GET
            [HttpGet]
            public IEnumerable<Enrollment> Get()
            {
                return EnrollmentsPersistency.Get();
            }


            // GET by ID
            [HttpGet("{id}", Name = "GetEnrollments")]
            public Enrollment Get(string id)
            {
                return EnrollmentsPersistency.Get(id);
            }

            // POST
            [HttpPost]
            public void Post([FromBody] Enrollment value)
            {
                EnrollmentsPersistency.Post(value);
            }

            // PUT
            [HttpPut]
            [Route("{id}")]
            public void Put(string id, [FromBody] Enrollment value)
            {
                EnrollmentsPersistency.Put(EnrollmentsPersistency.Get(id).Enrollment_id.ToString(), value);
            }

            // DELETE
            [HttpDelete]
            [Route("{id}")]
            public void Delete(string id)
            {
                EnrollmentsPersistency.Delete(id);
            }
        }
    
}
