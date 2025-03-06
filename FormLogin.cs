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
    public partial class FormLogin : Form
    {
        private SqlCommand cmd;
        private DataSet dt;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        String namauser, status, id;

        Koneksi Konn = new Koneksi();
        
        public FormLogin()
        {
            InitializeComponent();
        }

        void login()
        {
            String log = "Log-in";
            DateTime dt = DateTime.Now;
            String tgl = dt.ToString();
            SqlConnection conn = Konn.Getconn();
            cmd = new SqlCommand("insert into TblLog values('" + textBox1.Text + "','" + log + "','" + tgl + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Konn.Getconn();

            conn.Open();
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Masukan data!");
            }
            else
            {
                login();
                FormMenuUtama frm = new FormMenuUtama();              
                da = new SqlDataAdapter("select * from tbllogin where KodeUser = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "'", conn);
                DataTable dtbl = new DataTable();
                da.Fill(dtbl);
                
                if (dtbl.Rows.Count > 0)
                {
                    
                    foreach (DataRow drow in dtbl.Rows)
                    {
                        
                        if (drow["LevelUser"].ToString() == "Admin")
                        {
                            
                            frm.Show();                           

                            frm.btnDataMaster.Enabled = true;
                            frm.btnTransaksi.Enabled = true;
                            frm.btnLaporan.Enabled = true;
                            frm.btnLainnya.Enabled = true;
                            frm.btnAbout.Enabled = true;
                            frm.btnLogin.Visible = false;
                            frm.btnLogout.Visible = true;
                            
                            this.Close();
                        }
                        
                        else if (drow["LevelUser"].ToString() == "Manager")
                        {
                            
                            frm.Show();
                            
                            frm.btnDataMaster.Enabled = true;
                            frm.btnUser.Enabled = false;
                            frm.btnTransaksi.Enabled = true;
                            frm.btnLaporan.Enabled = true;
                            frm.btnLainnya.Enabled = true;
                            frm.btnGantiPw.Enabled = false;
                            frm.btnAbout.Enabled = true;
                            frm.btnLogin.Visible = false;
                            frm.btnLogout.Visible = true;

                            this.Close();
                            
                        }
                        else if (drow["LevelUser"].ToString() == "Kasir")
                        {
                            
                            frm.Show();

                            frm.btnDataMaster.Enabled = false;
                            frm.btnTransaksi.Enabled = true;
                            frm.btnLaporan.Enabled = false;
                            frm.btnLainnya.Enabled = true;
                            frm.btnGantiPw.Enabled = false;
                            frm.btnLog.Enabled = false;
                            frm.btnAbout.Enabled = true;
                            frm.btnLogin.Visible = false;
                            frm.btnLogout.Visible = true;

                            this.Close();
                            
                        }
                        namauser = drow["NamaUser"].ToString();
                        status = drow["LevelUser"].ToString();
                        id = drow["KodeUser"].ToString();                       

                    }
                    frm.lblNamaUser.Text = namauser;
                    frm.lblStatus.Text = status;
                    frm.lblKodeUser.Text = id;
                    
                }

                else
                {
                    MessageBox.Show("Ada Kesalahan!");
                }
                conn.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMenuUtama back = new FormMenuUtama();
            back.Show();
            
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                checkBox1.Checked = false;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                textBox2.Clear();
                pictureBox5.Image = Properties.Resources.pass2;
                panel3.BackColor = Color.FromArgb(137, 140, 197);
                textBox2.ForeColor = Color.FromArgb(137, 140, 197);

            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);    
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            pictureBox6.Image = Properties.Resources.usr2;
            panel2.BackColor = Color.FromArgb(137, 140, 197);
            textBox1.ForeColor = Color.FromArgb(137, 140, 197);

            pictureBox5.Image = Properties.Resources.pass1;
            panel3.BackColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.WhiteSmoke;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            pictureBox5.Image = Properties.Resources.pass2;
            panel3.BackColor = Color.FromArgb(137, 140, 197);
            textBox2.ForeColor = Color.FromArgb(137, 140, 197);

            pictureBox6.Image = Properties.Resources.usr1;
            panel2.BackColor = Color.WhiteSmoke;
            textBox1.ForeColor = Color.WhiteSmoke;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            pictureBox6.Image = Properties.Resources.usr1;
            panel2.BackColor = Color.WhiteSmoke;
            textBox1.ForeColor = Color.WhiteSmoke;

            pictureBox5.Image = Properties.Resources.pass1;
            panel3.BackColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.WhiteSmoke;
        }

        
    }
}
