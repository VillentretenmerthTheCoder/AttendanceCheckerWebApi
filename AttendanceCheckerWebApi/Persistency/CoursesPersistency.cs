using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;

namespace AttendanceCheckerWebApi.Persistency
{
    public class CoursesPersistency
    {
        public const string GET_ALL = "Select * from Course";
        public const string CONNECTION_STRING = @"Data Source=attendancecheckerdbb.database.windows.net;Initial Catalog=AttendanceCheckerDatabase;User ID=attendancechecker;Password=schoolproject_123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Get method that SQL can understand
        public static Course ReadNextElement(SqlDataReader reader)
        {
            Course coureses = new Course(reader.GetInt32(0), reader.GetString(1));
            return coureses;
        }

        public static TeachersTeaching ReadNextTeacherTeachings(SqlDataReader reader)
        {
            TeachersTeaching teacherteachings = new TeachersTeaching(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5));
            return teacherteachings;
        }

        // Get
        public static IEnumerable<Course> Get()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GET_ALL;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                courses.Add(ReadNextElement(reader));
                            }
                        }
                    }
                }

                return courses;
            }
        }

        // Get a conversation by ID
        public static Course Get(string course_id)
        {
            Course courseReturned = null;
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GET_ALL;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (ReadNextElement(reader).Course_id.ToString() == course_id)
                                {
                                    courseReturned = ReadNextElement(reader);
                                }
                            }
                        }
                    }
                }

                return courseReturned;
            }
        }

        // Post a conversation to the DB
        public static void Post(Course courseReturned)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert into Course Values (@Param3)";

                        cmd.Parameters.AddWithValue(parameterName: "@param3", courseReturned.Course_name);


                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Put (update) a conversation's info in the DB
        public static void Put(string course_id, Course courseAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open && courseAdded != null)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "UPDATE Course SET Course_name = @param3 WHERE Course_id = @param2";

                        cmd.Parameters.AddWithValue(parameterName: "@param2", courseAdded.Course_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param3", courseAdded.Course_name);


                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Delete a conversation from the DB
        public static void Delete(string course_id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Course WHERE Course_id = @param1";

                        cmd.Parameters.AddWithValue(parameterName: "@param1", course_id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        //Teacher and Teachings join table
        public static IEnumerable<TeachersTeaching> TeacherTeachings()
        {

            List<TeachersTeaching> teachersReturned = new List<TeachersTeaching>();
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if(conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Teacher.Name, Teacher.Surname, Teaching.Course_id, Teaching.Teacher_id, Course.Course_name, Teaching.Teaching_id FROM Teacher JOIN Teaching ON Teacher.Teacher_id = Teaching.Teacher_id JOIN Course ON Course.Course_id = Teaching.Course_id";

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                teachersReturned.Add(ReadNextTeacherTeachings(reader));
                            }
                        }
                    }
                }
            }

            return teachersReturned;
        }

    }
}

