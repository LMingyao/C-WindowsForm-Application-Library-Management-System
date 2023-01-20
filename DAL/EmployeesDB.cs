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
    public static class EmployeesDB
    {
        public static List<Employees> GetAllRecords()
        {
            SqlConnection conn = Utility.ConnectDB();
            List<Employees> listE = new List<Employees>();
            Employees emp;

            try
            {
                SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", conn);
                SqlDataReader reader = cmdSelectAll.ExecuteReader();
                while (reader.Read())
                {
                    emp = new Employees();
                    emp.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                    emp.EmployeeFirstName = Convert.ToString(reader["EmployeeFirstName"]);
                    emp.EmployeeLastName = Convert.ToString(reader["EmployeeLastName"]);
                    emp.EmployeePassword = Convert.ToString(reader["EmployeePassword"]);
                    emp.EmployeePosition = Convert.ToString(reader["EmployeePosition"]);
                    emp.EmployeeUserID = Convert.ToInt32(reader["UserID"]);
                    emp.EmployeePhoneNumber = Convert.ToString(reader["EmployeePhoneNumber"]);
                    emp.EmployeeEmail = Convert.ToString(reader["EmployeeEmail"]);
                    listE.Add(emp);
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


            return listE;


        }

        public static Employees SearchRecord(int id)
        {
            Employees emp = new Employees();
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
                    emp.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                    emp.EmployeeFirstName = Convert.ToString(reader["EmployeeFirstName"]);
                    emp.EmployeeLastName = Convert.ToString(reader["EmployeeLastName"]);
                    emp.EmployeePassword = Convert.ToString(reader["EmployeePassword"]);
                    emp.EmployeePosition = Convert.ToString(reader["EmployeePosition"]);
                    emp.EmployeeUserID = Convert.ToInt32(reader["UserID"]);
                    emp.EmployeePhoneNumber = Convert.ToString(reader["EmployeePhoneNumber"]);
                    emp.EmployeeEmail = Convert.ToString(reader["EmployeeEmail"]);
                }
                else
                {
                    emp = null;
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
            return emp;
        }
        public static void SaveRecord(Employees emp)
        {
            SqlConnection conn = Utility.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = " INSERT INTO Employees(EmployeeID, EmployeeFirstName, EmployeeLastName, EmployeePassword, EmployeePosition, UserID, EmployeePhoneNumber, EmployeeEmail)" +
                "VALUES(@EmployeeID, @EmployeeFirstName, @EmployeeLastName, @EmployeePassword, @EmployeePosition, @UserID, @EmployeePhoneNumber, @EmployeeEmail)";
            cmdInsert.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
            cmdInsert.Parameters.AddWithValue("@EmployeeFirstName", emp.EmployeeFirstName);
            cmdInsert.Parameters.AddWithValue("@EmployeeLastName", emp.EmployeeLastName);
            cmdInsert.Parameters.AddWithValue("@EmployeePassword", emp.EmployeePassword);
            cmdInsert.Parameters.AddWithValue("@EmployeePosition", emp.EmployeePosition);
            cmdInsert.Parameters.AddWithValue("@UserID", emp.EmployeeUserID);
            cmdInsert.Parameters.AddWithValue("@EmployeePhoneNumber", emp.EmployeePhoneNumber);
            cmdInsert.Parameters.AddWithValue("@EmployeeEmail", emp.EmployeeEmail);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }

        public static bool IsDuplicateId(int id)
        {
            if (EmployeesDB.SearchRecord(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
