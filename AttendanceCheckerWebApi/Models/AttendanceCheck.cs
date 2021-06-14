using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCheckerWebApi.Models
{
    public class AttendanceCheck
    {
        public int AttendanceCheck_id { get; set; }
        public int Lesson_instance_id { get; set; }

        public AttendanceCheck(int _attendancecheck_id, int _lesson_instance)
        {
            AttendanceCheck_id = _attendancecheck_id;
            Lesson_instance_id = _lesson_instance;
        }

        public AttendanceCheck() { }
    }
}
