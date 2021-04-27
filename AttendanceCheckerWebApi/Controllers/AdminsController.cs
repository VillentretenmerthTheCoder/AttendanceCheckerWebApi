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
        public class AdminsController : ControllerBase
        {
            // GET
            [HttpGet]
            public IEnumerable<Admin> Get()
            {
                return AdminsPersistency.Get();
            }


            // GET by ID
            [HttpGet("{id}", Name = "GetAdmins")]
            public Admin Get(string id)
            {
                return AdminsPersistency.Get(id);
            }

            // POST
            [HttpPost]
            public void Post([FromBody] Admin value)
            {
                AdminsPersistency.Post(value);
            }

            // PUT
            [HttpPut]
            [Route("{id}")]
            public void Put(string id, [FromBody] Admin value)
            {
                AdminsPersistency.Put(AdminsPersistency.Get(id).Admin_id.ToString(), value);
            }

            // DELETE
            [HttpDelete]
            [Route("{id}")]
            public void Delete(string id)
            {
                AdminsPersistency.Delete(id);
            }

        }
}
