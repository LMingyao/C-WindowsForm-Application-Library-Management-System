using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject2021.BLL;
using FinalProject2021.DAL;
using System.Data.SqlClient;

namespace FinalProject2021.GUI
{
    public partial class InventoryController : Form
    {
        public InventoryController()
        {
            InitializeComponent();
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            Books boo = new Books();
            List<Books> ListBoo = boo.GetAllBooks();
            listViewBook.Items.Clear();
            if (ListBoo.Count != 0)
            {
                foreach (Books b_item in ListBoo)
                {
                    ListViewItem item = new ListViewItem(b_item.ISBN.ToString());
                    item.SubItems.Add(b_item.Title);
                    item.SubItems.Add(b_item.UnitPrice.ToString());
                    item.SubItems.Add(b_item.YearPublished);
                    item.SubItems.Add(b_item.QOH.ToString());
                    item.SubItems.Add(b_item.CategoryID.ToString());
                    item.SubItems.Add(b_item.PublisherID.ToString());
                    listViewBook.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Book list is empty!\nPlease enter Book data.", "No Book data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Books boo = new Books();
            boo.ISBN = textBoxISBN.Text.Trim();
            boo.Title = textBoxTitle.Text.Trim();
            boo.UnitPrice = Convert.ToInt32(textBoxUnitPrice.Text.Trim());
            boo.YearPublished = textBoxYearPublished.Text.Trim();
            boo.QOH = Convert.ToInt32(textBoxQOH.Text.Trim());
            boo.CategoryID = Convert.ToInt32(comboBoxCategoryID.Text.Trim());
            boo.PublisherID = Convert.ToInt32(comboBoxPublisherID.Text.Trim());
            boo.SaveBooks(boo);
            MessageBox.Show("Book Saved", "Confirmation");
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string input = textBoxInput.Text.Trim();
            Books boo = new Books();
            boo = boo.SearchBooks(input);
            if (boo != null)
            {
                textBoxISBN.Text = boo.ISBN.ToString();
                textBoxTitle.Text = boo.Title;
                textBoxUnitPrice.Text = boo.UnitPrice.ToString();
                textBoxYearPublished.Text = boo.YearPublished;
                textBoxQOH.Text = boo.QOH.ToString();
                comboBoxCategoryID.Text = boo.CategoryID.ToString();
                comboBoxPublisherID.Text = boo.PublisherID.ToString();
            }
            else
            {
                MessageBox.Show("Book not found!", "Invalid ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxInput.Clear();
                textBoxInput.Focus();
            }
        }

        private void buttonListAuthor_Click(object sender, EventArgs e)
            {
                Author au = new Author();
            List<Author> listau = au.GetAllAuthors();
            listViewAuthor.Items.Clear();
            if (listau.Count != 0)
            {
                foreach (Author au_item in listau)
                {
                    ListViewItem item = new ListViewItem(au_item.AuthorID.ToString());
                    item.SubItems.Add(au_item.FirstName);
                    item.SubItems.Add(au_item.LastName);
                    item.SubItems.Add(au_item.Email);
                    listViewAuthor.Items.Add(item);

                    
                }
            }
            else
            {
                MessageBox.Show("Author list is empty");
                return;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
           
        }

        private void InventoryController_Load(object sender, EventArgs e)
        {
            Author au = new Author();
            List<Author> listau = au.GetAllAuthors();
            foreach (Author a in listau)
            {
                comboBoxAuthorID.Items.Add(a.AuthorID);
            }
            Books boo = new Books();
            List<Books> ListBoo = boo.GetAllBooks();
           
            foreach (Books b in ListBoo)
            {
                comboBoxISBN.Items.Add(b.ISBN);
            }

            Publisher pb = new Publisher();
            List<Publisher> Listpb = pb.GetAllPublishers();
            foreach (Publisher p in Listpb)
            {
                comboBoxPublisherID.Items.Add(p.PublisherID);
            }


            Category ct = new Category();
            List<Category> Listct = ct.GetAllCategories();
            foreach (Category c in Listct)
            {
                comboBoxCategoryID.Items.Add(c.CategoryID);
            }
            
            if(comboBoxAuthorID.SelectedIndex == -1 || comboBoxPublisherID.SelectedIndex == -1)
            {
                buttonUpdate.Enabled = false;
            }
            else
            {
                buttonUpdate.Enabled = true;

            }
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.TopMost = true;
        }

        private void comboBoxISBN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonABList_Click(object sender, EventArgs e)
        {
            AuthorBook ab = new AuthorBook();
            List<AuthorBook> listab = ab.GetAllAuthorBooks();
            listViewAB.Items.Clear();
            if (listab.Count != 0)
            {
                foreach (AuthorBook ab_item in listab)
                {
                    ListViewItem item = new ListViewItem(ab_item.AuthorID.ToString());
                    item.SubItems.Add(ab_item.ISBN);
                    item.SubItems.Add(ab_item.YearPublished);
                    item.SubItems.Add(ab_item.Edition);
                    listViewAB.Items.Add(item);

                }
            }
            else
            {
                MessageBox.Show("Author Book list is empty");
                return;
            }
        }

        private void listViewAB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCList_Click(object sender, EventArgs e)
        {
            Category ct = new Category();
            List<Category> listct = ct.GetAllCategories();
            listViewCategory.Items.Clear();
            if (listct.Count != 0)
            {
                foreach (Category ct_item in listct)
                {
                    ListViewItem item = new ListViewItem(ct_item.CategoryID.ToString());
                    item.SubItems.Add(ct_item.CategoryName);
                    listViewCategory.Items.Add(item);

                }
            }
            else
            {
                MessageBox.Show("Category list is empty");
                return;
            }
            textBoxCCID.Enabled = true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainInterface mi = new MainInterface();
            mi.Show();
            this.Hide();
        }

        private void buttonUList_Click(object sender, EventArgs e)
        {

            Publisher pb = new Publisher();
            List<Publisher> listpb = pb.GetAllPublishers();
            listViewPublisher.Items.Clear();
            if (listpb.Count != 0)
            {
                foreach (Publisher pb_item in listpb)
                {
                    ListViewItem item = new ListViewItem(pb_item.PublisherID.ToString());
                    item.SubItems.Add(pb_item.PublisherName);
                    item.SubItems.Add(pb_item.WebAddress);
                    listViewPublisher.Items.Add(item);

                }
            }
            else
            {
                MessageBox.Show("Publisher list is empty");
                return;
            }
            textBoxPPID.Enabled = true;
        }

        private void buttonDeleteAuthor_Click(object sender, EventArgs e)
        {
            if (!(textBoxSearchAuthorID.Text == string.Empty))
            {
                SqlConnection conn = Utility.ConnectDB();
                string query = "Delete from Authors where AuthorID= '" + this.textBoxSearchAuthorID.Text + "'"
                    + "Delete from AuthorBooks where AuthorID= '" + this.textBoxSearchAuthorID.Text + "'";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader myreader;
                try
                {
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("The Author has been deleted successfully", "user information");
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
                MessageBox.Show("Please enter the Author ID which you want to delete", "User information");
            }
        }

        private void buttonSearchAuthor_Click(object sender, EventArgs e)
        {

            string input = textBoxSearchAuthorID.Text.Trim();
           

            Author au = new Author();
            au = au.SearchAuthor(Convert.ToInt32(input));
            if (au != null)
            {
                textBoxAuthorID.Text = au.AuthorID.ToString();
                textBoxFirstName.Text = au.FirstName;
                textBoxLastName.Text = au.LastName;
                textBoxEmail.Text = au.Email;
            }
            else
            {
                MessageBox.Show("Author not found");
                textBoxSearchAuthorID.Clear();
                textBoxSearchAuthorID.Focus();
                return;
            }
        }

        private void buttonABSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxSearchAB.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Search Method First.", "Error");
                return;
            }

            else if (comboBoxSearchAB.SelectedIndex == 0)
                //Search By Author ID
            {
                string input = textBoxABSearch.Text.Trim();
                
                AuthorBook ab = new AuthorBook();
                ab = ab.SearchABID(Convert.ToInt32(input));
                if (ab != null)
                {
                    comboBoxAuthorID.Text = ab.AuthorID.ToString();
                    comboBoxISBN.Text = ab.ISBN;
                    textBoxABYearPublished.Text = ab.YearPublished;
                    textBoxABEdition.Text = ab.Edition;
                }
                else
                {
                    MessageBox.Show("Author Book not found");
                    textBoxABSearch.Clear();
                    textBoxABSearch.Focus();
                    return;
                }
            }

            else if (comboBoxSearchAB.SelectedIndex == 1)
                //Search By ISBN
            {
                string input = textBoxABSearch.Text.Trim();

                AuthorBook ab = new AuthorBook();
                ab = ab.SearchISBN(input);
                if (ab != null)
                {
                    comboBoxAuthorID.Text = ab.AuthorID.ToString();
                    comboBoxISBN.Text = ab.ISBN;
                    textBoxABYearPublished.Text = ab.YearPublished;
                    textBoxABEdition.Text = ab.Edition;
                }
                else
                {
                    MessageBox.Show("Author Book not found");
                    textBoxABSearch.Clear();
                    textBoxABSearch.Focus();
                    return;
                }
            }
        }

        private void comboBoxSearchAB_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonADAdd_Click(object sender, EventArgs e)
        {
            AuthorBook ab = new AuthorBook();
            ab.AuthorID = Convert.ToInt32(comboBoxAuthorID.Text.Trim());
            ab.ISBN = comboBoxISBN.Text.Trim();
            ab.YearPublished = textBoxABYearPublished.Text.Trim();
            ab.Edition = textBoxABEdition.Text.Trim();
            ab.SaveAuthorBook(ab);
            MessageBox.Show("Author Book Saved", "Confirmation");
        }

        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            Author aut = new Author();
            aut.AuthorID = Convert.ToInt32(textBoxAuthorID.Text.Trim());
            aut.FirstName = textBoxFirstName.Text.Trim();
            aut.LastName = textBoxLastName.Text.Trim();
            aut.Email = textBoxEmail.Text.Trim();
            aut.SaveAuthors(aut);
            MessageBox.Show("Author Saved", "Confirmation");
        }

        private void buttonCAdd_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.CategoryID = Convert.ToInt32(textBoxCCID.Text.Trim());
            cat.CategoryName = textBoxCCName.Text.Trim();
            cat.SaveCategories(cat);
            MessageBox.Show("Category Saved", "Confirmation");
        }

        private void buttonPAdd_Click(object sender, EventArgs e)
        {
            Publisher pub = new Publisher();
            pub.PublisherID = Convert.ToInt32(textBoxPPID.Text.Trim());
            pub.PublisherName = textBoxPPName.Text.Trim();
            pub.WebAddress = textBoxPPWebAddress.Text.Trim();
            pub.SavePublishers(pub);
            MessageBox.Show("Publisher Saved", "Confirmation");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!(textBoxInput.Text == string.Empty))
            {
                SqlConnection conn = Utility.ConnectDB();
                //SqlCommand cmdInsert = new SqlCommand();
                //cmdInsert.Connection = conn;
                string query = "Delete from Books where ISBN= '" + this.textBoxInput.Text + "'" 
                    + "Delete from AuthorBooks where ISBN= '" + this.textBoxInput.Text + "'";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                
                SqlDataReader myreader;
                try
                {
                    //conn.Open();
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("The Book has been deleted successfully", "user information");
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
                MessageBox.Show("Please enter the ISBN which you want to delete", "User information");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonADUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            
            if (comboBoxAuthorID.SelectedIndex != -1 || comboBoxPublisherID.SelectedIndex != -1)
            {
                if (!(textBoxInput.Text == string.Empty))
                {
                    SqlConnection conn = Utility.ConnectDB();
                    //SqlCommand cmdInsert = new SqlCommand();
                    //cmdInsert.Connection = conn;
                    string query = "Delete from Books where ISBN= '" + this.textBoxInput.Text + "'"
                        + "Delete from AuthorBooks where ISBN= '" + this.textBoxInput.Text + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader myreader;
                    try
                    {
                        //conn.Open();
                        myreader = cmd.ExecuteReader();
                        MessageBox.Show("The Book has been Updated successfully", "user information");
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
                    MessageBox.Show("Please enter the ISBN which you want to Update", "User information");
                }

                Books boo = new Books();
                boo.ISBN = textBoxISBN.Text.Trim();
                boo.Title = textBoxTitle.Text.Trim();
                boo.UnitPrice = Convert.ToInt32(textBoxUnitPrice.Text.Trim());
                boo.YearPublished = textBoxYearPublished.Text.Trim();
                boo.QOH = Convert.ToInt32(textBoxQOH.Text.Trim());
                boo.CategoryID = Convert.ToInt32(comboBoxCategoryID.Text.Trim());
                boo.PublisherID = Convert.ToInt32(comboBoxPublisherID.Text.Trim());
                boo.SaveBooks(boo);
            }
            else
            {
                MessageBox.Show("First, Please Search first and then do the updating. " +
                    "\n\nSecond, Change or maintain the Category ID & Publisher ID by using these two combo boxses.", "Warning");
            }
        }

        private void comboBoxAuthorID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCategoryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPublisherID.SelectedIndex != -1)
            {
                buttonUpdate.Enabled = true;
            }
        }

        private void comboBoxPublisherID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategoryID.SelectedIndex != -1)
            {
                buttonUpdate.Enabled = true;
            }
          
        }

