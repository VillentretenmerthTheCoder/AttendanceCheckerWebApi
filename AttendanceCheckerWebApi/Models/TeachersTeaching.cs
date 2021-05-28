using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCheckerWebApi.Models
{
    public class TeachersTeaching
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Course_id { get; set; }
        public int Teacher_id { get; set; }
        public string Course_name { get; set; }
        public int Teaching_id { get; set; }

        public TeachersTeaching(string name, string surname, int course_id, int teacher_id, string course_name, int teaching_id)
        {
            Name = name;
            Surname = surname;
            Course_id = course_id;
            Teacher_id = teacher_id;
            Course_name = course_name;
            Teaching_id = teaching_id;
        }

        public TeachersTeaching() { }
    }
}
