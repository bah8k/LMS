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
    public partial class userForm : Form
    {
        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\alnaseem\documents\visual studio 2012\Projects\LMS\LMS\Database1.mdf;Integrated Security=True");
        String user;
        int id;
        public userForm(String user)
        {
            InitializeComponent();
            this.user = user;
            sc.Open();
            SqlCommand cmd = new SqlCommand("select user_id from users where userName = '"+user+"'",sc);
            id = Convert.ToInt16(cmd.ExecuteScalar());
            sc.Close();
            //
        }
        private void userForm_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            yourBookForm home = new yourBookForm(id);
            home.TopLevel = false;
            centerPanel.Controls.Add(home);
            home.BringToFront();
            home.Show();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            bookYouCanGetForm home = new bookYouCanGetForm(id);
            home.TopLevel = false;
            centerPanel.Controls.Add(home);
            home.BringToFront();
            home.Show();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Click(object sender, EventArgs e)
        {
            this.Close();
        }


 

   
      
    }
}
