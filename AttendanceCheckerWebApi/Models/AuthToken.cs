using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCheckerWebApi.Models
{
    public class AuthToken
    {
        public string Token { get; set; }
        public DateTime date { get; set; }
        public AuthToken(string token)
        {
            date = DateTime.Now;
            Token = token;
        }
        


    }
}
