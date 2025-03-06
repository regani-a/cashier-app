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
    public partial class TransaksiPenjualan : Form
    {
        Koneksi konn = new Koneksi();
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        int total;
        int no = 0;

        public TransaksiPenjualan()
        {
            InitializeComponent();
        }
        DateTime dt = DateTime.Now;

        void repres()
        {     
            cmbKodeMenu.Text = "";
            lblNamaMenu.Text = "";
            lblHrgMenu.Text = "";
            txtJumlah.Text = "";
            
        }


        void munculDataTransaksi()
        {
            SqlConnection conn = konn.Getconn();
            conn.Open();
            cmd = new SqlCommand("select * from Tbl_Penjualan", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TBL_PENJUALAN1");
            dataGridView1.DataSource = ds;
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }
        void bersih()
        {
            total = 0;
            lblSubTotal.Text = "";
            repres();
            lblTotal.Text = "";
            dataGridView1.Rows.Clear();
        }
        
        private void lblkembali_Click(object sender, EventArgs e)
        {

        }

        private void TransaksiPenjualan_Load(object sender, EventArgs e)
        {
            BuatColumn();
            kodeauto();
            repres();
            
            SqlConnection conn = konn.Getconn();
            {
                cmd = new SqlCommand("select KodeMenu from TBL_MENU", conn);
                conn.Open();
                SqlDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    cmbKodeMenu.Items.Add(DR[0]);
                }
                conn.Close();
            }
            {
                cmd = new SqlCommand("select KodeUser from tbllogin", conn);
                conn.Open();
                SqlDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    cmbKodeUser.Items.Add(DR[0]);
                }
                conn.Close();
            }
            {
                cmd = new SqlCommand("select TglPenjualan from Tbl_Penjualan1", conn);
                conn.Open();
                SqlDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    txtTglTransaksi.Text = dt.ToString("yyyy/MM/dd");
                    
                }
            }    
        }       
        void BuatColumn()
        {
            dataGridView1.Columns.Clear(); 
            dataGridView1.Columns.Add("No", "No");
            dataGridView1.Columns.Add("NamaMenu", "Menu");
            dataGridView1.Columns.Add("HargaMenu", "Harga");
            dataGridView1.Columns.Add("Jumlah", "Jumlah");
            dataGridView1.Columns.Add("SubTotal", "SubTotal");
            dataGridView1.Columns.Add("TglPenjualan", "Tanggal");
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
            
        } 

        private void cmbKodeMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            cmd = new SqlCommand("select * from TBL_MENU where KodeMenu = '" + cmbKodeMenu.Text + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblKodeMenu.Text = dr[0].ToString();
                lblNamaMenu.Text = dr[1].ToString();
                lblHrgMenu.Text = dr[2].ToString();

                txtJumlah.Focus();
                lblSubTotal.Text = "";
            }
            else
            {
                MessageBox.Show("Data tidak ada!");
            }
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            cmd = new SqlCommand("select * from tbllogin where KodeUser = '" + cmbKodeUser.Text + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblNamaUser.Text = dr[1].ToString();
            }
            else
            {
                MessageBox.Show("Data tidak ada!");
            }
        }


        private void btnBayar_Click(object sender, EventArgs e)
        {
            int totalhrg = Convert.ToInt32(lblTotal.Text);
            int tunai = Convert.ToInt32(txtTunai.Text);

            if (tunai < totalhrg)
            {
                MessageBox.Show("Kurrrang!");
            }
            else if (tunai == 0)
            {
                MessageBox.Show("Berapa?");
            }
            else
            {
                int kembalian = tunai - totalhrg;
                lblKembalian.Text = Convert.ToString(kembalian);
            }
          
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbKodeMenu.Text.Trim() == "" || lblNamaMenu.Text.Trim() == "" || lblHrgMenu.Text.Trim() == "" || txtJumlah.Text.Trim() == "" || lblSubTotal.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi !");
            }
            else
            {
                int hargabarang = Convert.ToInt32(lblHrgMenu.Text);
                int jumlah = Convert.ToInt32(txtJumlah.Text);

                int subtotal = hargabarang * jumlah;
                lblSubTotal.Text = Convert.ToString(subtotal);
                total += subtotal;
                lblTotal.Text = Convert.ToString(total);

                no += 1;
                dataGridView1.Rows.Add(no, lblNamaMenu.Text, lblHrgMenu.Text, txtJumlah.Text, lblSubTotal.Text, txtTglTransaksi.Text);
                dataGridView1.Refresh();

                SqlConnection conn = konn.Getconn();
                cmd = new SqlCommand("insert into Tbl_Penjualan1 values('" + no + "','" + cmbKodeMenu.Text + "','" + lblNamaMenu.Text + "','" + lblHrgMenu.Text + "','" + txtJumlah.Text + "','" + lblSubTotal.Text + "','" + txtTglTransaksi.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();               
                repres();                            
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BuatColumn();
            kodeauto();
            repres();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNoTransaksi.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            cmbKodeMenu.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            lblNamaMenu.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            lblHrgMenu.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtJumlah.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            lblSubTotal.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtTglTransaksi.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        void kodeauto()
        {
            long hitung;
            string urutan;
            SqlConnection conn = konn.Getconn();
            conn.Open();
            cmd = new SqlCommand("select KdPenjualan from Tbl_CttPenjualan1 where KdPenjualan in(select max(KdPenjualan) from Tbl_CttPenjualan1) order by KdPenjualan desc", conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                hitung = Convert.ToInt64(dr[0].ToString().Substring(dr["KdPenjualan"].ToString().Length - 3, 3)) + 1;
                string kodeurut = "000" + hitung;
                urutan = "KdP" + kodeurut.Substring(kodeurut.Length - 3, 3);
            }
            else
            {
                urutan = "KdP001";
            }
            dr.Close();
            lblKdTran.Text = urutan;
            conn.Close();
        }
    
        private void btnProses_Click(object sender, EventArgs e)
        { 
            if (cmbKodeUser.Text.Trim() == "" || lblNamaUser.Text.Trim() == "" || lblKodeMenu.Text.Trim() == "" || lblTotal.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi !");
            }
            else
            {              
                string status = "Terbayar";
                SqlConnection conn = konn.Getconn();
                cmd = new SqlCommand("insert into Tbl_CttPenjualan1 values('" + lblKdTran.Text + "','" + txtTglTransaksi.Text + "','" + cmbKodeUser.Text + "','" + lblNamaUser.Text + "','" + lblKodeMenu.Text + "','" + lblTotal.Text + "','" + status + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Catatan Tersimpan");
                BuatColumn();
                kodeauto();
                repres();
            }
        }

        private void bayarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            cmd = new SqlCommand("delete Tbl_Penjualan1 where No ='" + no + "'", conn); /*txtNoTransaksi.Text*/
            //("delete Tbl_Penjualan where No like '%" + no + "%'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            repres();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            Nota nt = new Nota();

            nt.Show();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd = new SqlCommand("select * from Tbl_Penjualan1", conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Tbl_Penjualan1");
            crNota cnt = new crNota();
            cnt.SetDataSource(ds);
            //nt.crystalReportViewer1.SelectionFormula = ("totext({Tbl_Penjualan.No}) = '" + lblNamaMenu.Text + "'");
            nt.crystalReportViewer1.ReportSource = cnt;
            nt.crystalReportViewer1.Refresh();
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtJumlah_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJumlah_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSimpan_Click(sender, e);
            }
        }

        private void txtJumlah_KeyPress(object sender, KeyPressEventArgs e)
        {
            int hargabarang = Convert.ToInt32(lblHrgMenu.Text);
            int jumlah = Convert.ToInt32(txtJumlah.Text);

            int subtotal = hargabarang * jumlah;
            lblSubTotal.Text = Convert.ToString(subtotal);

            //int hargabarang = Convert.ToInt32(lblHrgMenu.Text);
            //int jumlah = int.Parse(txtJumlah.Text);

            //int subtotal = hargabarang * jumlah;
            //lblSubTotal.Text = subtotal.ToString();
        }
    }
}
