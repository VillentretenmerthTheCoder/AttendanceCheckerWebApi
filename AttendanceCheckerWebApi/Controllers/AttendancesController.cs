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

        [HttpGet]
        [Route("gettoken")]
        public AuthToken GetToken()
        {

            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;
            for (int i = 0; i < 6; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }


            AuthToken token = new AuthToken(str_build.ToString());
            TokenHandler.addToken(token);
            return token;
        }
        [HttpPost]
        [Route("authtoken")]
        public Boolean authtoken([FromBody] AuthToken t)
        {
            
            return TokenHandler.authTokens.Exists(x => x.Token == t.Token);
        }

    }
}
