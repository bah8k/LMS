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

namespace LMS
{
    public partial class login : Form
    {
        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\alnaseem\documents\visual studio 2012\Projects\LMS\LMS\Database1.mdf;Integrated Security=True");
        public login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            create singUp = new create();
            this.Hide();
            singUp.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (username.Text == "admin" && password.Text == "admin") {

                Form1 dashBord = new Form1();
                this.Hide();
                dashBord.Show();

                return;
            }

            //login
            sc.Open();
            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(name)FROM users WHERE username = '"
                + username.Text+ "'" + 
                "and password ='"+password.Text+"'",sc);

            if (cmd.ExecuteScalar().ToString() == "0") MessageBox.Show("Login fild");
            else
            {
                userForm dashBord = new userForm(username.Text.ToString());
                this.Hide();
                dashBord.Show();
                
            }
          

            sc.Close();



        }

    }
}
