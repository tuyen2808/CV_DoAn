using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    class KetNoi
    {
        string strconnect = @"Data Source=DESKTOP-PDJNB2D\SQLEXPRESS; Initial Catalog=QL;User ID=sa; Password=sql2012";
        public SqlConnection sqlcon;
        public SqlCommand sqlcom;
        public SqlDataAdapter sqlda;
        public SqlDataReader sqldr;
        public DataSet ds = new DataSet();
        public void ketnoi()
        {
            sqlcon = new SqlConnection(strconnect);
            sqlcon.Open();
        }

        public void ngatketnoi()
        {
            sqlcon.Close();
        }

        public void thucthiketnoi(string strsql)
        {
            ketnoi();
            sqlcom = new SqlCommand(strsql, sqlcon);
            sqlcom.ExecuteNonQuery();
            ngatketnoi();
        }

        public DataTable getDataTable(string sql, string tblName)
        {
            ketnoi();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            da.Fill(ds, tblName);
            ngatketnoi();
            return ds.Tables[tblName];
        }

        public SqlDataAdapter getDataAdapter(string sql, string tblName)
        {
            ketnoi();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            da.Fill(ds, tblName);
            ngatketnoi();
            return da;
        }

        public void loaddatagridview(DataGridView dg, string strselect)
        {
            ds.Clear();
            sqlda = new SqlDataAdapter(strselect, strconnect);
            sqlda.Fill(ds, "tenbang");
            dg.DataSource = ds.Tables[0];
        }

        public void loaddatagridview1(DataGridView dg, DataSet ds1, string strselect)
        {
            ds1.Clear();
            sqlda = new SqlDataAdapter(strselect, strconnect);
            sqlda.Fill(ds1, "tenbang");
            dg.DataSource = ds1.Tables[0];
        }

        public void loadcombobox(ComboBox cb, string strselect, byte chiso)
        {
            ketnoi();
            sqlcom = new SqlCommand(strselect, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                cb.Items.Add(sqldr[chiso].ToString());
            }
            ngatketnoi();
        }

        public void loadtextbox(TextBox cb, string strselect)
        {
            ketnoi();
            sqlcom = new SqlCommand(strselect, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                cb.Text = sqldr[0].ToString();
            }
            ngatketnoi();
        }

        public bool kttrungkhoa(string dauvao, string strsql)
        {
            bool ok = false;
            ketnoi();
            sqlcom = new SqlCommand(strsql, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                if (sqldr[0].ToString().ToLower() == dauvao.ToLower())
                    ok = true;
            }
            ngatketnoi();
            return ok;
        }

        public void loatextbox(TextBox tb, string strselect, byte chiso)
        {
            ketnoi();
            sqlcom = new SqlCommand(strselect, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                tb.Lines[0] = (sqldr[chiso].ToString());
            }
            ngatketnoi();
        }
    }
}
