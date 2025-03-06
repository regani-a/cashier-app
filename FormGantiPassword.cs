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
    public partial class FormGantiPassword : Form
    {
        public FormGantiPassword()
        {
            InitializeComponent();
        }
        Koneksi konn = new Koneksi();
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;


        private void txtPwLama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SqlConnection conn = konn.Getconn();
                cmd = new SqlCommand("select * from tbllogin where Password = '" + txtPwLama.Text + "'", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtPwBaru.Enabled = true;
                    txtKonfirPwBaru.Enabled = true;

                    txtPwBaru.Focus();
                }
                else
                {
                    MessageBox.Show("Password Lama Salah!");
                    txtPwLama.Text = "";
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 

        private void btnGanti_Click(object sender, EventArgs e)
        {
            if (txtPwBaru.Text.Trim() == "" || txtKonfirPwBaru.Text.Trim() == "")
            {
                MessageBox.Show("Masukan Password Baru!");
            }
            else
            {
                if (txtPwBaru.Text != txtKonfirPwBaru.Text)
                {
                    MessageBox.Show("Password baru dan Konfirmasi harus sama");
                    txtPwBaru.Text = "";
                    txtKonfirPwBaru.Text = "";
                    txtPwBaru.Focus();
                }
                else
                {
                    
                    SqlConnection conn = konn.Getconn();
                    string gantipw = "update tbllogin set Password ='" + txtKonfirPwBaru.Text + "' where Password = '" + txtPwLama.Text + "'";
                    cmd = new SqlCommand(gantipw, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Password berhasil diganti");

                }
            }

        }

        private void txtPwBaru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKonfirPwBaru.Focus();
            }
        }

        private void txtKonfirPwBaru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGanti_Click(sender, e);
            }
        }

        private void FormGantiPassword_Load(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPwLama.UseSystemPasswordChar = true;
                txtPwBaru.UseSystemPasswordChar = true;
                txtKonfirPwBaru.UseSystemPasswordChar = true;
            }
            else
            {
                txtPwLama.UseSystemPasswordChar = false;
                txtPwBaru.UseSystemPasswordChar = false;
                txtKonfirPwBaru.UseSystemPasswordChar = false;
            }
        }
    }
}
