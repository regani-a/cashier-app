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
    public partial class FormMenuUtama : Form
    {
        public static FormMenuUtama menu;

        Koneksi konn = new Koneksi();
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        FormLogin frmLogin;

        void frmLogin_fromClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin = null;
        }
        FormMasterUser frmUser;
        void frmUser_fromClosed(object sender, FormClosedEventArgs e)
        {
            frmUser = null;
        }
        FormMasterMenu frmMenu;
        void frmMenu_fromClosed(object sender, FormClosedEventArgs e)
        {
            frmMenu = null;
        }
        Penjualan penjualan;
        void trskpenjualan_fromClosed(object sender,FormClosedEventArgs e)
        {
            penjualan = null;
        }
        FormGantiPassword gpw;
        void gpw_fromClosed(object sender, FormClosedEventArgs e)
        {
            gpw = null;
        }
        FormLogActivity fla;
        void fla_fromClosed(object sender, FormClosedEventArgs e)
        {
            fla = null;
        }

        void MenuTerkunci()
        {            
            btnDataMaster.Enabled = false;
            btnTransaksi.Enabled = false;
            btnLaporan.Enabled = false;
            btnLainnya.Enabled = false;
            btnAbout.Enabled = true;
            btnLogin.Visible = true;
            btnLogout.Visible = false;
            lblSelected7.Visible = false;
            lblNamaUser.Text = "Nama User";
            lblStatus.Text = "Status";
            lblKodeUser.Text = "";
            menu = this;
        }
       

        public FormMenuUtama()
        {
            InitializeComponent();
        }

        private void FormMenuUtama_Load(object sender, EventArgs e)
        {
            MenuTerkunci();          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnDataMaster_Click(object sender, EventArgs e)
        {
            lblSelected1.Visible = true;
            lblSelected2.Visible = false;
            lblSelected3.Visible = false;
            lblSelected4.Visible = false;
            lblSelected5.Visible = false;
            lblSelected6.Visible = false;
            lblSelected7.Visible = false;

            pnlDataMaster.Visible = true;
            pnlTransaksi.Visible = false;
            pnlLaporan.Visible = false;
            pnlLainnya.Visible = false;
            pnlAbout.Visible = false;


        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            lblSelected1.Visible = false;
            lblSelected2.Visible = true;
            lblSelected3.Visible = false;
            lblSelected4.Visible = false;
            lblSelected5.Visible = false;
            lblSelected6.Visible = false;
            lblSelected7.Visible = false;

            pnlDataMaster.Visible = false;
            pnlTransaksi.Visible = true;
            pnlLaporan.Visible = false;
            pnlLainnya.Visible = false;
            pnlAbout.Visible = false;

        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            lblSelected1.Visible = false;
            lblSelected2.Visible = false;
            lblSelected3.Visible = true;
            lblSelected4.Visible = false;
            lblSelected5.Visible = false;
            lblSelected6.Visible = false;
            lblSelected7.Visible = false;

            pnlDataMaster.Visible = false;
            pnlTransaksi.Visible = false;
            pnlLaporan.Visible = true;
            pnlLainnya.Visible = false;
            pnlAbout.Visible = false;
        }

        private void btnLainnya_Click(object sender, EventArgs e)
        {
            lblSelected1.Visible = false;
            lblSelected2.Visible = false;
            lblSelected3.Visible = false;
            lblSelected4.Visible = true;
            lblSelected5.Visible = false;
            lblSelected6.Visible = false;
            lblSelected7.Visible = false;

            pnlDataMaster.Visible = false;
            pnlTransaksi.Visible = false;
            pnlLaporan.Visible = false;
            pnlLainnya.Visible = true;
            pnlAbout.Visible = false;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            lblSelected1.Visible = false;
            lblSelected2.Visible = false;
            lblSelected3.Visible = false;
            lblSelected4.Visible = false;
            lblSelected5.Visible = true;
            lblSelected6.Visible = false;
            lblSelected7.Visible = false;

            pnlDataMaster.Visible = false;
            pnlTransaksi.Visible = false;
            pnlLaporan.Visible = false;
            pnlLainnya.Visible = false;
            pnlAbout.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblSelected1.Visible = false;
            lblSelected2.Visible = false;
            lblSelected3.Visible = false;
            lblSelected4.Visible = false;
            lblSelected5.Visible = false;
            lblSelected6.Visible = true;
            lblSelected7.Visible = false;

            pnlDataMaster.Visible = false;
            pnlTransaksi.Visible = false;
            pnlLaporan.Visible = false;
            pnlLainnya.Visible = false;
            pnlAbout.Visible = false;

            if (frmLogin == null)
            {
                frmLogin = new FormLogin();
                frmLogin.FormClosed += new FormClosedEventHandler(frmLogin_fromClosed);
                frmLogin.ShowDialog();
            }
            else
            {
                frmLogin.Activate();
            }
            this.Hide();
        }

        void logout()
        {
            String log = "Log-out";
            DateTime dt = DateTime.Now;
            String tgl = dt.ToString();
            SqlConnection conn = konn.Getconn();
            cmd = new SqlCommand("insert into TblLog values('" + lblKodeUser.Text + "','" + log + "','" + tgl + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            logout();
            lblSelected1.Visible = false;
            lblSelected2.Visible = false;
            lblSelected3.Visible = false;
            lblSelected4.Visible = false;
            lblSelected5.Visible = false;
            lblSelected6.Visible = false;
            lblSelected7.Visible = true;

            pnlDataMaster.Visible = false;
            pnlTransaksi.Visible = false;
            pnlLaporan.Visible = false;
            pnlLainnya.Visible = false;
            pnlAbout.Visible = false;

            MenuTerkunci();
        }

        void logopuser()
        {
            String log = "Open Master Data User";
            DateTime dt = DateTime.Now;
            String tgl = dt.ToString();
            SqlConnection conn = konn.Getconn();
            cmd = new SqlCommand("insert into TblLog values('" + lblKodeUser.Text + "','" + log + "','" + tgl + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            logopuser();
            if (frmUser == null)
            {
                frmUser = new FormMasterUser();
                frmUser.FormClosed += new FormClosedEventHandler(frmUser_fromClosed);
                frmUser.ShowDialog();
            }
            else
            {
                frmUser.Activate();
            }
        }

        void logopmenu()
        {
            String log = "Open Master Data Menu";
            DateTime dt = DateTime.Now;
            String tgl = dt.ToString();
            SqlConnection conn = konn.Getconn();
            cmd = new SqlCommand("insert into TblLog values('" + lblKodeUser.Text + "','" + log + "','" + tgl + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            logopmenu();
            if (frmMenu == null)
            {
                frmMenu = new FormMasterMenu();
                frmMenu.FormClosed += new FormClosedEventHandler(frmMenu_fromClosed);
                frmMenu.ShowDialog();
            }
            else
            {
                frmMenu.Activate();
            }
        }

        void logoppenju()
        {
            String log = "Open Catatan Penjualan";
            DateTime dt = DateTime.Now;
            String tgl = dt.ToString();
            SqlConnection conn = konn.Getconn();
            cmd = new SqlCommand("insert into TblLog values('" + lblNamaUser.Text + "','" + log + "','" + tgl + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private void btnPenjualan_Click(object sender, EventArgs e)
        {
            logoppenju();
            if (penjualan == null)
            {
                penjualan = new Penjualan();
                penjualan.FormClosed += new FormClosedEventHandler(trskpenjualan_fromClosed);
                penjualan.ShowDialog();
            }
            else
            {
                penjualan.Activate();
            }
        }

        void logopgpw()
        {
            String log = "Open Form Ganti Password";
            DateTime dt = DateTime.Now;
            String tgl = dt.ToString();
            SqlConnection conn = konn.Getconn();
            cmd = new SqlCommand("insert into TblLog values('" + lblKodeUser.Text + "','" + log + "','" + tgl + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private void btnGantiPw_Click(object sender, EventArgs e)
        {
            logopgpw();
            if (gpw == null)
            {
                gpw = new FormGantiPassword();
                gpw.FormClosed += new FormClosedEventHandler(gpw_fromClosed);
                gpw.ShowDialog();
            }
            else
            {           
                gpw.Activate();               
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblNamaUser_Click(object sender, EventArgs e)
        {

        }

        void logoplapPendapatan()
        {
            String log = "Open Laporan Pendapatan";
            DateTime dt = DateTime.Now;
            String tgl = dt.ToString();
            SqlConnection conn = konn.Getconn();
            cmd = new SqlCommand("insert into TblLog values('" + lblKodeUser.Text + "','" + log + "','" + tgl + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private void btnLapPendapatan_Click(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            LapPendapatan lpt = new LapPendapatan();

            logoplapPendapatan();
            lpt.Show();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd = new SqlCommand("select * from Tbl_CttPenjualan", conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Tbl_CttPenjualan");
            crLapPendapatan clpt = new crLapPendapatan();
            clpt.SetDataSource(ds);
            //nt.crystalReportViewer1.SelectionFormula = ""
            lpt.crystalReportViewer1.ReportSource = clpt;
            lpt.crystalReportViewer1.Refresh();
            conn.Close();
        }

        void logoplapUser()
        {
            String log = "Open Laporan Data User";
            DateTime dt = DateTime.Now;
            String tgl = dt.ToString();
            SqlConnection conn = konn.Getconn();
            cmd = new SqlCommand("insert into TblLog values('" + lblKodeUser.Text + "','" + log + "','" + tgl + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private void btnLapUser_Click(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            LapDataUser ldu = new LapDataUser();

            logoplapUser();
            ldu.Show();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd = new SqlCommand("select * from tbllogin", conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "tbllogin");
            crLapDataUser cldu = new crLapDataUser();
            cldu.SetDataSource(ds);
            ldu.crystalReportViewer1.ReportSource = cldu;
            ldu.crystalReportViewer1.Refresh();
            conn.Close();
        }

        void logoplapMenu()
        {
            String log = "Open Laporan Data Menu";
            DateTime dt = DateTime.Now;
            String tgl = dt.ToString();
            SqlConnection conn = konn.Getconn();
            cmd = new SqlCommand("insert into TblLog values('" + lblKodeUser.Text + "','" + log + "','" + tgl + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private void btnLapMenu_Click(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            LapDataMenu ldm = new LapDataMenu();

            logoplapMenu();
            ldm.Show();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd = new SqlCommand("select * from TBL_MENU", conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "TBL_MENU");
            crLapDataMenu cldm = new crLapDataMenu();
            cldm.SetDataSource(ds);
            ldm.crystalReportViewer1.ReportSource = cldm;
            ldm.crystalReportViewer1.Refresh();
            conn.Close();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (fla == null)
            {
                fla = new FormLogActivity();
                fla.FormClosed += new FormClosedEventHandler(fla_fromClosed);
                fla.ShowDialog();
            }
            else
            {
                fla.Activate();
            }
        }
 

    }
}
