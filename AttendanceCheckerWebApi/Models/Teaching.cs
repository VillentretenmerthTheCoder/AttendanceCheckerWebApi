using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCheckerWebApi.Models
{
    public class Teaching
    {
        public int Teaching_id { get; set; }
        public int Course_id { get; set; }
        public int Teacher_id { get; set; }

        public Teaching(int _teaching_id, int _course_id, int _teacher_id)
        {
            Teaching_id = _teaching_id;
            Course_id = _course_id;
            Teacher_id = _teacher_id;

        }
        public Teaching() { }
    }
}
