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
        public class Lesson_instacesController : ControllerBase
        {
            // GET
            [HttpGet]
            public IEnumerable<Lesson_instance> Get()
            {
                return Lesson_instancesPersistency.Get();
            }


            // GET by ID
            [HttpGet("{id}", Name = "GetLesson_instances")]
            public Lesson_instance Get(string id)
            {
                return Lesson_instancesPersistency.Get(id);
            }

            // POST
            [HttpPost]
            public void Post([FromBody] Lesson_instance value)
            {
                Lesson_instancesPersistency.Post(value);
            }

            // PUT
            [HttpPut]
            [Route("{id}")]
            public void Put(string id, [FromBody] Lesson_instance value)
            {
                Lesson_instancesPersistency.Put(Lesson_instancesPersistency.Get(id).Lesson_instance_id.ToString(), value);
            }

            // DELETE
            [HttpDelete]
            [Route("{id}")]
            public void Delete(string id)
            {
                Lesson_instancesPersistency.Delete(id);
            }
        }
    
}
