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
    public partial class ThongTinKhachHang : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_DSKH = new SqlDataAdapter();
        KetNoi cn = new KetNoi();
        public ThongTinKhachHang()
        {
            InitializeComponent();
            LoadDataGridview_DSKH();
        }

        private void DataBingDing(DataTable tb)
        {
            txt_MaKH.DataBindings.Clear();
            txt_TenKH.DataBindings.Clear();
            txt_MST.DataBindings.Clear();
            txt_GioiTinh.DataBindings.Clear();
            txt_DiaChi.DataBindings.Clear();
            txt_SDT.DataBindings.Clear();
            txt_MaKH.DataBindings.Add("Text", tb, "MaKH");
            txt_TenKH.DataBindings.Add("Text", tb, "TenKH");
            txt_MST.DataBindings.Add("Text", tb, "MST");
            txt_GioiTinh.DataBindings.Add("Text", tb, "GioiTinh");
            txt_DiaChi.DataBindings.Add("Text", tb, "DiaChi");
            txt_SDT.DataBindings.Add("Text", tb, "SDT");
        }

        public void LoadDataGridview_DSKH()
        {
            try
            {
                string sql = "select * from KhachHang ";
                da_DSKH = cn.getDataAdapter(sql, "KH");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["KH"].Columns["MaKH"];
                cn.ds.Tables["KH"].PrimaryKey = primarykey;
                grid_DSKH.DataSource = cn.ds.Tables["KH"];
                DataBingDing(cn.ds.Tables["KH"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

    }
}