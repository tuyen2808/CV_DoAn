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
    public partial class LapPhieuChi : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_LPC = new SqlDataAdapter();
        KetNoi cn = new KetNoi();
        char TrangThai = '0';
        public LapPhieuChi()
        {
            InitializeComponent();
            LoadCboMaNV();
            LoadCboSoPC();
            LoadCboSoPN();
            LoadDataGridview_CTPC();
        }

        private void LapPhieuChi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDataSet2.PHIEUCHI' table. You can move, or remove it, as needed.

        }
        private void DataBingDing(DataTable tb)
        {
            dateEdit_NgayLap.DataBindings.Clear();
            txt_LyDoChi.DataBindings.Clear();
            txt_SoTien.DataBindings.Clear();
            cbo_SoPN.DataBindings.Clear();
            txt_LyDoChi.DataBindings.Add("Text", tb, "LyDoChi");
            dateEdit_NgayLap.DataBindings.Add("Text", tb, "NgayLap_PC");
            txt_SoTien.DataBindings.Add("Text", tb, "SoTienChi");
            cbo_SoPN.DataBindings.Add("text",tb,"SoPN");
        }

        public void LoadCboSoPC()
        {
            try
            {
                string sql = "select * from PhieuChi";
                DataTable dt = cn.getDataTable(sql, "PhieuChi");
                cbo_SoPC.DataSource = dt;
                cbo_SoPC.DisplayMember = "SoPC";
                cbo_SoPC.ValueMember = "SoPC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
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
                cbo_MaNV.DataBindings.Clear();
                cbo_MaNV.DataBindings.Add("text",dt,"MaNV");
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

        public void LoadDataGridview_CTPC()
        {
            try
            {
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["PhieuChi"].Columns["SoPC"];
                cn.ds.Tables["PhieuChi"].PrimaryKey = primarykey;
                grid_CTPC.DataSource = cn.ds.Tables["PhieuChi"];
                DataBingDing(cn.ds.Tables["PhieuChi"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }

        }

        public void XoaTextBox()
        {
            txt_SoPC.Text = txt_LyDoChi.Text = txt_SoTien.Text = txtTenNSX.Text = null;
        }

        public void DisTextBox(bool e)
        {
            txtDiaChi.Enabled = txtMaNSX.Enabled = txtSDT.Enabled = txtTenNSX.Enabled = e;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

        }


    }
}