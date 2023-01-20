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
    public static class AuthorDB
    {
        public static List<Author> GetAllRecords()
        {
            SqlConnection conn = Utility.ConnectDB();
            List<Author> listau = new List<Author>();
            Author au;

            try
            {
                SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Authors", conn);
                SqlDataReader reader = cmdSelectAll.ExecuteReader();
                while (reader.Read())
                {
                    au = new Author();
                    au.AuthorID = Convert.ToInt32(reader["AuthorID"]);
                    au.FirstName = Convert.ToString(reader["FirstName"]);
                    au.LastName = Convert.ToString(reader["LastName"]);
                    au.Email = Convert.ToString(reader["Email"]);
                    listau.Add(au);
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


            return listau;


        }

        public static Author SearchRecord(int auid)
        {
            Author au = new Author();
            SqlConnection conn = Utility.ConnectDB();
            try
            {
                SqlCommand cmdSearchId = new SqlCommand();
                cmdSearchId.Connection = conn;
                cmdSearchId.CommandText = "SELECT * FROM Authors " +
                                            "WHERE AuthorID = @AuthorID";
                cmdSearchId.Parameters.AddWithValue("@AuthorID", auid);
                SqlDataReader reader = cmdSearchId.ExecuteReader();
                if (reader.Read())
                {
                    au.AuthorID = Convert.ToInt32(reader["AuthorID"]);
                    au.LastName = Convert.ToString(reader["LastName"]);
                    au.FirstName = Convert.ToString(reader["FirstName"]);
                    au.Email = Convert.ToString(reader["Email"]);

                }
                else
                {
                    au = null;
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
            return au;
        }

        public static void SaveRecord(Author aut)
        {

            SqlConnection conn = Utility.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = " INSERT INTO Authors (AuthorID, FirstName, LastName, Email)" +
                "VALUES(@AuthorID, @FirstName, @LastName, @Email)";
            cmdInsert.Parameters.AddWithValue("@AuthorID", aut.AuthorID);
            cmdInsert.Parameters.AddWithValue("@FirstName", aut.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", aut.LastName);
            cmdInsert.Parameters.AddWithValue("@Email", aut.Email);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }
    }
}
