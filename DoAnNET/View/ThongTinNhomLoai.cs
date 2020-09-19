using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyNhaSach;

namespace DoAnNET.View
{
    public partial class ThongTinNhomLoai : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_TTNL = new SqlDataAdapter();
        KetNoi cn = new KetNoi();
        public ThongTinNhomLoai()
        {
            InitializeComponent();
            LoadDataGridview_TTNL();
        }

        private void DataBingDing(DataTable tb)
        {
            txt_MaNL.DataBindings.Clear();
            txt_TenNL.DataBindings.Clear();
            txt_MaCL.DataBindings.Clear();
            txt_TenNL.DataBindings.Add("Text", tb, "TenNL");
            txt_MaNL.DataBindings.Add("Text", tb, "MaNL");
            txt_MaCL.DataBindings.Add("Text", tb, "MaCL");
        }

        public void LoadDataGridview_TTNL()
        {
            try
            {
                string sql = "select * from NhomLoai ";
                da_TTNL = cn.getDataAdapter(sql, "NL");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["NL"].Columns["MaNL"];
                cn.ds.Tables["NL"].PrimaryKey = primarykey;
                grid_CTNL.DataSource = cn.ds.Tables["NL"];
                DataBingDing(cn.ds.Tables["NL"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }
    }
}