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

namespace AppKasir
{
    public partial class FormLogActivity : Form
    {
        Koneksi konn = new Koneksi();
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        public FormLogActivity()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            ds = new DataSet();
            SqlConnection conn = konn.Getconn();
            conn.Open();
            da = new SqlDataAdapter("select * from TblLog where KodeUser like '%" + txtSearch.Text + "%' or Tanggal like '%" + txtSearch.Text + "%'", conn);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogActivity_Load(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            conn.Open();
            cmd = new SqlCommand("select * from TblLog", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TblLog");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TblLog";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }

       
    }
}
