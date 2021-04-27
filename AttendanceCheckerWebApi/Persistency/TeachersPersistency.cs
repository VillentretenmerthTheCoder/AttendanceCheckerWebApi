using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;

namespace AttendanceCheckerWebApi.Persistency
{
    public class TeachersPersistency
    {
        public const string GET_ALL = "Select * from Teacher";
        public const string CONNECTION_STRING = @"Data Source=attendancecheckerapidbserver.database.windows.net;Initial Catalog=AttendanceCheckerDatabase;User ID=attendancechecker;Password=schoolproject_123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Get method that SQL can understand
        public static Teacher ReadNextElement(SqlDataReader reader)
        {
            Teacher teacher = new Teacher(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
            return teacher;
        }

        // Get
        public static IEnumerable<Teacher> Get()
        {
            List<Teacher> teachers = new List<Teacher>();
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
                                teachers.Add(ReadNextElement(reader));
                            }
                        }
                    }
                }

                return teachers;
            }
        }

        // Get a conversation by ID
        public static Teacher Get(string teacher_id)
        {
            Teacher teacherReturned = null;
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
                                if (ReadNextElement(reader).Teacher_id.ToString() == teacher_id)
                                {
                                    teacherReturned = ReadNextElement(reader);
                                }
                            }
                        }
                    }
                }

                return teacherReturned;
            }
        }

        // Post a conversation to the DB
        public static void Post(Teacher teacherAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert into Teacher Values (@Param3, @Param4, @Param5, @Param6, @Param7)";

                        cmd.Parameters.AddWithValue(parameterName: "@param3", teacherAdded.Name);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", teacherAdded.Surname);
                        cmd.Parameters.AddWithValue(parameterName: "@param5", teacherAdded.School_email);
                        cmd.Parameters.AddWithValue(parameterName: "@param6", teacherAdded.Password);
                        cmd.Parameters.AddWithValue(parameterName: "@param7", teacherAdded.Phone_number);


                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Put (update) a conversation's info in the DB
        public static void Put(string teacher_id, Teacher teacherAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open && teacherAdded != null)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "UPDATE Teacher SET Name = @param3, Surname = @param4, School_email=@param5, Password=@param6, Phone_number=@param7 WHERE Teacher_id = @param2";

                        cmd.Parameters.AddWithValue(parameterName: "@param2", teacherAdded.Teacher_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param3", teacherAdded.Name);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", teacherAdded.Surname);
                        cmd.Parameters.AddWithValue(parameterName: "@param5", teacherAdded.School_email);
                        cmd.Parameters.AddWithValue(parameterName: "@param6", teacherAdded.Password);
                        cmd.Parameters.AddWithValue(parameterName: "@param7", teacherAdded.Phone_number);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Delete a conversation from the DB
        public static void Delete(string teacher_id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Teacher WHERE Teacher_id = @param1";

                        cmd.Parameters.AddWithValue(parameterName: "@param1", teacher_id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}

