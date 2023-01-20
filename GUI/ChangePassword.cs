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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void textBoxEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            buttonChange.Enabled = false;
            textBoxNew2.Enabled = false;
            textBoxNew.Enabled = false;
            this.WindowState = FormWindowState.Maximized;
            textBoxNew.UseSystemPasswordChar = true;
            textBoxOldPassword.UseSystemPasswordChar = true;
            textBoxNew2.UseSystemPasswordChar = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.TopMost = true;

        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Utility.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;

            if (textBoxEmployeeID.Text != string.Empty || textBoxOldPassword.Text != string.Empty)
            {
                string query = "Select * from Employees Where EmployeeID = '" + textBoxEmployeeID.Text.Trim() + "'and EmployeePassword ='"
                     + textBoxOldPassword.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable Employees = new DataTable();
                sda.Fill(Employees);

                if (Employees.Rows.Count == 1)
                {
                    MessageBox.Show("Your identity verification has been successful, password can be changed.", "Confirmation");
                    buttonChange.Enabled = true;
                    textBoxNew.Enabled = true;
                    textBoxNew2.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Please cheack your Employee ID and Password!\n" +
                   "If you cannot fix this issue, contact the company.", "Warning");
                    textBoxOldPassword.Clear();
                    buttonChange.Enabled = false;
                    textBoxNew.Enabled = false;
                    textBoxNew2.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("Please enter your EmployeeID and Password", "Warning");
                buttonChange.Enabled = false;
                textBoxNew.Enabled = false;
                textBoxNew2.Enabled = false;
            }

            textBoxNew.Clear();
            textBoxNew2.Clear();

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainInterface mi = new MainInterface();
            this.Hide();
            mi.Show();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (textBoxNew2.Text.Trim() == textBoxNew.Text.Trim())
            { 
                if (!(textBoxNew.Text == string.Empty))
                {
                    SqlConnection conn = Utility.ConnectDB();
                    string query = "UPDATE Employees SET EmployeePassword= '" + this.textBoxNew.Text + "'" + " where EmployeeID= '" + this.textBoxEmployeeID.Text + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader myreader;
                    try
                    {
                        myreader = cmd.ExecuteReader();
                        MessageBox.Show("The Password has been changed successfully", "user information");
                        while (myreader.Read())
                        {
                        }
                        conn.Close();
                    }
                    catch (Exception ec)
                    {
                        MessageBox.Show(ec.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the revised Password", "Warning");
                }
                textBoxEmployeeID.Clear();
                textBoxOldPassword.Clear();
                textBoxNew.Clear();
                textBoxNew2.Clear();
            }

            else
            {
                MessageBox.Show("The passwords you entered twice do not match","Warning");
                textBoxNew.Clear();
                textBoxNew2.Clear();
            }
            
        }

    

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }

    }
}
