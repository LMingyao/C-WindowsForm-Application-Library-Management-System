using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject2021.BLL;
using System.Data.SqlClient;

namespace FinalProject2021.DAL
{
    public static class AuthorBookDB
    {
        public static List<AuthorBook> GetAllRecords()
        {
            SqlConnection conn = Utility.ConnectDB();
            List<AuthorBook> listab = new List<AuthorBook>();
            AuthorBook ab;

            try
            {
                SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM AuthorBooks", conn);
                SqlDataReader reader = cmdSelectAll.ExecuteReader();
                while (reader.Read())
                {
                    ab = new AuthorBook();
                    ab.AuthorID = Convert.ToInt32(reader["AuthorID"]);
                    ab.ISBN = Convert.ToString(reader["ISBN"]);
                    ab.YearPublished = Convert.ToString(reader["YearPublished"]);
                    ab.Edition = Convert.ToString(reader["Edition"]);
                    listab.Add(ab);
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


            return listab;


        }

        public static AuthorBook SearchRecordABID(int abId)
        {
            AuthorBook ab = new AuthorBook();
            SqlConnection conn = Utility.ConnectDB();
            try
            {
                SqlCommand cmdSearchId = new SqlCommand();
                cmdSearchId.Connection = conn;
                cmdSearchId.CommandText = "SELECT * FROM AuthorBooks " +
                                            "WHERE AuthorID = @AuthorID";
                cmdSearchId.Parameters.AddWithValue("@AuthorID", abId);
                SqlDataReader reader = cmdSearchId.ExecuteReader();
                if (reader.Read())
                {
                    ab.AuthorID = Convert.ToInt32(reader["AuthorID"]);
                    ab.ISBN = Convert.ToString(reader["ISBN"]);
                    ab.YearPublished = Convert.ToString(reader["YearPublished"]);
                    ab.Edition = Convert.ToString(reader["Edition"]);

                }
                else
                {
                    ab = null;
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
            return ab;
        }

        public static AuthorBook SearchRecordISBN(string ISBNid)
        {
            AuthorBook ab = new AuthorBook();
            SqlConnection conn = Utility.ConnectDB();
            try
            {
                SqlCommand cmdSearchId = new SqlCommand();
                cmdSearchId.Connection = conn;
                cmdSearchId.CommandText = "SELECT * FROM AuthorBooks " +
                                            "WHERE ISBN = @ISBN";
                cmdSearchId.Parameters.AddWithValue("@ISBN", ISBNid);
                SqlDataReader reader = cmdSearchId.ExecuteReader();
                if (reader.Read())
                {
                    ab.AuthorID = Convert.ToInt32(reader["AuthorID"]);
                    ab.ISBN = Convert.ToString(reader["ISBN"]);
                    ab.YearPublished = Convert.ToString(reader["YearPublished"]);
                    ab.Edition = Convert.ToString(reader["Edition"]);

                }
                else
                {
                    ab = null;
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
            return ab;
        }

        public static void SaveRecord(AuthorBook ab)
        {

            SqlConnection conn = Utility.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = " INSERT INTO AuthorBooks(AuthorID, ISBN, YearPublished, Edition)" +
                "VALUES(@AuthorID, @ISBN, @YearPublished, @Edition)";
            cmdInsert.Parameters.AddWithValue("@AuthorID", ab.AuthorID);
            cmdInsert.Parameters.AddWithValue("@ISBN", ab.ISBN);
            cmdInsert.Parameters.AddWithValue("@YearPublished", ab.YearPublished);
            cmdInsert.Parameters.AddWithValue("@Edition", ab.Edition);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }
    }
}
