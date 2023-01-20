using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject2021.BLL;
using System.Data.SqlClient;

namespace FinalProject2021.DAL
{
    public static class BooksDB
    {
        public static List<Books> GetAllRecords()
        {
            SqlConnection conn = Utility.ConnectDB();

            List<Books> listB = new List<Books>();

            try
            {
                SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Books", conn);
                SqlDataReader reader = cmdSelectAll.ExecuteReader();
                Books boo;
                while (reader.Read())
                {
                    boo = new Books();
                    boo.ISBN = reader["ISBN"].ToString();
                    boo.Title = reader["Title"].ToString();
                    boo.UnitPrice = Convert.ToInt32(reader["UnitPrice"]);
                    boo.YearPublished = reader["YearPublished"].ToString();
                    boo.QOH = Convert.ToInt32(reader["QOH"]);
                    boo.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    boo.PublisherID = Convert.ToInt32(reader["PublisherID"]);
                    listB.Add(boo);
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

            return listB;
        }

        public static Books SearchRecord(string id)
        {
            Books boo = new Books();
            SqlConnection conn = Utility.ConnectDB();

            try
            {
                SqlCommand cmdSearchById = new SqlCommand();
                cmdSearchById.Connection = conn;
                cmdSearchById.CommandText = "SELECT * FROM Books " +
                                            "WHERE ISBN = @ISBN";
                cmdSearchById.Parameters.AddWithValue("@ISBN", id);
                SqlDataReader reader = cmdSearchById.ExecuteReader();
                if (reader.Read())
                {
                    boo.ISBN = reader["ISBN"].ToString();
                    boo.Title = reader["Title"].ToString();
                    boo.UnitPrice = Convert.ToInt32(reader["UnitPrice"]);
                    boo.YearPublished = reader["YearPublished"].ToString();
                    boo.QOH = Convert.ToInt32(reader["QOH"]);
                    boo.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    boo.PublisherID = Convert.ToInt32(reader["PublisherID"]);
                }
                else
                {
                    boo = null;
                }

            }
            catch (SqlException ex)
            {

                throw ex;
            }

            finally
            {
                // close the database
                conn.Close();
                conn.Dispose();

            }
            return boo;
        }

        public static void SaveRecord(Books boo)
        {
        
            SqlConnection conn = Utility.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = " INSERT INTO Books (ISBN, Title, UnitPrice, YearPublished, QOH, CategoryID, PublisherID)" +
                "VALUES(@ISBN, @Title, @UnitPrice, @YearPublished, @QOH, @CategoryID, @PublisherID)";
            cmdInsert.Parameters.AddWithValue("@ISBN", boo.ISBN);
            cmdInsert.Parameters.AddWithValue("@Title", boo.Title);
            cmdInsert.Parameters.AddWithValue("@UnitPrice", boo.UnitPrice);
            cmdInsert.Parameters.AddWithValue("@YearPublished", boo.YearPublished);
            cmdInsert.Parameters.AddWithValue("@QOH", boo.QOH);
            cmdInsert.Parameters.AddWithValue("@CategoryID", boo.CategoryID);
            cmdInsert.Parameters.AddWithValue("@PublisherID", boo.PublisherID);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }
    }
}