        private void buttonCSearch_Click(object sender, EventArgs e)
        {
            string input = textBoxSearchCategoryID.Text.Trim();
            Category ct = new Category();
            ct = ct.SearchCategoryID(Convert.ToInt32(input));
            if (ct != null)
            {
                textBoxCCID.Text = ct.CategoryID.ToString();
                textBoxCCName.Text = ct.CategoryName;
            }
            else
            {
                MessageBox.Show("Category not found");
                textBoxSearchCategoryID.Clear();
                textBoxSearchCategoryID.Focus();
                return;
            }
            textBoxCCID.Enabled = false;
        }

        private void buttonUSearch_Click(object sender, EventArgs e)
        {
            string input = textBoxSearchPublisherID.Text.Trim();
            Publisher pb = new Publisher();
            pb = pb.SearchPublisherID(Convert.ToInt32(input));
            if (pb != null)
            {
                textBoxPPID.Text = pb.PublisherID.ToString();
                textBoxPPName.Text = pb.PublisherName;
                textBoxPPWebAddress.Text = pb.WebAddress;
            }
            else
            {
                MessageBox.Show("Publisher not found");
                textBoxSearchPublisherID.Clear();
                textBoxSearchPublisherID.Focus();
                return;
            }
            textBoxPPID.Enabled = false;
        }

