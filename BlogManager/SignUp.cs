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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog='C:\Users\Hp User\Documents\BlogDB.mdf';Integrated Security=True;Connect Timeout=30");

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Fields cannot be left empty");
            }
            else if(textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Password does not match");
            }
            else
            {
                con.Open();
                try
                {

                    string query = "insert into [User](username,password,contact) values(@name,@pass,@contact)";
                    //string query = "insert into [User](username,password,contact) values(" + username.Text + ",'" + userpassword.Text + "'," + usercontact.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    cmd.Parameters.AddWithValue("@contact", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User saved successfully");

                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("User could not be saved. Error : " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
                Login lg = new Login();
                lg.Show();
                this.Hide();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
