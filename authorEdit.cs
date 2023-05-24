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
    public partial class authorEdit : Form
    {
        int id;
        String tableName;
        String idName;
        public authorEdit(int id,bool isBook)
        {
            InitializeComponent();
            this.id = id;
            tableName = isBook? "books" : "ths";
            idName = isBook ? "book_id" : "ths_id";
        }
        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\alnaseem\documents\visual studio 2012\Projects\LMS\LMS\Database1.mdf;Integrated Security=True");
        private void authorEdit_Load(object sender, EventArgs e)
        {
            sc.Open();
            SqlCommand cmd = new SqlCommand("SELECT name FROM " + tableName + " WHERE " + idName + " = " + id, sc);
            textBox1.Text = cmd.ExecuteScalar().ToString();
            sc.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlCommand cmd = new SqlCommand("UPDATE " + tableName + " SET name = '" + textBox1.Text + "' WHERE " + idName + " =" + id, sc);
            cmd.ExecuteNonQuery();
            sc.Close();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM " + tableName + " WHERE " + idName + " =" + id, sc);
            cmd.ExecuteNonQuery();
            sc.Close();
            this.Hide();

        }
    }
}
