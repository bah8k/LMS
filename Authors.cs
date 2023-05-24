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
    public partial class Authors : Form
    {
        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\alnaseem\documents\visual studio 2012\Projects\LMS\LMS\Database1.mdf;Integrated Security=True");
        public Authors()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlCommand cmd = new SqlCommand(
                "insert ths VALUES ('"
                + authorNme.Text + "')", sc);
            cmd.ExecuteNonQuery();
            authorNme.Clear();
            sc.Close();


            SqlDataAdapter dataAdaper = new SqlDataAdapter("SELECT ths_id as id ,name FROM ths", sc);
            table = new DataTable();
            dataAdaper.Fill(table);
            dataGridView1.DataSource = table;

        }

         DataTable table = new DataTable();

        private void Authors_Load(object sender, EventArgs e)
        {

            SqlDataAdapter dataAdaper = new SqlDataAdapter("SELECT ths_id as id ,name FROM ths", sc);
            dataAdaper.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {
            MessageBox.Show(e.RowIndex.ToString());
        }

 

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            authorEdit EditForm = new authorEdit(Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value),false);
            EditForm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdaper = new SqlDataAdapter("SELECT ths_id as id ,name FROM ths", sc);
            table = new DataTable();
            dataAdaper.Fill(table);
            dataGridView1.DataSource = table;
        }



    }
}
