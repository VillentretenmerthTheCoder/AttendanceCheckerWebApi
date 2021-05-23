using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;

namespace AttendanceCheckerWebApi.Persistency
{
    public class AttendancesPersistency
    {
        public const string GET_ALL = "Select * from Attendance";
        public const string CONNECTION_STRING = @"Data Source=attendancecheckerdbb.database.windows.net;Initial Catalog=AttendanceCheckerDatabase;User ID=attendancechecker;Password=schoolproject_123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Get method that SQL can understand
        public static Attendance ReadNextElement(SqlDataReader reader)
        {
            Attendance attendance = new Attendance(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetBoolean(3), reader.GetBoolean(4), reader.GetBoolean(5));
            return attendance;
        }

        // Get
        public static IEnumerable<Attendance> Get()
        {
            List<Attendance> attendances = new List<Attendance>();
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
                                attendances.Add(ReadNextElement(reader));
                            }
                        }
                    }
                }

                return attendances;
            }
        }

        // Get a conversation by ID
        public static Attendance Get(string attendance_id)
        {
            Attendance attendanceReturned = null;
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
                                if (ReadNextElement(reader).Attendance_id.ToString() == attendance_id)
                                {
                                    attendanceReturned = ReadNextElement(reader);
                                }
                            }
                        }
                    }
                }

                return attendanceReturned;
            }
        }

        // Post a conversation to the DB
        public static void Post(Attendance attendanceAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert into Attendance Values (@Param3, @Param4, @Param5, @Param6, @Param7)";

                        cmd.Parameters.AddWithValue(parameterName: "@param3", attendanceAdded.Lesson_instance_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", attendanceAdded.Enrollment_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param5", attendanceAdded.Attendance1);
                        cmd.Parameters.AddWithValue(parameterName: "@param6", attendanceAdded.Attendance2);
                        cmd.Parameters.AddWithValue(parameterName: "@param7", attendanceAdded.Attendance3);


                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Put (update) a conversation's info in the DB
        public static void Put(string attendance_id, Attendance attendanceAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open && attendanceAdded != null)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "UPDATE Attendance SET Name = @param3, Surname = @param4, School_email=@param5, Password=@param6, Phone_number=@param7 WHERE Attendance_id = @param2";

                        cmd.Parameters.AddWithValue(parameterName: "@param2", attendanceAdded.Attendance_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param3", attendanceAdded.Lesson_instance_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", attendanceAdded.Enrollment_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param5", attendanceAdded.Attendance1);
                        cmd.Parameters.AddWithValue(parameterName: "@param6", attendanceAdded.Attendance2);
                        cmd.Parameters.AddWithValue(parameterName: "@param7", attendanceAdded.Attendance3);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Delete a conversation from the DB
        public static void Delete(string attendance_id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Attendance WHERE Attendance_id = @param1";

                        cmd.Parameters.AddWithValue(parameterName: "@param1", attendance_id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}

