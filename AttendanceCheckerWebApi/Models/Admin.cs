using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCheckerWebApi.Models
{
    public class Admin
    {
        public int Admin_id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Admin(int _admin_id, string _login, string _password)
        {
            Admin_id = _admin_id;
            Login = _login;
            Password = _password;
        }

        public Admin() { }
    }
}
