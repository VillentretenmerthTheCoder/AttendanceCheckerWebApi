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
        public class TeachingsController : ControllerBase
        {
            // GET
            [HttpGet]
            public IEnumerable<Teaching> Get()
            {
                return TeachingsPersistency.Get();
            }


            // GET by ID
            [HttpGet("{id}", Name = "GetTeaching")]
            public Teaching Get(string id)
            {
                return TeachingsPersistency.Get(id);
            }

            // POST
            [HttpPost]
            public void Post([FromBody] Teaching value)
            {
                TeachingsPersistency.Post(value);
            }

            // PUT
            [HttpPut]
            [Route("{id}")]
            public void Put(string id, [FromBody] Teaching value)
            {
                TeachingsPersistency.Put(TeachingsPersistency.Get(id).Teaching_id.ToString(), value);
            }

            // DELETE
            [HttpDelete]
            [Route("{id}")]
            public void Delete(string id)
            {
                TeachingsPersistency.Delete(id);
            }
        }
    
}
