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

namespace BlogManager
{
    public partial class BlogAdd : Form
    {
        public BlogAdd()
        {
            InitializeComponent();
        }

       
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog='C:\Users\Hp User\Documents\BlogDB.mdf';Integrated Security=True;Connect Timeout=30");
        public static string username = "";
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (title.Text == "" || description.Text == "" || author.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                con.Open();
                try
                {

                    string query = "insert into Blogs(title,description,author) values(@ti,@desc,@auth)";
                    //string query = "insert into [User](username,password,contact) values(" + username.Text + ",'" + userpassword.Text + "'," + usercontact.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ti", title.Text);
                    cmd.Parameters.AddWithValue("@desc", description.Text);
                    cmd.Parameters.AddWithValue("@auth", author.Text);
                    cmd.ExecuteNonQuery();
                    clear();
                    MessageBox.Show("Your Blog has been posted");

                    //populate();
                    //clear();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("User could not be saved. Error : " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

        
        }
        private void clear()
        {
            title.Text = "";
            description.Text = "";
            author.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Blogs b = new Blogs();
            b.Show();
            this.Hide();
        }

        private void BlogAdd_Load(object sender, EventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void description_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
