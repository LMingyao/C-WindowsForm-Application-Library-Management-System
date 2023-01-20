using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject2021.DAL;

namespace FinalProject2021.BLL
{
    public class OrderList
    {
        private int orderID;
        private string orderDate;
        private string orderType;
        private string shippingDate;
        private string status;
        private string payment;
        private int customerID;
        private string iSBN;

        public int OrderID { get => orderID; set => orderID = value; }
        public string OrderDate { get => orderDate; set => orderDate = value; }
        public string OrderType { get => orderType; set => orderType = value; }
        public string ShippingDate { get => shippingDate; set => shippingDate = value; }
        public string Status { get => status; set => status = value; }
        public string Payment { get => payment; set => payment = value; }
        public int CustomerID { get => customerID; set => customerID = value; }
        public string ISBN { get => iSBN; set => iSBN = value; }

        public List<OrderList> GetAllOrders()
        {
            return OrderListDB.GetAllRecords();
        }
        public OrderList SearchOrders(int cusID)
        {
            return OrderListDB.SearchRecord(cusID);
        }

    }
}
