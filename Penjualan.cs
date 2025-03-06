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
    public partial class Penjualan : Form
    {
        Koneksi konn = new Koneksi();
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        TransaksiPenjualan tp;
        void frmLogin_fromClosed(object sender, FormClosedEventArgs e)
        {
            tp = null;
        }

        public Penjualan()
        {
            InitializeComponent();
        }
        DateTime dt = DateTime.Now;
        
        void kondisiAwal()
        {
            munculDataTransaksiP();
        }
        
        private void Penjualan_Load(object sender, EventArgs e)
        {
            kondisiAwal();                                     
        }
        public void munculDataTransaksiP()
        {
            SqlConnection conn = konn.Getconn();
            conn.Open();
            cmd = new SqlCommand("select KdPenjualan,TglPenjualan,KodeUser,NamaUser,Total,Status from Tbl_CttPenjualan1", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Tbl_CttPenjualan1");
            dataGridViewPenjualan.DataSource = ds;
            dataGridViewPenjualan.DataMember = "Tbl_CttPenjualan1";
            dataGridViewPenjualan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPenjualan.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = dataGridViewPenjualan.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            if (tp == null)
            {
                tp = new TransaksiPenjualan();
                tp.FormClosed += new FormClosedEventHandler(frmLogin_fromClosed);
                tp.ShowDialog();
            }
            else
            {
                tp.Activate();
            }
            
        }      

        private void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            cmd = new SqlCommand("delete Tbl_CttPenjualan1 where KdPenjualan = '" + label1.Text + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data berhasil di hapus");
            kondisiAwal();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            ds = new DataSet();
            SqlConnection conn = konn.Getconn();
            conn.Open();
            da = new SqlDataAdapter("select KdPenjualan,TglPenjualan,KodeUser,NamaUser,Total,Status from Tbl_CttPenjualan1 where NamaKasir like '%" + txtSearch.Text + "%' or KdPenjualan like '%" + txtSearch.Text + "%'", conn);
            da.Fill(ds);
            dataGridViewPenjualan.DataSource = ds.Tables[0];
            conn.Close();
        }       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            munculDataTransaksiP();           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            String tglawal;
            dtp1.CustomFormat = "yyyy/MM/dd";
            dtp1.Format = DateTimePickerFormat.Custom;
            tglawal = dtp1.Text;
            lblAwal.Text = tglawal;
        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            String tglahir;
            dtp2.CustomFormat = "yyyy/MM/dd";
            dtp2.Format = DateTimePickerFormat.Custom;
            tglahir = dtp2.Text;
            lblAkhir.Text = tglahir;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            ds = new DataSet();
            SqlConnection conn = konn.Getconn();
            conn.Open();
            da = new SqlDataAdapter("select KdPenjualan,TglPenjualan,KodeUser,NamaUser,Total,Status from Tbl_CttPenjualan1 where TglPenjualan between '" + lblAwal.Text + "' and  '" + lblAkhir.Text + "'", conn);
            da.Fill(ds);
            dataGridViewPenjualan.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            LapPenjualan lp = new LapPenjualan();

            lp.Show();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd = new SqlCommand("select * from Tbl_CttPenjualan1", conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Tbl_CttPenjualan1");
            crLapPenjualan clp = new crLapPenjualan();
            clp.SetDataSource(ds);
            //nt.crystalReportViewer1.SelectionFormula = ""
            lp.crystalReportViewer1.ReportSource = clp;
            lp.crystalReportViewer1.Refresh();
            conn.Close();
        }

        private void dataGridViewPenjualan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
