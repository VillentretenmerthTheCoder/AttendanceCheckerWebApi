using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;

namespace AttendanceCheckerWebApi.Persistency
{
    public class Lesson_instancesPersistency
    {
        public const string GET_ALL = "Select * from Lesson_instance";
        public const string CONNECTION_STRING = @"Data Source=attendancecheckerapidbserver.database.windows.net;Initial Catalog=AttendanceCheckerDatabase;User ID=attendancechecker;Password=schoolproject_123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Get method that SQL can understand
        public static Lesson_instance ReadNextElement(SqlDataReader reader)
        {
            Lesson_instance lesson_instance = new Lesson_instance(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetInt32(3));
            return lesson_instance;
        }

        // Get
        public static IEnumerable<Lesson_instance> Get()
        {
            List<Lesson_instance> lesson_instances = new List<Lesson_instance>();
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
                                lesson_instances.Add(ReadNextElement(reader));
                            }
                        }
                    }
                }

                return lesson_instances;
            }
        }

        // Get a conversation by ID
        public static Lesson_instance Get(string lesson_instance_id)
        {
            Lesson_instance lesson_instanceReturned = null;
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
                                if (ReadNextElement(reader).Lesson_instance_id.ToString() == lesson_instance_id)
                                {
                                    lesson_instanceReturned = ReadNextElement(reader);
                                }
                            }
                        }
                    }
                }

                return lesson_instanceReturned;
            }
        }

        // Post a conversation to the DB
        public static void Post(Lesson_instance lesson_instanceReturned)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert into Lesson_instance Values (@Param3, @Param4, @Param5)";

                        cmd.Parameters.AddWithValue(parameterName: "@param3", lesson_instanceReturned.Teaching_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", lesson_instanceReturned.Lesson_datetime);
                        cmd.Parameters.AddWithValue(parameterName: "@param5", lesson_instanceReturned.class_number);
                 


                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Put (update) a conversation's info in the DB
        public static void Put(string lesson_instance_id, Lesson_instance lesson_instanceReturned)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open && lesson_instanceReturned != null)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "UPDATE Lesson_instance SET Teaching_id = @param3, Lesson_datetime = @param4, class_number=@param5 WHERE Lesson_instance_id = @param2";

                        cmd.Parameters.AddWithValue(parameterName: "@param2", lesson_instanceReturned.Lesson_instance_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param3", lesson_instanceReturned.Teaching_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", lesson_instanceReturned.Lesson_datetime);
                        cmd.Parameters.AddWithValue(parameterName: "@param5", lesson_instanceReturned.class_number);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Delete a conversation from the DB
        public static void Delete(string lesson_instance_id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Lesson_instance WHERE Lesson_isntance_id = @param1";

                        cmd.Parameters.AddWithValue(parameterName: "@param1", lesson_instance_id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}

