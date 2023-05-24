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
    public partial class yourBookForm : Form
    {
        int id;
        public yourBookForm(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\alnaseem\documents\visual studio 2012\Projects\LMS\LMS\Database1.mdf;Integrated Security=True");

        private void yourBookForm_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter("select taken_id as 'رقم الاستعارة',(select name from books where book_id = book_idin)as'اسم الكتاب' from taken where user_idin = " + id, sc);
            DataTable dt = new DataTable();
            sqlDataAdap.Fill(dt);
            dataGridView1.DataSource = dt;

        }

    
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sc.Open();
            SqlCommand cmd = new SqlCommand("select book_idin from taken where taken_id =" + Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value).ToString(),sc);
            int book_idd = Convert.ToInt16(cmd.ExecuteScalar());
            sc.Close();

            sc.Open();
            cmd = new SqlCommand("select copies from books where book_id = (select book_idin from taken where taken_id =" + Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value).ToString() + ")", sc);
            int x = Convert.ToInt16(cmd.ExecuteScalar());
            sc.Close();
            AreUAgree fm = new AreUAgree(id, Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value), false, x, book_idd);
            fm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
