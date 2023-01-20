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
    public static class PublisherDB
    {
        public static List<Publisher> GetAllRecords()
        {
            SqlConnection conn = Utility.ConnectDB();
            List<Publisher> listpb = new List<Publisher>();
            Publisher pb;

            try
            {
                SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Publishers", conn);
                SqlDataReader reader = cmdSelectAll.ExecuteReader();
                while (reader.Read())
                {
                    pb = new Publisher();
                    pb.PublisherID = Convert.ToInt32(reader["PublisherID"]);
                    pb.PublisherName = Convert.ToString(reader["PublisherName"]);
                    pb.WebAddress = Convert.ToString(reader["WebAddress"]);
                    listpb.Add(pb);
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


            return listpb;


        }

        public static void SaveRecord(Publisher pub)
        {

            SqlConnection conn = Utility.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = " INSERT INTO Publishers (PublisherID, PublisherName, WebAddress)" +
                "VALUES(@PublisherID, @PublisherName, @WebAddress)";
            cmdInsert.Parameters.AddWithValue("@PublisherID", pub.PublisherID);
            cmdInsert.Parameters.AddWithValue("@PublisherName", pub.PublisherName);
            cmdInsert.Parameters.AddWithValue("@WebAddress", pub.WebAddress);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }

        public static Publisher SearchRecord(int pbID)
        {
            Publisher pb = new Publisher();
            SqlConnection conn = Utility.ConnectDB();
            try
            {
                SqlCommand cmdSearchId = new SqlCommand();
                cmdSearchId.Connection = conn;
                cmdSearchId.CommandText = "SELECT * FROM Publishers " +
                                            "WHERE PublisherID = @PublisherID";
                cmdSearchId.Parameters.AddWithValue("@PublisherID", pbID);
                SqlDataReader reader = cmdSearchId.ExecuteReader();
                if (reader.Read())
                {
                    pb.PublisherID = Convert.ToInt32(reader["PublisherID"]);
                    pb.PublisherName = Convert.ToString(reader["PublisherName"]);
                    pb.WebAddress = Convert.ToString(reader["WebAddress"]);

                }
                else
                {
                    pb = null;
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
            return pb;
        }



    }
}
