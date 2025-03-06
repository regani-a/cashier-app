using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AppKasir
{
    class Koneksi
    {
        public SqlConnection Getconn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source=DESKTOP-SJ37Q4L\\RG;Initial Catalog=hah;Integrated Security=True";
            return Conn;
        }
    }
}
