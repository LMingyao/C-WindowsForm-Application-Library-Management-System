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
    public static class CategoryDB
    {
        public static List<Category> GetAllRecords()
        {
            SqlConnection conn = Utility.ConnectDB();
            List<Category> listct = new List<Category>();
            Category ct;

            try
            {
                SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Categories", conn);
                SqlDataReader reader = cmdSelectAll.ExecuteReader();
                while (reader.Read())
                {
                    ct = new Category();
                    ct.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    ct.CategoryName = Convert.ToString(reader["CategoryName"]);
                    listct.Add(ct);
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


            return listct;


        }

        public static void SaveRecord(Category cat)
        {

            SqlConnection conn = Utility.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = " INSERT INTO Categories (CategoryID, CategoryName)" +
                "VALUES(@CategoryID, @CategoryName)";
            cmdInsert.Parameters.AddWithValue("@CategoryID", cat.CategoryID);
            cmdInsert.Parameters.AddWithValue("@CategoryName", cat.CategoryName);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }

        public static Category SearchRecord(int ctID)
        {
            Category ct = new Category();
            SqlConnection conn = Utility.ConnectDB();
            try
            {
                SqlCommand cmdSearchId = new SqlCommand();
                cmdSearchId.Connection = conn;
                cmdSearchId.CommandText = "SELECT * FROM Categories " +
                                            "WHERE CategoryID = @CategoryID";
                cmdSearchId.Parameters.AddWithValue("@CategoryID", ctID);
                SqlDataReader reader = cmdSearchId.ExecuteReader();
                if (reader.Read())
                {
                    ct.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    ct.CategoryName = Convert.ToString(reader["CategoryName"]);

                }
                else
                {
                    ct = null;
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
            return ct;
        }
    }
}
