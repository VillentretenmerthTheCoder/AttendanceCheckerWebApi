using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;
using AttendanceCheckerWebApi.Persistency;
using System.Text;

namespace AttendanceCheckerWebApi.Controllers

{

    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceCheckController : ControllerBase
    {
        // GET
        [HttpGet]
        public IEnumerable<AttendanceCheck> Get()
        {
            return AttendanceCheckPersistency.Get();
        }


        // GET by ID
        [HttpGet("{id}", Name = "GetAttendancecheks")]
        public AttendanceCheck Get(string id)
        {
            return AttendanceCheckPersistency.Get(id);
        }

        // POST
        [HttpPost]
        public void Post([FromBody] AttendanceCheck value)
        {
            AttendanceCheckPersistency.Post(value);
        }

        // PUT
        [HttpPut]
        [Route("{id}")]
        public void Put(string id, [FromBody] AttendanceCheck value)
        {
            AttendanceCheckPersistency.Put(AttendanceCheckPersistency.Get(id).AttendanceCheck_id.ToString(), value);
        }

        // DELETE
        [HttpDelete]
        [Route("{id}")]
        public void Delete(string id)
        {
            AttendanceCheckPersistency.Delete(id);
        }

    }
}
