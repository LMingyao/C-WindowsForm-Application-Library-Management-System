using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FinalProject2021.DAL;
using System.Windows.Forms;

namespace FinalProject2021.BLL
{
    public class Customers
    {
        int customerID;
        string customerString;
        string streetAddress;
        string city;
        string postalCode;
        string phoneNumber;
        string faxNumber;
        string creditLimit;
        string email;

        public int CustomerID { get => customerID; set => customerID = value; }
        public string CustomerString { get => customerString; set => customerString = value; }
        public string StreetAddress { get => streetAddress; set => streetAddress = value; }
        public string City { get => city; set => city = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string FaxNumber { get => faxNumber; set => faxNumber = value; }
        public string CreditLimit { get => creditLimit; set => creditLimit = value; }
        public string Email { get => email; set => email = value; }

        public DataTable ListCustomers()
        {
            return CustomersDB.ListCustomersFromDB();

        }

        public void SaveCustomers(Customers aCustomers)
        {
            CustomersDB.SaveRecord(aCustomers);
        }
        public Customers SearchCustomers(int cusID)
        {
            return CustomersDB.SearchRecord(cusID);
        }
        public bool IsDuplicateID(TextBox txtBox)
        {
            return CustomersDB.IsDuplicateId(txtBox);
        }
    }
}
