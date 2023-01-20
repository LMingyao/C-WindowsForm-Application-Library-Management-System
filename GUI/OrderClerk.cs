using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using FinalProject2021.DAL;

namespace FinalProject2021.GUI
{
    public partial class OrderClerk : Form
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        public OrderClerk()
        {
            InitializeComponent();
        }

        private void OrderClerk_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.TopMost = true;
            var listCus = (from cus in db.Customers
                           select cus).ToList();
            foreach (var itemCus in listCus)
            {
                comboBoxCustomer.Items.Add(itemCus.CustomerID);
            }

            var listBk = (from bk in db.Books
                          select bk).ToList();

            foreach (var itemBk in listBk)
            {
                comboBoxBook.Items.Add(itemBk.ISBN);

            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainInterface mf = new MainInterface();
            mf.Show();
            this.Hide();
        }

        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {
            if (textBoxOrderID != null)
            {
                if (comboBoxCustomer.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the Customer from the list.", "Customer");
                    return;
                }
                if (comboBoxBook.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the Book from the list.", "Book");
                    return;
                }
                if (comboBoxOrderType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the Order Type from the list.", "OrderType");
                    return;
                }
                if (comboBoxPayment.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the Payment from the list.", "Payment");
                    return;
                }
                if (comboBoxStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the Status from the list.", "Status");
                    return;
                }

                //int OrderIdSelected = Convert.ToInt32(textBoxOrderID.Text);
                //string OrderIdEnter = textBoxOrderID.Text.Trim();
                //var OrderIDCheck = (from ord in db.Orders
                //                    where ord.OrderID == OrderIdSelected
                //                    select ord).FirstOrDefault();



                Order ord = new Order();
                ord.OrderID = Convert.ToInt32(textBoxOrderID.Text);
                ord.OrderDate = dateTimePickerOrderDate.Value.ToString();
                ord.OrderType = comboBoxOrderType.Text.Trim();
                ord.ShippingDate = dateTimePickerShippingDate.Value.ToString();
                ord.Status = comboBoxStatus.Text.Trim();
                ord.Payment = comboBoxPayment.Text.Trim();
                ord.CustomerID = Convert.ToInt32(comboBoxCustomer.Text.Trim());
                ord.ISBN = comboBoxBook.Text.Trim();
                db.Orders.Add(ord);
                db.SaveChanges();
                MessageBox.Show("The Order has been placed successfully.", "Orders");

            }
            else if (textBoxOrderID == null)
            {
                MessageBox.Show("Please Enter Order ID.", "Warning");
                return;
            }

        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexDSelected = comboBoxCustomer.SelectedIndex;
            int CustomerID = Convert.ToInt32(comboBoxCustomer.Text);
            Customer cus = db.Customers.Find(CustomerID);
            labelCus.Text = "Name: " + cus.CustomerName + "\n" +
                            "Address: " + cus.StreetAddress + " " + cus.City + " " + cus.PostalCode + "\n" +
                            "PhoneNumber: " + cus.PhoneNumber + "\n" +
                            "FaxNumber: " + cus.FaxNumber + "\n" +
                            "Email: " + cus.Email + "\n" +
                            "CreditLimit: " + cus.CreditLimit;
        }

        private void comboBoxBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexDSelected = comboBoxCustomer.SelectedIndex;
            string ISBN = Convert.ToString(comboBoxBook.Text);
            Book bk = db.Books.Find(ISBN);
            labelBk.Text = "Title: " + bk.Title + "\n" +
                            "Unit Prices: " + bk.UnitPrice + "\n" +
                            "YearPublished: " + bk.YearPublished + "\n" +
                            "QOH: " + bk.QOH + "\n";
        }

        private void buttonListOrder_Click(object sender, EventArgs e)
        {


            var listOrders = (from od in db.Orders
                              select new
                              {
                                  OrderID = od.OrderID,
                                  OrderDate = od.OrderDate,
                                  OrderType = od.OrderType,
                                  ShippingDate = od.ShippingDate,
                                  Status = od.Status,
                                  Payment = od.Payment,
                                  CustomerID = od.CustomerID,
                                  ISBN = od.ISBN
                              });


            listViewOrder.Items.Clear();
            foreach (var itemOd in listOrders)
            {
                ListViewItem item = new ListViewItem(itemOd.OrderID.ToString());
                item.SubItems.Add(itemOd.OrderDate);
                item.SubItems.Add(itemOd.OrderType);
                item.SubItems.Add(itemOd.ShippingDate);
                item.SubItems.Add(itemOd.Status);
                item.SubItems.Add(itemOd.Payment);
                item.SubItems.Add(itemOd.CustomerID.ToString());
                item.SubItems.Add(itemOd.ISBN);
                listViewOrder.Items.Add(item);
            }

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
           
            if(textBoxSearch == null)
            {
                MessageBox.Show("Please enter Search Query","Warning");
                return;
            }
            else {
                int input = Convert.ToInt32(textBoxSearch.Text.Trim());
                Order ord = db.Orders.Find(input);
                if (ord != null)
                {
                    ListViewItem item = new ListViewItem(ord.OrderID.ToString());
                    item.SubItems.Add(ord.OrderDate);
                    item.SubItems.Add(ord.OrderType);
                    item.SubItems.Add(ord.ShippingDate);
                    item.SubItems.Add(ord.Status);
                    item.SubItems.Add(ord.Payment);
                    item.SubItems.Add(ord.CustomerID.ToString());
                    item.SubItems.Add(ord.ISBN);
                    listViewOrder.Items.Clear();
                    listViewOrder.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("No Order Founded", "Warning");
                    return;
                }
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            int input = Convert.ToInt32(textBoxSearch.Text.Trim());
            Order ord = db.Orders.Find(input);
            ord.Status = "Cancelled";
            db.SaveChanges();
            MessageBox.Show("The Order has been successfully cancelled", "Confirmation");
        }

      
    }
}
