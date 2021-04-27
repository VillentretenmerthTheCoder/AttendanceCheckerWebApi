using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCheckerWebApi.Models
{
    public class Enrollment
    {
        public int Enrollment_id { get; set; }
        public int Student_id { get; set; }
        public int Course_id { get; set; }

        public Enrollment(int _enrollment_id, int _student_id, int _course_id)
        {
            Enrollment_id = _enrollment_id;
            Student_id = _student_id;
            Course_id = _course_id;
        }

        public Enrollment() { }
    }
}
