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
    public partial class DanhMucPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_DMPN = new SqlDataAdapter();
        KetNoi cn = new KetNoi();

        public DanhMucPhieuNhap()
        {
            InitializeComponent();
            LoadCboMaNCC();
            LoadCboMaNV();
            LoadCboSoPN();
            LoadDataGridview_DMPN();
        }

        public void LoadCboSoPN()
        {
            try
            {
                string sql = "select * from PhieuNhap";
                DataTable dt = cn.getDataTable(sql, "PN");
                cbo_SoPN.DataSource = dt;
                cbo_SoPN.DisplayMember = "SoPN";
                cbo_SoPN.ValueMember = "SoPN";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        public void LoadCboMaNCC()
        {
            try
            {
                string sql = "select * from NHACUNGCAP ";
                DataTable dt = cn.getDataTable(sql, "NHACUNGCAP");
                cbo_MaNCC.DataSource = dt;
                cbo_MaNCC.DisplayMember = "TenNCC";
                cbo_MaNCC.ValueMember = "MaNCC";

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
                string sql = "select * from NhanVien where ChucVu = N'kế toán'";
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

        public void LoadDataGridview_DMPN()
        {
            try
            {
                string sql = "select * from PhieuNhap";
                da_DMPN = cn.getDataAdapter(sql,"PhieuNhap");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["PhieuNhap"].Columns["SoPN"];
                cn.ds.Tables["PhieuNhap"].PrimaryKey = primarykey;
                grid_CTPN.DataSource = cn.ds.Tables["PhieuNhap"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (rdo_SoPN.Checked == true)
            {
                cn.ds.Tables["PhieuNhap"].Clear();
                string sql = "select * from PhieuNhap where SoPN = '" + cbo_SoPN.SelectedValue + "'";
                da_DMPN = cn.getDataAdapter(sql, "PhieuNhap");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["PhieuNhap"].Columns["SoPN"];
                cn.ds.Tables["PhieuNhap"].PrimaryKey = primarykey;
                grid_CTPN.DataSource = cn.ds.Tables["PhieuNhap"];
            }
            else if (rdo_MaNV.Checked == true)
            {
                cn.ds.Tables["PhieuNhap"].Clear();
                string sql = "select * from PhieuNhap where MaNV = '" + cbo_MaNV.SelectedValue + "'";
                da_DMPN = cn.getDataAdapter(sql, "PhieuNhap");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["PhieuNhap"].Columns["SoPN"];
                cn.ds.Tables["PhieuNhap"].PrimaryKey = primarykey;
                grid_CTPN.DataSource = cn.ds.Tables["PhieuNhap"];
            }
            else if (rdo_NhaCungCap.Checked == true)
            {
                cn.ds.Tables["PhieuNhap"].Clear();
                string sql = "select * from PhieuNhap where MaNV = '" + cbo_MaNCC.SelectedValue + "'";
                da_DMPN = cn.getDataAdapter(sql, "PhieuNhap");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["PhieuNhap"].Columns["SoPN"];
                cn.ds.Tables["PhieuNhap"].PrimaryKey = primarykey;
                grid_CTPN.DataSource = cn.ds.Tables["PhieuNhap"];
            }
            else if (rdo_NgayLap.Checked == true)
            {
                cn.ds.Tables["PhieuNhap"].Clear();
                string sql = "select * from HoaDon where NgayLap_PN = '" + dateEdit_NgayLap.Text + "'";
                da_DMPN = cn.getDataAdapter(sql, "PhieuNhap");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["PhieuNhap"].Columns["SoPN"];
                cn.ds.Tables["PhieuNhap"].PrimaryKey = primarykey;
                grid_CTPN.DataSource = cn.ds.Tables["PhieuNhap"];
            }
        }

        private void rdo_SoPN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_SoPN.Checked == true)
            {
                cbo_MaNV.Enabled = false;
                cbo_MaNCC.Enabled = false;
                dateEdit_NgayLap.Enabled = false;
                cbo_SoPN.Enabled = true;
            }
            else if (rdo_MaNV.Checked == true)
            {
                cbo_SoPN.Enabled = false;
                cbo_MaNCC.Enabled = false;
                dateEdit_NgayLap.Enabled = false;
                cbo_MaNV.Enabled = true;
            }
            else if (rdo_NhaCungCap.Checked == true)
            {
                cbo_SoPN.Enabled = false;
                cbo_MaNV.Enabled = false;
                dateEdit_NgayLap.Enabled = false;
                cbo_MaNCC.Enabled = true;
            }
            else if (rdo_NgayLap.Checked == true)
            {
                cbo_SoPN.Enabled = false;
                cbo_MaNV.Enabled = false;
                cbo_MaNCC.Enabled = false;
                dateEdit_NgayLap.Enabled = true;
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string id = gV_CTPN.GetRowCellValue(gV_CTPN.FocusedRowHandle, gV_CTPN.Columns[0]).ToString();
                String sql = "delete from CT_Phieuhap where SoPN = '" + id + "'";
                cn.thucthiketnoi(sql);
                cn.ds.Tables["PhieuNhap"].Clear();
                string delete = "delete from PhieuNhap where SoPN = '" + id + "'";
                da_DMPN = cn.getDataAdapter(delete, "PhieuNhap");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["PhieuNhap"].Columns["SoPN"];
                cn.ds.Tables["PhieuNhap"].PrimaryKey = primarykey;
                grid_CTPN.DataSource = cn.ds.Tables["PhieuNhap"];
                LoadDataGridview_DMPN();
            }
        }

        private void gV_CTPN_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            cbo_SoPN.Enabled = true;
            cbo_MaNV.Enabled = true;
            cbo_MaNCC.Enabled = true;
            dateEdit_NgayLap.Enabled = true;
        }

    }
}