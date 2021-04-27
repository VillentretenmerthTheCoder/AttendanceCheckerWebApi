using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCheckerWebApi.Models
{
    public class Student
    {
        public int Student_id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string School_email { get; set; }
        public string Password { get; set; }
        public string Phone_number { get; set; }

        public Student(int _student_id, string _name, string _surname, string _school_email, string _password, string _phone_number)
        {
            Student_id = _student_id;
            Name = _name;
            Surname = _surname;
            School_email = _school_email;
            Password = _password;
            Phone_number = _phone_number;
        }

        public Student() {}
    }
}
