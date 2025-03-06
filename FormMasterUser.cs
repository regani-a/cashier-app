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
    public partial class FormMasterUser : Form
    {
        Koneksi konn = new Koneksi();
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        void kondisiAwal()
        {
            txtKodeUser.Text = "";
            txtNamaUser.Text = "";
            txtPassword.Text = "";
            cmbLevelUser.Text = "";

            txtSearch.Text = "";
            cmbLevel.Text = "";
            munculDataUser();

        }
        public FormMasterUser()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtKodeUser.Text.Trim() == "" || txtNamaUser.Text.Trim() == "" || txtPassword.Text.Trim() == "" || cmbLevelUser.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi !");
            }
            else
            {
                SqlConnection conn = konn.Getconn();
                cmd = new SqlCommand("update tbllogin set NamaUser = '" + txtNamaUser.Text + "',Password = '" + txtPassword.Text + "',LevelUser = '" + cmbLevelUser.Text + "'where KodeUser = '" + txtKodeUser.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di edit");
                kondisiAwal();
                Terkunci();
            }
        }
        private void btnTutup_Click(object sender, EventArgs e)
        {
            txtNamaUser.Text = "";
            txtPassword.Text = "";
            cmbLevelUser.Text = "";
        }

        void munculDataUser()
        {
            SqlConnection conn = konn.Getconn();
            conn.Open();
            cmd = new SqlCommand("select * from tbllogin", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tbllogin");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbllogin";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }

        void kodeauto()
        {
            long hitung;
            string urutan;
            SqlConnection conn = konn.Getconn();
            conn.Open();
            cmd = new SqlCommand("select KodeUser from tbllogin where KodeUser in(select max(KodeUser) from tbllogin) order by KodeUser desc", conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                hitung = Convert.ToInt64(dr[0].ToString().Substring(dr["KodeUser"].ToString().Length - 3, 3)) + 1;
                string kodeurut = "000" + hitung;
                urutan = "USR" + kodeurut.Substring(kodeurut.Length - 3, 3);
            }
            else
            {
                urutan = "USR001";
            }
            dr.Close();
            txtKodeUser.Text = urutan;
            conn.Close();
        }
      

        private void FormMasterKasir_Load(object sender, EventArgs e)
        {
            Terkunci();
            kondisiAwal();
            kodeauto();           
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (txtKodeUser.Text.Trim() == "" || txtNamaUser.Text.Trim() == "" || txtPassword.Text.Trim() == "" || cmbLevelUser.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi !");
            }
            else
            {
                SqlConnection conn = konn.Getconn();
                cmd = new SqlCommand("insert into tbllogin values('" + txtKodeUser.Text + "','" + txtNamaUser.Text + "','" + txtPassword.Text + "','" + cmbLevelUser.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di input");
                kondisiAwal();
                Terkunci();
            }
        }
        private void txtKodeKasir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SqlConnection conn = konn.Getconn();
                cmd = new SqlCommand("select * from tbllogin where KodeUser = '" + txtKodeUser.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtKodeUser.Text = dr[0].ToString();
                    txtNamaUser.Text = dr[1].ToString();
                    txtPassword.Text = dr[2].ToString();
                    cmbLevelUser.Text = dr[3].ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ada!");
                    kondisiAwal();
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtKodeUser.Text.Trim() == "" || txtNamaUser.Text.Trim() == "" || txtPassword.Text.Trim() == "" || cmbLevelUser.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi !");
            }
            else
            {
                SqlConnection conn = konn.Getconn();
                cmd = new SqlCommand("delete tbllogin where KodeUser ='" + txtKodeUser.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di hapus");
                kondisiAwal();
                Terkunci();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKodeUser.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtNamaUser.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtPassword.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            cmbLevelUser.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKodeUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtNamaUser.Focus();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtKodeUser.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtNamaUser.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            ds = new DataSet();
            SqlConnection conn = konn.Getconn();
            conn.Open();
            da = new SqlDataAdapter("select * from tbllogin where NamaUser like '%" + txtSearch.Text + "%' or KodeUser like '%" + txtSearch.Text + "%'", conn);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
            
            txtKodeUser.Clear();
            txtNamaUser.Clear();
            txtPassword.Clear();
            cmbLevelUser.Text = "";
            cmbLevel.Text = "";
        }
       
        private void cmbUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            ds = new DataSet();
            SqlConnection conn = konn.Getconn();
            conn.Open();
            da = new SqlDataAdapter("select * from tbllogin where LevelUser = '" + cmbLevel.Text + "'", conn);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                e.Value = new string ('*',e.Value.ToString().Length);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                checkBox1.Checked = false;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        void Terkunci()
        {
            //e
            btnInput.Enabled = false;
            btnEdit.Enabled = false;

            txtKodeUser.Enabled = false;
            txtNamaUser.Enabled = false;
            txtPassword.Enabled = false;
            cmbLevelUser.Enabled = false;

            button1.Visible = true;
            button2.Visible = true;
            btnHapus.Enabled = true;
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kodeauto();
            txtNamaUser.Text = "";
            txtPassword.Text = "";
            cmbLevelUser.Text = "";
            
            cmbLevel.Text = "";
            txtSearch.Text = "";

            txtNamaUser.Enabled = true;
            txtPassword.Enabled = true;
            cmbLevelUser.Enabled = true;
            txtNamaUser.Focus();

            button2.Enabled = false;
            btnHapus.Enabled = false;
            button3.Visible = true;

            //e
            btnInput.Enabled = true;

            button1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbLevel.Text = "";
            txtSearch.Text = "";

            txtNamaUser.Enabled = true;
            txtPassword.Enabled = true;
            cmbLevelUser.Enabled = true;
            txtNamaUser.Focus();

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
