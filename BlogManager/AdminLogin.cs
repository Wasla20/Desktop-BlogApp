using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogManager
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Enter Credentials");
            }
            else if(textBox1.Text != "admin" || textBox2.Text != "admin")
            {
                MessageBox.Show("Invalid Credentials");
            }
            else
            {
                Users user = new Users();
                user.Show();
                this.Hide();
            }
        }
    }
}
