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
    public partial class LapPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_CTPN = new SqlDataAdapter();
        KetNoi cn = new KetNoi();
        public LapPhieuNhap()
        {
            InitializeComponent();
            LoadCboMaNCC();
            LoadCboMaNV();
            LoadCboSoPN();
            LoadDataGridview_CTPN();
        }

        private void DataBingDing(DataTable tb)
        {
            dateEdit_NgayLap.DataBindings.Clear();
            txt_GiaTri.DataBindings.Clear();
            txt_Thue.DataBindings.Clear();
            cbo_MaNCC.DataBindings.Clear();
            cbo_MaNV.DataBindings.Clear();
            txt_GiaTri.DataBindings.Add("Text", tb, "TongGiaTri");
            dateEdit_NgayLap.DataBindings.Add("Text", tb, "NgayLap_PN");
            txt_Thue.DataBindings.Add("Text", tb, "ThueXuat");
            cbo_MaNCC.DataBindings.Add("text", tb, "MaNCC");
            cbo_MaNV.DataBindings.Add("text", tb, "MaNV");
        }

        public void LoadCboSoPN()
        {
            try
            {
                string sql = "select * from PhieuNhap";
                DataTable dt = cn.getDataTable(sql, "PhieuNhap");
                cbo_SoPN.DataSource = dt;
                cbo_SoPN.DisplayMember = "SoPN";
                cbo_SoPN.ValueMember = "SoPN";
                DataBingDing(dt);
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
                string sql = "select * from NhanVien Where ChucVu = N'kế toán'";
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

        public void LoadDataGridview_CTPN()
        {
            try
            {
                string sql = "select * from CT_PhieuNhap ";
                da_CTPN = cn.getDataAdapter(sql, "CT_PhieuNhap");
                DataColumn[] primarykey = new DataColumn[2];
                primarykey[0] = cn.ds.Tables["CT_PhieuNhap"].Columns["SoPN"];
                primarykey[1] = cn.ds.Tables["CT_PhieuNhap"].Columns["MaTB"];
                cn.ds.Tables["CT_PhieuNhap"].PrimaryKey = primarykey;
                grid_CTPN.DataSource = cn.ds.Tables["CT_PhieuNhap"];
                cbo_SoPN.DataBindings.Clear();
                cbo_SoPN.DataBindings.Add("text", cn.ds.Tables["CT_PhieuNhap"],"SoPN");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }
    }
}