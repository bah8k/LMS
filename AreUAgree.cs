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
    public partial class AreUAgree : Form
    {
        bool isAdd;
        int userId;
        int bookId;
        int cop;
        int takenId;
        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\alnaseem\documents\visual studio 2012\Projects\LMS\LMS\Database1.mdf;Integrated Security=True");
        public AreUAgree(int userId, int takenId, bool isAdd, int cop, int bookId = 0)
        {
            InitializeComponent();
            this.userId = userId;
            this.bookId = bookId;
            this.isAdd = isAdd;
            this.cop = cop;
            this.takenId = takenId;
        }

        private void AreUAgree_Load(object sender, EventArgs e)
        {
            label1.Text = isAdd ? "هل تريد استعارة الكتاب ؟ " : "هل تريد اعادة الكتاب ؟ ";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                sc.Open();
                SqlCommand cmd = new SqlCommand("update books set copies = " + (cop - 1).ToString() + "where book_id = " + bookId, sc);
                cmd.ExecuteNonQuery();
                sc.Close();

                sc.Open();
                cmd = new SqlCommand("insert into taken values('" + bookId + "','" + userId + "')", sc);
                cmd.ExecuteNonQuery();
                sc.Close();


                this.Hide();

            }
            else {


                sc.Open();
                SqlCommand cmd = new SqlCommand("update books set copies = " + (cop + 1).ToString() + "where book_id = " + bookId, sc);
                cmd.ExecuteNonQuery();
                sc.Close();
                sc.Open();
                cmd = new SqlCommand("DELETE FROM taken WHERE taken_id = " + takenId, sc);
                cmd.ExecuteNonQuery();
                sc.Close();
                this.Hide();




            }
        }
    }
}