        private void textBoxCCName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonABDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxSearchAB.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Method First.", "Error");
                return;
            }

            else if (comboBoxSearchAB.SelectedIndex == 0)
            //Delete By Author ID
            {
                if (!(textBoxABSearch.Text == string.Empty))
                {
                    SqlConnection conn = Utility.ConnectDB();
                    string query = "Delete from AuthorBooks where AuthorID= '" + this.textBoxABSearch.Text + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader myreader;
                    try
                    {
                        myreader = cmd.ExecuteReader();
                        MessageBox.Show("The Author Book has been deleted successfully", "user information");
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
                    MessageBox.Show("Please enter the Author ID which you want to delete", "User information");
                }
            }

            else if (comboBoxSearchAB.SelectedIndex == 1)
            //Delete By ISBN
            {
                if (!(textBoxABSearch.Text == string.Empty))
                {
                    SqlConnection conn = Utility.ConnectDB();
                    string query = "Delete from AuthorBooks where ISBN= '" + this.textBoxABSearch.Text + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader myreader;
                    try
                    {
                        myreader = cmd.ExecuteReader();
                        MessageBox.Show("The Author Book has been deleted successfully", "user information");
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
                    MessageBox.Show("Please enter the ISBN which you want to delete", "User information");
                }
            }
        }

        private void buttonCDelete_Click(object sender, EventArgs e)
        {
            if (!(textBoxSearchCategoryID.Text == string.Empty))
            {
                SqlConnection conn = Utility.ConnectDB();
                string query = "Delete from Categories where CategoryID= '" + this.textBoxSearchCategoryID.Text + "'"
                     + "Delete from Books where CategoryID= '" + this.textBoxSearchCategoryID.Text + "'";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader myreader;
                try
                {
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("The Category has been deleted successfully", "user information");
                    while (myreader.Read())
                    {
                    }
                    conn.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("This category ID has been used in the Table Books, \n " +
                        "if you really want to delete this category, you need to delete the record of that book with this category ID","Warning");
                }
            }
            else
            {
                MessageBox.Show("Please enter the Category ID which you want to delete", "User information");
            }
            textBoxCCID.Enabled = true;
        }

        private void buttonUDelete_Click(object sender, EventArgs e)
        {

            if (!(textBoxSearchPublisherID.Text == string.Empty))
            {
                SqlConnection conn = Utility.ConnectDB();
                string query = "Delete from Publishers where PublisherID= '" + this.textBoxSearchPublisherID.Text + "'"
                     + "Delete from Books where PublisherID= '" + this.textBoxSearchPublisherID.Text + "'";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader myreader;
                try
                {
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("The Publsiher has been deleted successfully", "user information");
                    while (myreader.Read())
                    {
                    }
                    conn.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("This Publisher ID has been used in the Table Books, \n " +
                        "if you really want to delete this Publisher, you need to delete the record of that book with this Publisher ID", "Warning");
                }
            }
            else
            {
                MessageBox.Show("Please enter the Publisher ID which you want to delete", "User information");
            }
            textBoxPPID.Enabled = true;
        }

        private void buttonUpdateAuthor_Click(object sender, EventArgs e)
        {
            if (!(textBoxSearchAuthorID.Text == string.Empty))
            {
                SqlConnection conn = Utility.ConnectDB();
                string query = "Delete from Authors where AuthorID= '" + this.textBoxSearchAuthorID.Text + "'"
                    + "Delete from AuthorBooks where AuthorID= '" + this.textBoxSearchAuthorID.Text + "'";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader myreader;
                try
                {
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("The Author has been Updated successfully", "user information");
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
                MessageBox.Show("Please enter the Author ID which you want to Update", "User information");
            }

            Author aut = new Author();
            aut.AuthorID = Convert.ToInt32(textBoxAuthorID.Text.Trim());
            aut.FirstName = textBoxFirstName.Text.Trim();
            aut.LastName = textBoxLastName.Text.Trim();
            aut.Email = textBoxEmail.Text.Trim();
            aut.SaveAuthors(aut);


        }

        private void buttonCUpdate_Click(object sender, EventArgs e)
        {
            if (!(textBoxSearchCategoryID.Text == string.Empty))
            {
                SqlConnection conn = Utility.ConnectDB();
                string query = "UPDATE Categories SET CategoryName= '" + this.textBoxCCName.Text +"'"+" where CategoryID= '" + this.textBoxSearchCategoryID.Text + "'";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader myreader;
                try
                {
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("The Category has been Updated successfully", "user information");
                    while (myreader.Read())
                    {
                    }
                    conn.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("Category ID cannot be changed");
                    MessageBox.Show(ec.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter the Category ID which you want to update", "User information");
            }
        }

        private void buttonPUpdate_Click(object sender, EventArgs e)
        {
            if (!(textBoxSearchPublisherID.Text == string.Empty))
            {
                SqlConnection conn = Utility.ConnectDB();
                string query = "UPDATE Publishers SET PublisherName= '" + this.textBoxPPName.Text + "'" + " where PublisherID= '" + this.textBoxSearchPublisherID.Text + "'"+
                     "UPDATE Publishers SET WebAddress = '" + this.textBoxPPWebAddress.Text + "'" + " where PublisherID= '" + this.textBoxSearchPublisherID.Text + "'";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader myreader;
                try
                {
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("The Publisher has been Updated successfully", "user information");
                    while (myreader.Read())
                    {
                    }
                    conn.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("Publisher ID cannot be changed");
                    MessageBox.Show(ec.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter the Publisher ID which you want to update", "User information");
            }
            textBoxPPID.Enabled = true;
        }
    }
}
