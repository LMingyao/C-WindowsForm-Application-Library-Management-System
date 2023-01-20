using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FinalProject2021.VALIDATION;
using FinalProject2021.BLL;
using FinalProject2021.DAL;

namespace FinalProject2021.GUI
{
    public partial class SalesManager : Form
    {
        DataTable dtCustomers;

        public SalesManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainInterface mf = new MainInterface();
            mf.Show();
            this.Hide();

        }

        private void buttonlist_Click(object sender, EventArgs e)
        {
            BLL.Customers customer = new BLL.Customers();
            dtCustomers = customer.ListCustomers();
            dataGridViewListFromDatabase.DataSource = dtCustomers;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.TopMost = true;
        }

        private void buttonListFromDataSet_Click(object sender, EventArgs e)
        {
            dataGridViewListFromDataSet.DataSource = dtCustomers;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
       
            Customers aCustomers = new Customers();
            //if (!aCustomers.IsDuplicateID(textBoxCustomerID))
            //{
                aCustomers.CustomerID = Convert.ToInt32(textBoxCustomerID.Text.Trim());
                aCustomers.CustomerString = textBoxCustomerName.Text.Trim();
                aCustomers.StreetAddress = textBoxStreetAddress.Text.Trim();
                aCustomers.City = textBoxCity.Text.Trim();
                aCustomers.PostalCode = textBoxPostalCode.Text.Trim();
                aCustomers.PhoneNumber = textBoxPhoneNumber.Text.Trim();
                aCustomers.FaxNumber = textBoxFaxNumber.Text.Trim();
                aCustomers.CreditLimit = textBoxCreditLimit.Text.Trim();
                aCustomers.Email = textBoxEmail.Text.Trim();
                aCustomers.SaveCustomers(aCustomers);
            //}
        
        }
        
        

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxCustomerID.Text.Trim());
            Customers aCustomers = new Customers();
            aCustomers = aCustomers.SearchCustomers(searchId);
            textBoxCustomerID.Text = aCustomers.CustomerID.ToString();
            textBoxCustomerName.Text = aCustomers.CustomerString;
            textBoxStreetAddress.Text = aCustomers.StreetAddress;
            textBoxCity.Text = aCustomers.City;
            textBoxPostalCode.Text = aCustomers.PostalCode;
            textBoxPhoneNumber.Text = aCustomers.PhoneNumber;
            textBoxFaxNumber.Text = aCustomers.FaxNumber;
            textBoxCreditLimit.Text = aCustomers.CreditLimit;
            textBoxEmail.Text = aCustomers.Email;

        }
    }
}
