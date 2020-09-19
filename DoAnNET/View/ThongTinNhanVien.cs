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
    public partial class ThongTinNhanVien : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_DSNV = new SqlDataAdapter();
        KetNoi cn = new KetNoi();
        public ThongTinNhanVien()
        {
            InitializeComponent();
            LoadDataGridview_DSNV();
        }

        private void DataBingDing(DataTable tb)
        {
            txt_MaNV.DataBindings.Clear();
            txt_TenNV.DataBindings.Clear();
            txt_ChucVu.DataBindings.Clear();
            txt_GioiTinh.DataBindings.Clear();
            txt_DiaChi.DataBindings.Clear();
            txt_SDT.DataBindings.Clear();
            txt_MaNV.DataBindings.Add("Text", tb, "MaNV");
            txt_TenNV.DataBindings.Add("Text", tb, "TenNV");
            txt_ChucVu.DataBindings.Add("Text", tb, "ChucVu");
            txt_GioiTinh.DataBindings.Add("Text", tb, "GioiTinh");
            txt_DiaChi.DataBindings.Add("Text", tb, "DiaChi");
            txt_SDT.DataBindings.Add("Text", tb, "SDT");
        }

        public void LoadDataGridview_DSNV()
        {
            try
            {
                string sql = "select * from NhanVien ";
                da_DSNV = cn.getDataAdapter(sql, "NV");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["NV"].Columns["MaNV"];
                cn.ds.Tables["NV"].PrimaryKey = primarykey;
                grid_DSNV.DataSource = cn.ds.Tables["NV"];
                DataBingDing(cn.ds.Tables["NV"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }
    }
}