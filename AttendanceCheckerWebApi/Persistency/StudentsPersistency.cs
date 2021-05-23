using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;


namespace AttendanceCheckerWebApi
{
    public static class StudentPersistency
    {
       
        
        
        public const string GET_ALL = "Select * from Student";
        public const string CONNECTION_STRING = @"Data Source=attendancecheckerdbb.database.windows.net;Initial Catalog=AttendanceCheckerDatabase;User ID=attendancechecker;Password=schoolproject_123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Get method that SQL can understand
        public static Student ReadNextElement(SqlDataReader reader)
        {
            Student student = new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
            return student;
        }

        // Get
        public static IEnumerable<Student> Get()
        {
            List<Student> conversations = new List<Student>();
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
                                conversations.Add(ReadNextElement(reader));
                            }
                        }
                    }
                }

                return conversations;
            }
        }

        // Get a conversation by ID
        public static Student Get(string student_id)
        {
            Student studentReturned = null;
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
                                if (ReadNextElement(reader).Student_id.ToString() == student_id)
                                {
                                    studentReturned = ReadNextElement(reader);
                                }
                            }
                        }
                    }
                }

                return studentReturned;
            }
        }

        // Post a conversation to the DB
        public static void Post(Student studentAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert into Student Values (@Param3, @Param4, @Param5, @Param6, @Param7)";
               
                        cmd.Parameters.AddWithValue(parameterName: "@param3", studentAdded.Name);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", studentAdded.Surname);
                        cmd.Parameters.AddWithValue(parameterName: "@param5", studentAdded.School_email);
                        cmd.Parameters.AddWithValue(parameterName: "@param6", studentAdded.Password);
                        cmd.Parameters.AddWithValue(parameterName: "@param7", studentAdded.Phone_number);


                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Put (update) a conversation's info in the DB
        public static void Put(string student_id, Student studentAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open && studentAdded != null)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "UPDATE Student SET Name = @param3, Surname = @param4, School_email=@param5, Password=@param6, Phone_number=@param7 WHERE Student_id = @param2";

                        cmd.Parameters.AddWithValue(parameterName: "@param2", studentAdded.Student_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param3", studentAdded.Name);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", studentAdded.Surname);
                        cmd.Parameters.AddWithValue(parameterName: "@param5", studentAdded.School_email);
                        cmd.Parameters.AddWithValue(parameterName: "@param6", studentAdded.Password);
                        cmd.Parameters.AddWithValue(parameterName: "@param7", studentAdded.Phone_number);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Delete a conversation from the DB
        public static void Delete(string student_id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Student WHERE Student_id = @param1";

                        cmd.Parameters.AddWithValue(parameterName: "@param1", student_id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}