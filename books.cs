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
    public partial class books : Form
    {
        public books()
        {
            InitializeComponent();
        }
        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\alnaseem\documents\visual studio 2012\Projects\LMS\LMS\Database1.mdf;Integrated Security=True");
        DataTable table = new DataTable();

        private void books_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdaper = new SqlDataAdapter("SELECT book_id,name,copies,takes,(select name from ths where ths_id = author )as 'author' FROM books", sc);
            dataAdaper.Fill(table);
            dataGridView1.DataSource = table;
            sc.Open();
            SqlCommand cmd = new SqlCommand("select name from ths", sc);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read()) {
                comboBox1.Items.Add(r[0].ToString());
            }
  
            sc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            sc.Open();
            SqlCommand nm = new SqlCommand("select ths_id from ths where name = '"+comboBox1.SelectedItem.ToString()+"'", sc);
            int num = Convert.ToInt16(nm.ExecuteScalar().ToString());

            sc.Close();

            sc.Open();
            SqlCommand cmd = new SqlCommand(
                "insert books VALUES ('"
                + bookName.Text + "','"+ cpoiesNum.Text +"',0,"+num+")", sc);
            cmd.ExecuteNonQuery();
            bookName.Clear();
            cpoiesNum.Clear();
            sc.Close();


            SqlDataAdapter dataAdaper = new SqlDataAdapter("SELECT book_id,name,(select name from ths where ths_id = author )as 'author' FROM books", sc);
            table = new DataTable();
            dataAdaper.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            authorEdit EditForm = new authorEdit(Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value), true);
            EditForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdaper = new SqlDataAdapter("SELECT book_id,name,copies,takes,(select name from ths where ths_id = author )as 'author' FROM books", sc);
            table = new DataTable();
            dataAdaper.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }        
  
    }
}
