using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;

namespace AttendanceCheckerWebApi.Persistency
{
    public class EnrollmentsPersistency
    {
        public const string GET_ALL = "Select * from Enrollment";
        public const string CONNECTION_STRING = @"Data Source=attendancecheckerapidbserver.database.windows.net;Initial Catalog=AttendanceCheckerDatabase;User ID=attendancechecker;Password=schoolproject_123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Get method that SQL can understand
        public static Enrollment ReadNextElement(SqlDataReader reader)
        {
            Enrollment enrollment = new Enrollment(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
            return enrollment;
        }

        // Get
        public static IEnumerable<Enrollment> Get()
        {
            List<Enrollment> enrollments = new List<Enrollment>();
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
                                enrollments.Add(ReadNextElement(reader));
                            }
                        }
                    }
                }

                return enrollments;
            }
        }

        // Get a conversation by ID
        public static Enrollment Get(string enrollment_id)
        {
            Enrollment enrollmentReturned = null;
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
                                if (ReadNextElement(reader).Enrollment_id.ToString() == enrollment_id)
                                {
                                    enrollmentReturned = ReadNextElement(reader);
                                }
                            }
                        }
                    }
                }

                return enrollmentReturned;
            }
        }

        // Post a conversation to the DB
        public static void Post(Enrollment enrollmentAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert into Enrollment Values (@Param3, @Param4)";

                        cmd.Parameters.AddWithValue(parameterName: "@param3", enrollmentAdded.Student_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", enrollmentAdded.Course_id);


                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Put (update) a conversation's info in the DB
        public static void Put(string enrollment_id, Enrollment enrollmentAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open && enrollmentAdded != null)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "UPDATE Enrollment SET Student_id = @param3, Course_id = @param4 WHERE Enrollment_id = @param2";

                        cmd.Parameters.AddWithValue(parameterName: "@param2", enrollmentAdded.Enrollment_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param3", enrollmentAdded.Student_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", enrollmentAdded.Course_id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Delete a conversation from the DB
        public static void Delete(string enrollment_id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Enrollment WHERE Enrollment_id = @param1";

                        cmd.Parameters.AddWithValue(parameterName: "@param1", enrollment_id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
} 

