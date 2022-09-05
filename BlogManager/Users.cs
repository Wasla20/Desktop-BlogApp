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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            populate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog='C:\Users\Hp User\Documents\BlogDB.mdf';Integrated Security=True;Connect Timeout=30");
        

        private void populate()
        {
            con.Open();
            try
            {
                string query = "select * from [User]";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                var dataset = new DataSet();
                sda.Fill(dataset);
                UsersView.DataSource = dataset.Tables[0];
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(username.Text == "" || userpassword.Text == "" || usercontact.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                con.Open();
                try
                {
                    
                    string query = "insert into [User](username,password,contact) values(@name,@pass,@contact)";
                    //string query = "insert into [User](username,password,contact) values(" + username.Text + ",'" + userpassword.Text + "'," + usercontact.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", username.Text);
                    cmd.Parameters.AddWithValue("@pass", userpassword.Text);
                    cmd.Parameters.AddWithValue("@contact", usercontact.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User saved successfully");
                    con.Close();
                    populate();
                    clear();

                }
                catch(Exception ex)
                {
                    //MessageBox.Show("User could not be saved. Error : " + ex.Message);
                }
               /* finally
                {
                    con.Close();
                }
               */
            }
        }
        private void clear()
        {
            username.Text = "";
            userpassword.Text = "";
            usercontact.Text = "";
            Key = 0;
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }
        int Key = 0;
        private void UsersView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            username.Text = UsersView.SelectedRows[0].Cells[1].Value.ToString();
            userpassword.Text = UsersView.SelectedRows[0].Cells[2].Value.ToString();
            usercontact.Text = UsersView.SelectedRows[0].Cells[3].Value.ToString();
            if(username.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(UsersView.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if(Key == 0)
            {
                MessageBox.Show("Select User to be deleted");
            }
            else
            {
                con.Open();
                try
                {

                    string query = "delete from [User] where userID = "+Key+";";
                    SqlCommand cmd = new SqlCommand(query, con);                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User deleted successfully");
                    con.Close();
                    populate();
                    clear();


                }
                catch (Exception ex)
                {
                   // MessageBox.Show("User could not be deleted. Error : " + ex.Message);
                }
               /* finally
                {
                    con.Close();
                }
               */
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || userpassword.Text == "" || usercontact.Text == "")
            {
                MessageBox.Show("Select a user to update!");
            }
            else
            {
                con.Open();
                try
                {

                    string query = "update [User] set username='"+username.Text+"',password='"+userpassword.Text+"',contact='"+usercontact.Text+"' where userID="+Key+";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User updated successfully");
                    con.Close();
                    populate();
                    clear();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("User could not be updated. Error : " + ex.Message);
                }
         
                   
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }
    }
}
