using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FinalProject2021.BLL;

namespace FinalProject2021.DAL
{
    public static class LoginDB
    {

        public static Login SearchRecord(int id)
        {
            Login lg = new Login();
            SqlConnection conn = Utility.ConnectDB();
            try
            {
                SqlCommand cmdSearchId = new SqlCommand();
                cmdSearchId.Connection = conn;
                cmdSearchId.CommandText = "SELECT * FROM Employees " +
                                            "WHERE EmployeeID = @EmployeeID";
                cmdSearchId.Parameters.AddWithValue("@EmployeeID", id);
                SqlDataReader reader = cmdSearchId.ExecuteReader();
                if (reader.Read())
                {
                    lg.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                    lg.EmployeeFirstName = Convert.ToString(reader["EmployeeFirstName"]);
                    lg.EmployeeLastName = Convert.ToString(reader["EmployeeLastName"]);
                    lg.EmployeePassword = Convert.ToString(reader["EmployeePassword"]);
                    lg.EmployeePosition = Convert.ToString(reader["EmployeePosition"]);

                }
                else
                {
                    lg = null;
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
            return lg;
        }

       

        public static void UpdateP(Login lg)
        {
            SqlConnection conn = Utility.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = conn;
            cmdUpdate = new SqlCommand("UPDATE Employees SET EmployeePassword = @EmployeePassword" + "WHERE lg.EmployeeID = @EmployeeID", conn);
            conn.Close();
        }
        

    }
}
