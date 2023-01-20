using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using FinalProject2021.BLL;
using System.Windows.Forms;

namespace FinalProject2021.DAL
{
    public static class CustomersDB
    {
        static DataTable dtCustomers;
        static DataSet dsFinalProjectDB;
        static SqlDataAdapter da;

        public static DataTable ListCustomersFromDB()
        {

            dsFinalProjectDB = new DataSet("FinalProjectDB");
            dtCustomers = new DataTable("Customers");
            dtCustomers.Columns.Add("CustomerID", typeof(Int32));
            dtCustomers.Columns.Add("CustomerName", typeof(string));
            dtCustomers.Columns.Add("StreetAddress", typeof(string));
            dtCustomers.Columns.Add("City", typeof(string));
            dtCustomers.Columns.Add("PostalCode", typeof(string));
            dtCustomers.Columns.Add("PhoneNumber", typeof(string));
            dtCustomers.Columns.Add("FaxNumber", typeof(string));
            dtCustomers.Columns.Add("CreditLimit", typeof(string));
            dtCustomers.Columns.Add("Email", typeof(string));


            dtCustomers.PrimaryKey = new DataColumn[]
            {
                dtCustomers.Columns["CustomerID"]
            };

            dsFinalProjectDB = UnilityDB.GetDataSet(dtCustomers, "Customers");

            da = new SqlDataAdapter("SELECT * FROM Customers", UnilityDB.ConnectDB());

            da.Fill(dsFinalProjectDB.Tables["Customers"]);
            return dtCustomers;
        }

        public static Customers SearchRecord(int cusID)
        {
            DataRow drCustomers = dtCustomers.Rows.Find(cusID);
            if (drCustomers != null)
            {
                Customers aCustomers = new Customers();
                aCustomers.CustomerID = Convert.ToInt32(drCustomers["CustomerID"]);
                aCustomers.CustomerString = drCustomers["CustomerName"].ToString();
                aCustomers.StreetAddress = drCustomers["StreetAddress"].ToString();
                aCustomers.City = drCustomers["City"].ToString();
                aCustomers.PostalCode = drCustomers["PostalCode"].ToString();
                aCustomers.PhoneNumber = drCustomers["PhoneNumber"].ToString();
                aCustomers.FaxNumber = drCustomers["FaxNumber"].ToString();
                aCustomers.CreditLimit = drCustomers["CreditLimit"].ToString();
                aCustomers.Email = drCustomers["Email"].ToString();
                return aCustomers;
            }
            else
            {
                MessageBox.Show("Customer Not Found!", "Error");
                return null;
            }
        }


        public static void SaveRecord(Customers aCustomers)
        {
            dtCustomers = new DataTable("Customers");
            DataRow drCustomers = dtCustomers.NewRow();
            drCustomers["CustomerID"] = aCustomers.CustomerID;
            drCustomers["CustomerName"] = aCustomers.CustomerString;
            drCustomers["StreetAddress"] = aCustomers.StreetAddress;
            drCustomers["City"] = aCustomers.City;
            drCustomers["PostalCode"] = aCustomers.PostalCode;
            drCustomers["PhoneNumber"] = aCustomers.PhoneNumber;
            drCustomers["FaxNumber"] = aCustomers.FaxNumber;
            drCustomers["CreditLimit"] = aCustomers.CreditLimit;
            drCustomers["Email"] = aCustomers.Email;
            dtCustomers.Rows.Add(drCustomers);
            MessageBox.Show(drCustomers.RowState.ToString());
        }

        public static bool IsDuplicateId(TextBox txtBox)
        {
            dtCustomers = ListCustomersFromDB();

            DataRow drS = dtCustomers.Rows.Find(Convert.ToInt32(txtBox.Text));
            if (drS != null)
            {
                MessageBox.Show("The customer ID you entered already exists in the database!", "Error");
                txtBox.Text = "";
                return true;

            }
            return false;
        }
    }
}
