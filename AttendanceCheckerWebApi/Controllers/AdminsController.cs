using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;
using AttendanceCheckerWebApi.Persistency;
using System.Net;

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
            // login
            [HttpPost]
        [Route("Login")]
        public ActionResult<UserSession> login([FromBody] Login creds)
            {
            UserSession session = new UserSession();
             Admin a = AdminsPersistency.Auth(creds.username, creds.password);
                if (a!=null) {
                session.ID = a.Admin_id;
                session.role = "Admin";
                
            }
            Teacher t = TeachersPersistency.Auth(creds.username, creds.password);
            if (t != null)
            {
                session.ID = t.Teacher_id;
                session.role = "Teacher";

            }
            Student s = StudentPersistency.Auth(creds.username, creds.password);
            if (s != null)
            {
                session.ID = s.Student_id;
                session.role = "Student";

            }
            if (session.role == null) {
                return Unauthorized();
            }
                
            return session;
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
