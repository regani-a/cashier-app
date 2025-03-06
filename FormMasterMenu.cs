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
    public partial class FormMasterMenu : Form
    {
        Koneksi konn = new Koneksi();
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        void kondisiAwal()
        {
            txtKodeMenu.Text = "";
            txtNamaMenu.Text = "";
            txtHargaMenu.Text = "";
            cmbKategoriMenu.Text = "";
            cmbKeterangan.Text = "";

            txtSearch.Text = "";
            cmbKategori.Text = "";
            munculDataMenu();
           
        }

        void munculDataMenu()
        {
            SqlConnection conn = konn.Getconn();
            conn.Open();
            cmd = new SqlCommand("select * from TBL_MENU", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TBL_MENU");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TBL_MENU";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }

        void kodeauto()
        {
            long hitung;
            string urutan;
            SqlConnection conn = konn.Getconn();
            conn.Open();
            cmd = new SqlCommand("select KodeMenu from TBL_MENU where KodeMenu in(select max(KodeMenu) from TBL_MENU) order by KodeMenu desc", conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                hitung = Convert.ToInt64(dr[0].ToString().Substring(dr["KodeMenu"].ToString().Length - 3, 3)) + 1;
                string kodeurut = "000" + hitung;
                urutan = "Mn" + kodeurut.Substring(kodeurut.Length - 3, 3);
            }
            else
            {
                urutan = "Mn001";
            }
            dr.Close();
            txtKodeMenu.Text = urutan;
            conn.Close();
        }

        public FormMasterMenu()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (txtKodeMenu.Text.Trim() == "" || txtNamaMenu.Text.Trim() == "" || txtHargaMenu.Text.Trim() == "" || cmbKategoriMenu.Text.Trim() == "" || cmbKeterangan.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi !");
            }
            else
            {
                SqlConnection conn = konn.Getconn();
                cmd = new SqlCommand("insert into TBL_MENU values('" + txtKodeMenu.Text + "','" + txtNamaMenu.Text + "','" + txtHargaMenu.Text + "','" + cmbKategoriMenu.Text + "','" + cmbKeterangan.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di input");
                kondisiAwal();
                Terkunci();
            }
        }


        private void FormMasterBarang_Load(object sender, EventArgs e)
        {
            Terkunci();
            kondisiAwal();
            kodeauto();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            txtNamaMenu.Text = "";
            txtHargaMenu.Text = "";
            cmbKategoriMenu.Text = "";
            cmbKeterangan.Text = "";
        }
        
        private void txtKodeMenu_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SqlConnection conn = konn.Getconn();
                cmd = new SqlCommand("select * from TBL_MENU where KodeMenu = '" + txtKodeMenu.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtKodeMenu.Text = dr[0].ToString();
                    txtNamaMenu.Text = dr[1].ToString();
                    txtHargaMenu.Text = dr[2].ToString();
                    cmbKategoriMenu.Text = dr[3].ToString();
                    cmbKeterangan.Text = dr[4].ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ada!");
                    kondisiAwal();
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKodeMenu.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtNamaMenu.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtHargaMenu.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            cmbKategoriMenu.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cmbKeterangan.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKodeMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtNamaMenu.Focus();
            }
        }

        private void txtNamaMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtKodeMenu.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                txtHargaMenu.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtHargaMenu.Focus();
            }
        }

        private void txtHargaMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtNamaMenu.Focus();
            }
        }

        private void txtHargaMenu_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void btnHapus_Click_1(object sender, EventArgs e)
        {
            if (txtKodeMenu.Text.Trim() == "" || txtNamaMenu.Text.Trim() == "" || txtHargaMenu.Text.Trim() == "" || cmbKategoriMenu.Text.Trim() == "" || cmbKeterangan.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi !");
            }
            else
            {
                SqlConnection conn = konn.Getconn();
                cmd = new SqlCommand("delete TBL_MENU where KodeMenu ='" + txtKodeMenu.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di hapus");
                kondisiAwal();
                Terkunci();
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (txtKodeMenu.Text.Trim() == "" || txtNamaMenu.Text.Trim() == "" || txtHargaMenu.Text.Trim() == "" || cmbKategoriMenu.Text.Trim() == "" || cmbKeterangan.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi !");
            }
            else
            {
                SqlConnection conn = konn.Getconn();
                cmd = new SqlCommand("update TBL_MENU set NamaMenu = '" + txtNamaMenu.Text + "',HargaMenu = '" + txtHargaMenu.Text + "',KategoriMenu = '" + cmbKategoriMenu.Text + "',Keterangan = '" + cmbKeterangan.Text + "'where KodeMenu = '" + txtKodeMenu.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di edit");
                kondisiAwal();
                Terkunci();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            ds = new DataSet();
            SqlConnection conn = konn.Getconn();
            conn.Open();
            da = new SqlDataAdapter("select * from TBL_MENU where NamaMenu like '%" + txtSearch.Text + "%' or KodeMenu like '%" + txtSearch.Text + "%'", conn);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

            txtKodeMenu.Clear();
            txtNamaMenu.Clear();
            txtHargaMenu.Clear();
            cmbKategoriMenu.Text = "";
            cmbKeterangan.Text = "";
        }
        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            ds = new DataSet();
            SqlConnection conn = konn.Getconn();
            conn.Open();
            da = new SqlDataAdapter("select * from TBL_MENU where KategoriMenu = '" + cmbKategori.Text + "'", conn);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        void Terkunci()
        {
            //e
            btnInput.Enabled = false;
            btnEdit.Enabled = false;

            txtKodeMenu.Enabled = false;
            txtNamaMenu.Enabled = false;
            txtHargaMenu.Enabled = false;
            cmbKategoriMenu.Enabled = false;
            cmbKeterangan.Enabled = false;

            button1.Visible = true;
            button2.Visible = true;
            btnHapus.Enabled = true;
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kodeauto();
            txtNamaMenu.Text = "";
            txtHargaMenu.Text = "";
            cmbKategoriMenu.Text = "";
            cmbKeterangan.Text = "";

            cmbKategori.Text = "";
            txtSearch.Text = "";

            txtNamaMenu.Enabled = true;
            txtHargaMenu.Enabled = true;
            cmbKategoriMenu.Enabled = true;
            cmbKeterangan.Enabled = true;           

            txtNamaMenu.Focus();

            button2.Enabled = false;
            btnHapus.Enabled = false;
            button3.Visible = true;

            //e
            btnInput.Enabled = true;

            button1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbKategori.Text = "";
            txtSearch.Text = "";

            txtNamaMenu.Enabled = true;
            txtHargaMenu.Enabled = true;
            cmbKategoriMenu.Enabled = true;
            cmbKeterangan.Enabled = true;

            txtNamaMenu.Focus();

            button1.Enabled = false;
            btnHapus.Enabled = false;
            button3.Visible = true;

            //e
            btnEdit.Enabled = true;

            button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kondisiAwal();
            Terkunci();
        }
    }
}
