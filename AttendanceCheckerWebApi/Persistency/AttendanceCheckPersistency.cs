using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;

namespace AttendanceCheckerWebApi.Persistency
{
    public class AttendanceCheckPersistency
    {
        public const string GET_ALL = "Select * from AttendanceCheck";
        public const string CONNECTION_STRING = @"Data Source=attendancecheckerdbb.database.windows.net;Initial Catalog=AttendanceCheckerDatabase;User ID=attendancechecker;Password=schoolproject_123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Get method that SQL can understand
        public static AttendanceCheck ReadNextElement(SqlDataReader reader)
        {
            AttendanceCheck attendancecheck = new AttendanceCheck(reader.GetInt32(0), reader.GetInt32(1));
            return attendancecheck;
        }

        // Get
        public static IEnumerable<AttendanceCheck> Get()
        {
            List<AttendanceCheck> attendancechecks = new List<AttendanceCheck>();
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
                                attendancechecks.Add(ReadNextElement(reader));
                            }
                        }
                    }
                }

                return attendancechecks;
            }
        }

        // Get a conversation by ID
        public static AttendanceCheck Get(string attendance_id)
        {
            AttendanceCheck attendancecheckReturned = null;
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
                                if (ReadNextElement(reader).AttendanceCheck_id.ToString() == attendance_id)
                                {
                                    attendancecheckReturned = ReadNextElement(reader);
                                }
                            }
                        }
                    }
                }

                return attendancecheckReturned;
            }
        }

        // Post a conversation to the DB
        public static void Post(AttendanceCheck attendanceAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert into AttendanceCheck Values (@Param4)";

                        cmd.Parameters.AddWithValue(parameterName: "@param4", attendanceAdded.Lesson_instance_id);
                        


                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Put (update) a conversation's info in the DB
        public static void Put(string attendancecheck_id, AttendanceCheck attendancecheckAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open && attendancecheckAdded != null)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "UPDATE AttendanceCheck SET Lesson_instance_id = @param3 WHERE AttendanceCheck_id = @param2";

                        cmd.Parameters.AddWithValue(parameterName: "@param2", attendancecheckAdded.AttendanceCheck_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param3", attendancecheckAdded.Lesson_instance_id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Delete a conversation from the DB
        public static void Delete(string attendancecheck_id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM AttendanceCheck WHERE AttendanceCheck_id = @param1";

                        cmd.Parameters.AddWithValue(parameterName: "@param1", attendancecheck_id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}

