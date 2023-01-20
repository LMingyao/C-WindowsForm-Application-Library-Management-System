using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject2021.DAL;
using FinalProject2021.BLL;
using System.Data.SqlClient;
using FinalProject2021.VALIDATION;

namespace FinalProject2021.GUI
{
    public partial class Accountant : Form
    {
        public Accountant()
        {
            InitializeComponent();
        }

        private void Accountant_Load(object sender, EventArgs e)
        {
            this.textBox1.AutoSize = false;
            textBox1.Height = 400;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            OrderList ord = new OrderList();
            List<OrderList> listord =ord.GetAllOrders();
            foreach (OrderList o in listord)
            {
                comboBoxCustomer.Items.Add(o.OrderID);
            }

        }

       
        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)

        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainInterface mf = new MainInterface();
            mf.Show();
            this.Hide();
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
        
            string input = comboBoxCustomer.Text;
            OrderList ord = new OrderList();
            ord = ord.SearchOrders(Convert.ToInt32(input));
            dataGridView1.DataSource = ord;


        }
    }
}
