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
    public partial class DanhMucHoaDon : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_DMHD = new SqlDataAdapter();
        KetNoi cn = new KetNoi();
        public DanhMucHoaDon()
        {
            InitializeComponent();
            LoadDataGridview_DMHD();
            LoadCboSoHD();
            LoadCboMaKH();
            LoadCboMaNV();
        }

        public void LoadCboSoHD()
        {
            try
            {
                string sql = "select * from HoaDon";
                DataTable dt = cn.getDataTable(sql, "HoaDon");
                cbo_SoHD.DataSource = dt;
                cbo_SoHD.DisplayMember = "SoHD";
                cbo_SoHD.ValueMember = "SoHD";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        public void LoadCboMaKH()
        {
            try
            {
                string sql = "select * from KhachHang";
                DataTable dt = cn.getDataTable(sql, "KhachHang");
                cbo_MaKH.DataSource = dt;
                cbo_MaKH.DisplayMember = "TenKH";
                cbo_MaKH.ValueMember = "MaKH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }
        public void LoadCboMaNV()
        {
            try
            {
                string sql = "select * from NhanVien";
                DataTable dt = cn.getDataTable(sql, "NhanVien");
                cbo_MaNV.DataSource = dt;
                cbo_MaNV.DisplayMember = "TenNV";
                cbo_MaNV.ValueMember = "MaNV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        public void LoadDataGridview_DMHD()
        {
            try
            {
                String sql = "select * from HoaDon";
                da_DMHD = cn.getDataAdapter(sql, "HoaDon1");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["HoaDon1"].Columns["SoHD"];
                cn.ds.Tables["HoaDon1"].PrimaryKey = primarykey;
                grid_CTHD.DataSource = cn.ds.Tables["HoaDon1"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }

        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (rdo_SoHD.Checked == true)
            {
                cn.ds.Tables["HoaDon1"].Clear();
                string sql = "select * from HoaDon where SoHD = '" + cbo_SoHD.SelectedValue + "'";
                da_DMHD = cn.getDataAdapter(sql, "HoaDon1");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["HoaDon1"].Columns["SoHD"];
                cn.ds.Tables["HoaDon1"].PrimaryKey = primarykey;
                grid_CTHD.DataSource = cn.ds.Tables["HoaDon1"];
            }
            else if (rdo_MaNV.Checked == true)
            {
                cn.ds.Tables["HoaDon1"].Clear();
                string sql = "select * from HoaDon where MaNV = '" + cbo_MaNV.SelectedValue + "'";
                da_DMHD = cn.getDataAdapter(sql, "HoaDon1");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["HoaDon1"].Columns["SoHD"];
                cn.ds.Tables["HoaDon1"].PrimaryKey = primarykey;
                grid_CTHD.DataSource = cn.ds.Tables["HoaDon1"];
            }
            else if (rdo_MaKH.Checked == true)
            {
                cn.ds.Tables["HoaDon1"].Clear();
                string sql = "select * from HoaDon where MaKH = '" + cbo_MaKH.SelectedValue + "'";
                da_DMHD = cn.getDataAdapter(sql, "HoaDon1");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["HoaDon1"].Columns["SoHD"];
                cn.ds.Tables["HoaDon1"].PrimaryKey = primarykey;
                grid_CTHD.DataSource = cn.ds.Tables["HoaDon1"];
            }
            else if (rdo_NgayLap.Checked == true)
            {
                cn.ds.Tables["HoaDon1"].Clear();
                string sql = "select * from HoaDon where NgayLap_HD = '" + DateEdit_NgayLap.Text + "'";
                da_DMHD = cn.getDataAdapter(sql, "HoaDon1");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["HoaDon1"].Columns["SoHD"];
                cn.ds.Tables["HoaDon1"].PrimaryKey = primarykey;
                grid_CTHD.DataSource = cn.ds.Tables["HoaDon1"];
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string id = gV_CTHD.GetRowCellValue(gV_CTHD.FocusedRowHandle, gV_CTHD.Columns[0]).ToString();
                String sql = "delete from CT_HoaDon where SoHD = '" + id + "'";
                cn.thucthiketnoi(sql);
                cn.ds.Tables["HoaDon"].Clear();
                string delete = "delete from HoaDon where SoHD = '" + id + "'";
                da_DMHD = cn.getDataAdapter(delete, "HoaDon");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["HoaDon"].Columns["SoHD"];
                cn.ds.Tables["HoaDon"].PrimaryKey = primarykey;
                grid_CTHD.DataSource = cn.ds.Tables["HoaDon"];
                LoadDataGridview_DMHD();
            }
        }

        private void gV_CTHD_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void rdo_SoHD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_SoHD.Checked == true)
            {
                cbo_MaNV.Enabled = false;
                cbo_MaKH.Enabled = false;
                DateEdit_NgayLap.Enabled = false;
                cbo_SoHD.Enabled = true;
            }
            else if (rdo_MaNV.Checked == true)
            {
                cbo_SoHD.Enabled = false;
                cbo_MaKH.Enabled = false;
                DateEdit_NgayLap.Enabled = false;
                cbo_MaNV.Enabled = true;
            }
            else if (rdo_MaKH.Checked == true)
            {
                cbo_MaKH.Enabled = true;
                cbo_SoHD.Enabled = false;
                cbo_MaNV.Enabled = false;
                DateEdit_NgayLap.Enabled = false;
            }
            else if (rdo_NgayLap.Checked == true)
            {
                DateEdit_NgayLap.Enabled = true;
                cbo_SoHD.Enabled = false;
                cbo_MaNV.Enabled = false;
                cbo_MaKH.Enabled = false;
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            DateEdit_NgayLap.Enabled = true;
            cbo_SoHD.Enabled = true;
            cbo_MaNV.Enabled = true;
            cbo_MaKH.Enabled = true;
        }

    }

    
}