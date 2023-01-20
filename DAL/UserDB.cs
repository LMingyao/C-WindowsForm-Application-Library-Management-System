using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject2021.DAL;
using FinalProject2021.BLL;
using System.Data.SqlClient;

namespace FinalProject2021.DAL
{
    public static class UserDB
    {
        public static List<User> GetAllRecords()
        {
            SqlConnection conn = Utility.ConnectDB();
            List<User> listU = new List<User>();
            User us;

            try
            {
                SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM UsersAccount", conn);
                SqlDataReader reader = cmdSelectAll.ExecuteReader();
                while (reader.Read())
                {
                    us = new User();
                    us.UserID = Convert.ToInt32(reader["UserID"]);
                    us.UserPassword = Convert.ToString(reader["UserPassword"]); 
                    us.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                    listU.Add(us);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }


            return listU;


        }

        public static void SaveRecord(User us)
        {
            SqlConnection conn = Utility.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = " INSERT INTO UsersAccount(UserID, UserPassword, EmployeeID)" +
                "VALUES(@UserID, @UserPassword, @EmployeeID)";
            cmdInsert.Parameters.AddWithValue("@UserID",us.UserID);
            cmdInsert.Parameters.AddWithValue("@UserPassword", us.UserPassword);
            cmdInsert.Parameters.AddWithValue("@EmployeeID", us.EmployeeID);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }

        public static User SearchRecord(int usId)
        {
            User us = new User();
            SqlConnection conn = Utility.ConnectDB();
            try
            {
                SqlCommand cmdSearchId = new SqlCommand();
                cmdSearchId.Connection = conn;
                cmdSearchId.CommandText = "SELECT * FROM UsersAccount " +
                                            "WHERE UserID = @UserID";
                cmdSearchId.Parameters.AddWithValue("@UserID ", usId);
                SqlDataReader reader = cmdSearchId.ExecuteReader();
                if (reader.Read())
                {
                    us.UserID = Convert.ToInt32(reader["UserID"]);
                    us.UserPassword = Convert.ToString(reader["UserPassword"]);
                    us.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);

                }
                else
                {
                    us = null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return us;
        }

    }
}
