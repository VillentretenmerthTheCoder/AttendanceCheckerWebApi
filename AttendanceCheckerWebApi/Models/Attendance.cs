using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCheckerWebApi.Models
{
    public class Attendance
    {
        public int Attendance_id { get; set; }
        public int Lesson_instance_id { get; set; }
        public int Enrollment_id { get; set; }

        public bool Attendance1 { get; set; }
        public bool Attendance2 { get; set; }
        public bool Attendance3 { get; set; }

        public Attendance(int _attendance_id, int _lesson_instance_id, int _enrollment_id, bool _attendance1, bool _attendance2, bool _attendance3)
        {
            Attendance_id = _attendance_id;
            Lesson_instance_id = _lesson_instance_id;
            Enrollment_id = _enrollment_id;
            Attendance1 = _attendance1;
            Attendance2 = _attendance2;
            Attendance3 = _attendance3;
        }

        public Attendance() { }
    }
}
