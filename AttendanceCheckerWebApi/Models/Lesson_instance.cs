using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceCheckerWebApi.Models
{
    public class Lesson_instance
    {
        public int Lesson_instance_id { get; set; }
        public int Teaching_id { get; set; }
        public DateTime Lesson_datetime { get; set; }
        public int class_number { get; set; }


        public Lesson_instance(int _lesson_instance_id, int _teaching_id, DateTime _lesson_datetime, int _class_number)
        {
            Lesson_instance_id = _lesson_instance_id;
            Teaching_id = _teaching_id;
            Lesson_datetime = _lesson_datetime;
            class_number = _class_number;
        }

        public Lesson_instance() { }
    }
}
