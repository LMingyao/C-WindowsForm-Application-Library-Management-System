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
    public static class OrderListDB
    {
        public static List<OrderList>GetAllRecords()
        {
            SqlConnection conn = Utility.ConnectDB();
            List<OrderList> listord = new List<OrderList>();
            OrderList ord;
            try
            {
                SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Orders", conn);
                SqlDataReader reader = cmdSelectAll.ExecuteReader();
                while (reader.Read())
                {
                    ord = new OrderList();
                    ord.OrderID = Convert.ToInt32(reader["OrderID"]);
                    ord.OrderDate = Convert.ToString(reader["OrderDate"]);
                    ord.OrderType = Convert.ToString(reader["OrderType"]);
                    ord.ShippingDate = Convert.ToString(reader["ShippingDate"]);
                    ord.Status = Convert.ToString(reader["Status"]);
                    ord.Payment = Convert.ToString(reader["Payment"]);
                    ord.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    ord.ISBN = Convert.ToString(reader["ISBN"]);

                    listord.Add(ord);
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


            return listord;


        }

        public static OrderList SearchRecord(int cusID)
        {
            OrderList ord = new OrderList();
            SqlConnection conn = Utility.ConnectDB();

            try
            {
                SqlCommand cmdSearchById = new SqlCommand();
                cmdSearchById.Connection = conn;
                cmdSearchById.CommandText = "SELECT * FROM Orders " +
                                            "WHERE CustomerID = @cusID";
                cmdSearchById.Parameters.AddWithValue("@cusID", cusID);
                SqlDataReader reader = cmdSearchById.ExecuteReader();
                if (reader.Read())
                {
                    ord.OrderID = Convert.ToInt32(reader["OrderID"]);
                    ord.OrderDate = reader["OrderDate"].ToString();
                    ord.OrderType = reader["OrderType"].ToString();
                    ord.ShippingDate = reader["ShippingDate"].ToString();
                    ord.Status = reader["Status"].ToString();
                    ord.Payment = reader["Payment"].ToString();
                    ord.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    ord.ISBN = reader["ISBN"].ToString();

                }
                else
                {
                    ord = null;
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
            return ord;
        }
    }
}
