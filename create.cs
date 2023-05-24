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
    public partial class create : Form
    {
        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\alnaseem\documents\visual studio 2012\Projects\LMS\LMS\Database1.mdf;Integrated Security=True");
        public create()
        {
            InitializeComponent();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login singIn = new login();
            this.Hide();
            singIn.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(name.Text == "" || password.Text == "" || repassword.Text == "" || username.Text == ""))
            {

                if (password.Text != repassword.Text) {
                    MessageBox.Show("The password not match !!");
                    return;
                }

                if (password.Text.Length < 6)
                {
                    MessageBox.Show("The password very short");
                    return;
                }

                //sing uppppppppppp
                sc.Open();
                SqlCommand cmd = new SqlCommand(
                    "insert into users VALUES ('"
                    + name.Text + "','" + username.Text + "','" +
                    password.Text + "')", sc);
                cmd.ExecuteNonQuery();
                sc.Close();

                userForm dashBord = new userForm(username.Text.ToString());
                this.Hide();
                dashBord.Show();

            }
            else {
                MessageBox.Show("All fields required");
            }
        }


    }
}
