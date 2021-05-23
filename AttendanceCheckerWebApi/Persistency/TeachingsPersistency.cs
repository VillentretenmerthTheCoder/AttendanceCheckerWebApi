using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;

namespace AttendanceCheckerWebApi.Persistency
{
    public class TeachingsPersistency
    {
        public const string GET_ALL = "Select * from Teaching";
        public const string CONNECTION_STRING = @"Data Source=attendancecheckerdbb.database.windows.net;Initial Catalog=AttendanceCheckerDatabase;User ID=attendancechecker;Password=schoolproject_123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Get method that SQL can understand
        public static Teaching ReadNextElement(SqlDataReader reader)
        {
            Teaching teaching = new Teaching(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
            return teaching;
        }

        // Get
        public static IEnumerable<Teaching> Get()
        {
            List<Teaching> teachings = new List<Teaching>();
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
                                teachings.Add(ReadNextElement(reader));
                            }
                        }
                    }
                }

                return teachings;
            }
        }

        // Get a conversation by ID
        public static Teaching Get(string teaching_id)
        {
            Teaching teachingReturned = null;
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
                                if (ReadNextElement(reader).Teaching_id.ToString() == teaching_id)
                                {
                                    teachingReturned = ReadNextElement(reader);
                                }
                            }
                        }
                    }
                }

                return teachingReturned;
            }
        }

        // Post a conversation to the DB
        public static void Post(Teaching teachingReturned)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert into Teaching Values (@Param3, @Param4)";

                        cmd.Parameters.AddWithValue(parameterName: "@param3", teachingReturned.Course_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", teachingReturned.Teacher_id);


                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Put (update) a conversation's info in the DB
        public static void Put(string teaching_id, Teaching teachingReturned)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open && teachingReturned != null)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "UPDATE Teaching SET Course_id = @param3, Teacher_id = @param4 WHERE Teaching_id = @param2";

                        cmd.Parameters.AddWithValue(parameterName: "@param2", teachingReturned.Teaching_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param3", teachingReturned.Course_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", teachingReturned.Teacher_id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Delete a conversation from the DB
        public static void Delete(string teaching_id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Teaching WHERE Teaching_id = @param1";

                        cmd.Parameters.AddWithValue(parameterName: "@param1", teaching_id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}

