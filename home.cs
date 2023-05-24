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
    public partial class home : Form
    {
        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\alnaseem\documents\visual studio 2012\Projects\LMS\LMS\Database1.mdf;Integrated Security=True");

        public home()
        {
            InitializeComponent();
        }

        private void home_Load(object sender, EventArgs e)
        {

            sc.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(name)FROM users", sc);
            bookNumber.Text = cmd.ExecuteScalar().ToString();
            cmd = new SqlCommand("SELECT COUNT(name)FROM ths", sc);
            label4.Text = cmd.ExecuteScalar().ToString();
            cmd = new SqlCommand("SELECT COUNT(name)FROM books", sc);
            label2.Text = cmd.ExecuteScalar().ToString();
            cmd = new SqlCommand("SELECT COUNT(*)FROM taken", sc);
            label6.Text = cmd.ExecuteScalar().ToString();
            

            SqlDataAdapter dataAdaper = new SqlDataAdapter("SELECT user_id as الرقم,name as الاسم, username as 'اسم المستخدم',password as 'كلمة السر' FROM users", sc);
            DataTable table = new DataTable();
            dataAdaper.Fill(table);
            dataGridView1.DataSource = table;

            sc.Close();

          

        }

        private void panel3_Click(object sender, EventArgs e)
        {

            SqlDataAdapter dataAdaper = new SqlDataAdapter("SELECT book_id as الرقم,name as 'اسم الكتاب',copies as 'مجموع النسخ',takes as 'النسخ المستعارة',(copies-takes) as 'النسخ المتبقية',(select name from ths where ths_id = author )as 'اسم المؤلف' FROM books", sc);
            DataTable table = new DataTable();
            dataAdaper.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdaper = new SqlDataAdapter("SELECT user_id as الرقم,name as الاسم, username as 'اسم المستخدم',password as 'كلمة السر' FROM users", sc);
            DataTable table = new DataTable();
            dataAdaper.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdaper = new SqlDataAdapter("SELECT ths_id as الرقم,name as 'اسم المؤلف' FROM ths", sc);
            DataTable table = new DataTable();
            dataAdaper.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdaper = new SqlDataAdapter("SELECT taken_id as 'رقم الاستعارة',(select name from books where book_id = book_idin ) as 'اسم الكتاب',(select name from users where user_id = user_idin ) as 'اسم المستخدم الي اسعتار'  FROM taken", sc);
            DataTable table = new DataTable();
            dataAdaper.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    
 


    }
}
