using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCheckerWebApi.Models;

namespace AttendanceCheckerWebApi.Persistency
{
    public class AdminsPersistency
    {
        public const string GET_ALL = "Select * from Admin";
        public const string CONNECTION_STRING = @"Data Source=attendancecheckerdbb.database.windows.net;Initial Catalog=AttendanceCheckerDatabase;User ID=attendancechecker;Password=schoolproject_123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Get method that SQL can understand
        public static Admin ReadNextElement(SqlDataReader reader)
        {
            Admin admin = new Admin(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            return admin;
        }

        // Get
        public static IEnumerable<Admin> Get()
        {
            List<Admin> admins = new List<Admin>();
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
                                admins.Add(ReadNextElement(reader));
                            }
                        }
                    }
                }

                return admins;
            }
        }

        // Get a conversation by ID
        public static Admin Get(string admin_id)
        {
            Admin adminReturned = null;
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
                                if (ReadNextElement(reader).Admin_id.ToString() == admin_id)
                                {
                                    adminReturned = ReadNextElement(reader);
                                }
                            }
                        }
                    }
                }

                return adminReturned;
            }
        }

        // Post a conversation to the DB
        public static void Post(Admin adminAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert into Admin Values (@Param4, @Param5)";

                        cmd.Parameters.AddWithValue(parameterName: "@param4", adminAdded.Login);
                        cmd.Parameters.AddWithValue(parameterName: "@param5", adminAdded.Password);


                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Put (update) a conversation's info in the DB
        public static void Put(string admin_id, Admin adminAdded)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open && adminAdded != null)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "UPDATE Admin SET Login = @param3, Password = @param4 WHERE Admin_id = @param2";

                        cmd.Parameters.AddWithValue(parameterName: "@param2", adminAdded.Admin_id);
                        cmd.Parameters.AddWithValue(parameterName: "@param3", adminAdded.Login);
                        cmd.Parameters.AddWithValue(parameterName: "@param4", adminAdded.Password);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Delete a conversation from the DB
        public static void Delete(string admin_id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Admin WHERE Admin_id = @param1";

                        cmd.Parameters.AddWithValue(parameterName: "@param1", admin_id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        //Auth
        public static Admin Auth(string name, string pass)
        {
            Admin a = new Admin();
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = new SqlCommand(@"Select Admin_id
              From Admin
              Where Login = @name AND Password = @pass", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@pass", pass);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows)
                            {
                                a.Admin_id = reader.GetInt32(0);

                            }
                            else
                            {
                                a = null;
                            }
                        }
                    }
                }
            }

            return a;
        }

    }
}

