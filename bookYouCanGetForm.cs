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
    public partial class bookYouCanGetForm : Form
    {
        int id;
        public bookYouCanGetForm(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\alnaseem\documents\visual studio 2012\Projects\LMS\LMS\Database1.mdf;Integrated Security=True");
        private void bookYouCanGetForm_Load(object sender, EventArgs e)
        {

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter("select * from books where copies > 0",sc);
            DataTable dt = new DataTable();
            sqlDataAdap.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AreUAgree fm = new AreUAgree(id,0,true,Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[2].Value),
                Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value));
            fm.Show();
        }

    
    }
}
