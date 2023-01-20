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
    public partial class MISManager : Form
    {
        public MISManager()
        {
            InitializeComponent();
        }

        private void MISManager_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.TopMost = true;

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainInterface mf = new MainInterface();
            mf.Show();
            this.Hide();
          

        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            User us = new User();
            List<User> listus = us.GetAllUsers();
            listViewUser.Items.Clear();
            if (listus.Count != 0)
            {
                foreach (User u_item in listus)
                {
                    ListViewItem item = new ListViewItem(u_item.UserID.ToString());
                    item.SubItems.Add(u_item.UserPassword);
                    item.SubItems.Add(u_item.EmployeeID.ToString());
                    listViewUser.Items.Add(item);

                }
            }
            else
            {
                MessageBox.Show("Users list is empty");
                return;
            }
        }

        private void buttonElist_Click(object sender, EventArgs e)
        {
            Employees emp = new Employees();
            List<Employees> listEmp = emp.GetAllEmployees();
            listViewEmployee.Items.Clear();
            if (listEmp.Count != 0)
            {
                foreach (Employees emp_item in listEmp)
                {
                    ListViewItem item = new ListViewItem(emp_item.EmployeeID.ToString());
                    item.SubItems.Add(emp_item.EmployeeFirstName);
                    item.SubItems.Add(emp_item.EmployeeLastName); 
                    item.SubItems.Add(emp_item.EmployeePassword);
                    item.SubItems.Add(emp_item.EmployeePosition);
                    item.SubItems.Add(emp_item.EmployeeUserID.ToString());
                    item.SubItems.Add(emp_item.EmployeePhoneNumber);
                    item.SubItems.Add(emp_item.EmployeeEmail);
                    listViewEmployee.Items.Add(item);

                }
            }
            else
            {
                MessageBox.Show("Employee list is empty");
                return;
            }
        }

        private void buttonESearch_Click(object sender, EventArgs e)
        {
            string input = textBoxESearch.Text.Trim();
            Employees emp = new Employees();
            emp = emp.SearchEmployees(Convert.ToInt32(input));
            if (emp != null)
            {
                textBoxEmployeeID.Text = emp.EmployeeID.ToString();
                textBoxEmployeeFirstName.Text = emp.EmployeeFirstName;
                textBoxEmployeeLastName.Text = emp.EmployeeLastName;
                textBoxEmployeePassword.Text = emp.EmployeePassword;
                textBoxPosition.Text = emp.EmployeePosition;
                textBoxEmployeeUserID.Text = emp.EmployeeUserID.ToString();
                textBoxEmployeePhone.Text = emp.EmployeePhoneNumber;
                textBoxEmployeeEmail.Text = emp.EmployeeEmail;
            }
            else
            {
                MessageBox.Show("Employee not found");
                textBoxESearch.Clear();
                textBoxESearch.Focus();
                return;
            }
        }

        private void buttonEDelete_Click(object sender, EventArgs e)
        {
            if (!(textBoxESearch.Text == string.Empty))
            {
                SqlConnection conn = Utility.ConnectDB();
                string query = "Delete from Employees where EmployeeID= '" + this.textBoxESearch.Text + "'";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader myreader;
                try
                {
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("The Employee has been deleted successfully", "user information");
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
                MessageBox.Show("Please enter the Employee ID which you want to delete", "User information");
            }
            textBoxEmployeeID.Clear();
            textBoxEmployeeLastName.Clear();
            textBoxEmployeeFirstName.Clear();
            textBoxEmployeePassword.Clear();
            textBoxPosition.Clear();
            textBoxEmployeeUserID.Clear();
            textBoxEmployeePhone.Clear();
            textBoxEmployeeEmail.Clear();

        }

        private void buttonEAdd_Click(object sender, EventArgs e)
        {
            string input = textBoxEmployeeID.Text.Trim();
            Employees emp = new Employees();
            if (!emp.IsDuplicateclId(Convert.ToInt32(input)))
            {
                input = "";
                input = textBoxEmployeeFirstName.Text.Trim();
                if (!Validation.IsValidName(input))
                {
                    MessageBox.Show("First Name contains only letters and space to separate first name components",
                        "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxEmployeeFirstName.Clear();
                    textBoxEmployeeFirstName.Focus();
                    return;

                }
                input = "";
                input = textBoxEmployeeLastName.Text.Trim();
                if (!Validation.IsValidName(input))
                {
                    MessageBox.Show("Last Name contains only letters and space to separate Last name components",
                        "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxEmployeeLastName.Clear();
                    textBoxEmployeeLastName.Focus();
                    return;

                }

                emp.EmployeeID = Convert.ToInt32(textBoxEmployeeID.Text.Trim());
                emp.EmployeeFirstName = textBoxEmployeeLastName.Text.Trim();
                emp.EmployeeLastName = textBoxEmployeeFirstName.Text.Trim();
                emp.EmployeePassword = textBoxEmployeePassword.Text.Trim();
                emp.EmployeePosition = textBoxPosition.Text.Trim();
                emp.EmployeeUserID = Convert.ToInt32(textBoxEmployeeUserID.Text.Trim());
                emp.EmployeePhoneNumber = textBoxEmployeePhone.Text.Trim();
                emp.EmployeeEmail = textBoxEmployeeEmail.Text.Trim();
                emp.SaveEmployees(emp);
                MessageBox.Show("New Employee Added successfully", "Confirmation");
                textBoxEmployeeID.Clear();
                textBoxEmployeeLastName.Clear();
                textBoxEmployeeFirstName.Clear();
                textBoxEmployeePassword.Clear();
                textBoxPosition.Clear();
                textBoxEmployeeUserID.Clear();
                textBoxEmployeePhone.Clear();
                textBoxEmployeeEmail.Clear();
            }
            else
            {
                MessageBox.Show("This Id has already existed");
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            User us = new User();
            us.UserID= Convert.ToInt32(textBoxUserID.Text.Trim());
            us.UserPassword = textBoxUserPassword.Text.Trim();
            us.EmployeeID = Convert.ToInt32(textBoxUEmployeeID.Text.Trim());
            us.SaveUser(us);
            MessageBox.Show("User Saved", "Confirmation");
            textBoxUserID.Clear();
            textBoxUserPassword.Clear();
            textBoxUEmployeeID.Clear();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string input = textBoxSearch.Text.Trim();
            User us = new User();
            us = us.SearchUser(Convert.ToInt32(input));
            if (us != null)
            {
                textBoxUserID.Text = us.UserID.ToString();
                textBoxUserPassword.Text = us.UserPassword;
                textBoxUEmployeeID.Text = us.EmployeeID.ToString();
            }
            else
            {
                MessageBox.Show("User not found");
                textBoxSearch.Clear();
                textBoxSearch.Focus();
                return;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!(textBoxSearch.Text == string.Empty))
            {
                SqlConnection conn = Utility.ConnectDB();
                string query = "Delete from UsersAccount where UserID= '" + this.textBoxSearch.Text + "'";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader myreader;
                try
                {
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("The User has been deleted successfully", "user information");
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
                MessageBox.Show("Please enter the User ID which you want to delete", "User information");
            }
            textBoxUserID.Clear();
            textBoxUserPassword.Clear();
            textBoxUEmployeeID.Clear();
                
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!(textBoxSearch.Text == string.Empty))
            {
                SqlConnection conn = Utility.ConnectDB();
                string query = "UPDATE UsersAccount SET UserPassword= '" + this.textBoxUserPassword.Text + "'" + " where UserID= '" + this.textBoxSearch.Text + "'"+
                    "UPDATE UsersAccount SET EmployeeID= '" + this.textBoxUEmployeeID.Text + "'" + " where UserID= '" + this.textBoxSearch.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader myreader;
                try
                {
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("The User has been Updated successfully", "user information");
                    while (myreader.Read())
                    {
                    }
                    conn.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("User ID cannot be changed!","Warning");
                    MessageBox.Show(ec.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter the User ID which you want to update", "User information");
            }
            //textBoxUserID.Clear();
            //textBoxUserPassword.Clear();
            //textBoxUEmployeeID.Clear();
        }

        private void buttonEUpdate_Click(object sender, EventArgs e)
        {
            if (!(textBoxESearch.Text == string.Empty))
            {
                SqlConnection conn = Utility.ConnectDB();
                string query = "UPDATE Employees SET EmployeeFirstName= '" + this.textBoxEmployeeFirstName.Text + "'" + " where EmployeeID= '" + this.textBoxESearch.Text + "'" +
                               "UPDATE Employees SET EmployeeLastName= '" + this.textBoxEmployeeLastName.Text + "'" + " where EmployeeID= '" + this.textBoxESearch.Text + "'"+
                               "UPDATE Employees SET EmployeePassword= '" + this.textBoxEmployeePassword.Text + "'" + " where EmployeeID= '" + this.textBoxESearch.Text + "'" +
                               "UPDATE Employees SET EmployeePosition= '" + this.textBoxPosition.Text + "'" + " where EmployeeID= '" + this.textBoxESearch.Text + "'" +
                               "UPDATE Employees SET UserID= '" + this.textBoxEmployeeUserID.Text + "'" + " where EmployeeID= '" + this.textBoxESearch.Text + "'" +
                               "UPDATE Employees SET EmployeePhoneNumber= '" + this.textBoxEmployeePhone.Text + "'" + " where EmployeeID= '" + this.textBoxESearch.Text + "'" +
                               "UPDATE Employees SET EmployeeEmail= '" + this.textBoxEmployeeEmail.Text + "'" + " where EmployeeID= '" + this.textBoxESearch.Text + "'" 
                               ;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader myreader;
                try
                {
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("The Employee has been Updated successfully", "user information");
                    while (myreader.Read())
                    {
                    }
                    conn.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("Employee ID cannot be changed!", "Warning");
                    MessageBox.Show(ec.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter the Employee ID which you want to update", "User information");
            }
            //textBoxEmployeeID.Clear();
            //textBoxEmployeeLastName.Clear();
            //textBoxEmployeeFirstName.Clear();
            //textBoxEmployeePassword.Clear();
            //textBoxPosition.Clear();
            //textBoxEmployeeUserID.Clear();
            //textBoxEmployeePhone.Clear();
            //textBoxEmployeeEmail.Clear();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
