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
        public class AttendanceController : ControllerBase
        {
            // GET
            [HttpGet]
            public IEnumerable<Attendance> Get()
            {
                return AttendancesPersistency.Get();
            }


            // GET by ID
            [HttpGet("{id}", Name = "GetAttendances")]
            public Attendance Get(string id)
            {
                return AttendancesPersistency.Get(id);
            }

            // POST
            [HttpPost]
            public void Post([FromBody] Attendance value)
            {
                AttendancesPersistency.Post(value);
            }

            // PUT
            [HttpPut]
            [Route("{id}")]
            public void Put(string id, [FromBody] Attendance value)
            {
                AttendancesPersistency.Put(AttendancesPersistency.Get(id).Attendance_id.ToString(), value);
            }

            // DELETE
            [HttpDelete]
            [Route("{id}")]
            public void Delete(string id)
            {
                AttendancesPersistency.Delete(id);
            }
        
    }
}
