using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCheckerWebApi.Models
{
    public class Course
    {
        public int Course_id { get; set; }
        public string Course_name { get; set; }

        public Course(int _course_id, string _course_name)
        {
            Course_id = _course_id;
            Course_name = _course_name;
        }

        public Course() { }
    }
}
