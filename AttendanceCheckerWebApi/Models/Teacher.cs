using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCheckerWebApi.Models
{
    public class Teacher
    {
        public int Teacher_id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string School_email { get; set; }
        public string Password { get; set; }
        public string Phone_number { get; set; }


        public Teacher(int _teacher_id, string _name, string _surname, string _school_email, string _password, string _phone_number)
        {
            Teacher_id = _teacher_id;
            Name = _name;
            Surname = _surname;
            School_email = _school_email;
            Password = _password;
            Phone_number = _phone_number;
        }

        public Teacher() { }
    }
}
