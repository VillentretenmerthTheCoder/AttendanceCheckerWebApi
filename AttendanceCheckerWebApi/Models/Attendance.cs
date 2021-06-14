using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCheckerWebApi.Models
{
    public class Attendance
    {
        public int Attendance_id { get; set; }
        public int Enrollment_id { get; set; }
        public int AttendanceCheck_id { get; set; }

        public Attendance(int _attendance_id, int _enrollment_id,  int _attendancecheck_id)
        {
            Attendance_id = _attendance_id;
            Enrollment_id = _enrollment_id;
            AttendanceCheck_id = _attendancecheck_id;
        }

        public Attendance() { }
    }
}
