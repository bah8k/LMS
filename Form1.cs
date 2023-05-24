using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            home home = new home();
            home.TopLevel = false;
            centerPanel.Controls.Add(home);
            home.BringToFront();
            home.Show();
        }


        private void Authors_Click(object sender, EventArgs e)
        {
            Authors home = new Authors();
            home.TopLevel = false;
            centerPanel.Controls.Add(home);
            home.BringToFront();
            home.Show();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            home home = new home();
            home.TopLevel = false;
            centerPanel.Controls.Add(home);
            home.BringToFront();
            home.Show();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            books home = new books();
            home.TopLevel = false;
            centerPanel.Controls.Add(home);
            home.BringToFront();
            home.Show();
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            Authors home = new Authors();
            home.TopLevel = false;
            centerPanel.Controls.Add(home);
            home.BringToFront();
            home.Show();
        }
       

    }
}
