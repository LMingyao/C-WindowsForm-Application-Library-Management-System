using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject2021.DAL;
using FinalProject2021.BLL;
using System.Data.SqlClient;
using FinalProject2021.VALIDATION;

namespace FinalProject2021.GUI
{
    public partial class MainInterface : Form
    {
        public MainInterface()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contact the Company now! Tel: 514-721-8662 " +'\n'+
                "Contactez l'entreprise maintenant! Tel: 514 - 721 - 8662","Warning");
        }

        private void MainInterface_Load(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            this.ControlBox = false;
            this.Width = 700;
            this.Height = 550;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.TopMost = true;

            //ButtonClickRepeater repeater = new ButtonClickRepeater(this.buttonShow, 1000);
            //repeater.Click += new EventHandler(buttonShow_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Utility.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;

            if (textBoxEmployeeID.Text != string.Empty || textBoxPassword.Text != string.Empty)
            {
                string query = "Select * from Employees Where EmployeeID = '" + textBoxEmployeeID.Text.Trim() + "'and EmployeePassword ='"
                     + textBoxPassword.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable Employees = new DataTable();
                sda.Fill(Employees);

                if (Employees.Rows.Count == 1)
                {
                    //MessageBox.Show("Login Successfully");
                    string input = textBoxEmployeeID.Text.Trim();
                    Login lg = new Login();
                    lg = lg.SearchEmployee(Convert.ToInt32(input));
                    if (lg.EmployeePosition == "MIS_Manager")
                    {
                        MessageBox.Show("EmployeeID " + lg.EmployeeID + ", " + lg.EmployeeFirstName + " " + lg.EmployeeLastName + " as a " + lg.EmployeePosition + " has been login successfully", "Confirmation");
                        MISManager mis = new MISManager();
                        this.Hide();
                        mis.Show();
                    }
                    else if (lg.EmployeePosition == "Sales_Manager")
                    {
                        MessageBox.Show("EmployeeID " + lg.EmployeeID + ", " + lg.EmployeeFirstName + " " + lg.EmployeeLastName + " as a " + lg.EmployeePosition + " has been login successfully", "Confirmation");
                        SalesManager sm = new SalesManager();
                        this.Hide();
                        sm.Show();
                    }
                    else if (lg.EmployeePosition == "Inventory_Controller")
                    {
                        MessageBox.Show("EmployeeID " + lg.EmployeeID + ", " + lg.EmployeeFirstName + " " + lg.EmployeeLastName + " as a " + lg.EmployeePosition + " has been login successfully", "Confirmation");
                        InventoryController ic = new InventoryController();
                        this.Hide();
                        ic.Show();
                    }
                    else if (lg.EmployeePosition == "Order_Clerk")
                    {
                        MessageBox.Show("EmployeeID " + lg.EmployeeID + ", " + lg.EmployeeFirstName + " " + lg.EmployeeLastName + " as a " + lg.EmployeePosition + " has been login successfully", "Confirmation");
                        OrderClerk oc = new OrderClerk();
                        this.Hide();
                        oc.Show();
                    }
                    else if (lg.EmployeePosition == "Accountant")
                    {
                        MessageBox.Show("EmployeeID " + lg.EmployeeID + ", " + lg.EmployeeFirstName + " " + lg.EmployeeLastName + " as a " + lg.EmployeePosition + " has been login successfully", "Confirmation");
                        Accountant ac = new Accountant();
                        this.Hide();
                        ac.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Please cheack your Employee ID and Password!\n" +
                    "If you cannot fix this issue, contact the company.", "Warning");
                }
            }
            else
            {
                MessageBox.Show("Please enter your EmployeeID and Password","Warning");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            this.Hide();
            cp.Show();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you really want to exit the application?",
          "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Help hp = new Help();
            this.Hide();
            hp.Show();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            var n = textBoxPassword.UseSystemPasswordChar;

            if (n = true)
            {
                textBoxPassword.UseSystemPasswordChar = false;
                wait(1000);
                textBoxPassword.UseSystemPasswordChar = true;

            }

        }

        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        //class ButtonClickRepeater
        //{
        //    public event EventHandler Click;

        //    private Button button;
        //    private Timer timer;

        //    public ButtonClickRepeater(Button button, int interval)
        //    {
        //        if (button == null) throw new ArgumentNullException();

        //        this.button = button;
        //        button.MouseDown += new MouseEventHandler(button_MouseDown);
        //        button.MouseUp += new MouseEventHandler(button_MouseUp);
        //        button.Disposed += new EventHandler(button_Disposed);

        //        timer = new Timer();
        //        timer.Interval = interval;
        //        timer.Tick += new EventHandler(timer_Tick);
        //    }

        //    void button_MouseDown(object sender, MouseEventArgs e)
        //    {
        //        OnClick(EventArgs.Empty);
        //        timer.Start();
        //    }

        //    void button_MouseUp(object sender, MouseEventArgs e)
        //    {
        //        timer.Stop();
        //    }

        //    void button_Disposed(object sender, EventArgs e)
        //    {
        //        timer.Stop();
        //        timer.Dispose();
        //    }

        //    void timer_Tick(object sender, EventArgs e)
        //    {
        //        OnClick(EventArgs.Empty);
        //    }

        //    protected void OnClick(EventArgs e)
        //    {
        //        if (Click != null) Click(button, e);
        //    }
        //}
    }


       
    
}
