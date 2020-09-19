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
    public partial class ThongTinThietBi : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_DSTB = new SqlDataAdapter();
        KetNoi cn = new KetNoi();
        public ThongTinThietBi()
        {
            InitializeComponent();
            LoadCboMaKho();
            LoadCboMaNSX();
            LoadCboMaTL();
            LoadDataGridview_DSTB();
        }

        private void DataBingDing(DataTable tb)
        {
            txt_TenTB.DataBindings.Clear();
            txt_MaTB.DataBindings.Clear();
            txt_DVT1.DataBindings.Clear();
            txt_DVT2.DataBindings.Clear();
            txt_DonGia.DataBindings.Clear();
            txt_GiaNhap.DataBindings.Clear();
            txt_SLTon.DataBindings.Clear();
            dateEdit_NgayCapNhap.DataBindings.Clear();
            cbo_TL.DataBindings.Clear();
            cbo_NSX.DataBindings.Clear();
            cbo_Kho.DataBindings.Clear();
            txt_TenTB.DataBindings.Add("Text", tb, "TenTB");
            txt_MaTB.DataBindings.Add("Text", tb, "MaTB");
            txt_DVT1.DataBindings.Add("Text", tb, "DVT");
            txt_DVT2.DataBindings.Add("Text", tb, "DVT_Max");
            txt_DonGia.DataBindings.Add("Text", tb, "DonGia");
            txt_GiaNhap.DataBindings.Add("Text", tb, "GiaNhap");
            txt_SLTon.DataBindings.Add("Text", tb, "SoLuongTon");
            dateEdit_NgayCapNhap.DataBindings.Add("Text", tb, "NgayCapNhat");
            cbo_TL.DataBindings.Add("Text", tb, "MaTL");
            cbo_NSX.DataBindings.Add("Text", tb, "MaNSX");
            cbo_Kho.DataBindings.Add("Text", tb, "MaKho");
        }

        public void LoadDataGridview_DSTB()
        {
            try
            {
                string sql = "select * from ThietBi ";
                da_DSTB = cn.getDataAdapter(sql, "TB");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["TB"].Columns["MaTB"];
                cn.ds.Tables["TB"].PrimaryKey = primarykey;
                grid_DSTB.DataSource = cn.ds.Tables["TB"];
                DataBingDing(cn.ds.Tables["TB"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        public void LoadCboMaNSX()
        {
            try
            {
                string sql = "select * from NSX ";
                DataTable dt = cn.getDataTable(sql, "NSX");
                cbo_NSX.DataSource = dt;
                cbo_NSX.DisplayMember = "TenNSX";
                cbo_NSX.ValueMember = "MaNSX";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        public void LoadCboMaKho()
        {
            try
            {
                string sql = "select * from KHO";
                DataTable dt = cn.getDataTable(sql, "KHO");
                cbo_Kho.DataSource = dt;
                cbo_Kho.DisplayMember = "TenKho";
                cbo_Kho.ValueMember = "MaKho";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        public void LoadCboMaTL()
        {
            try
            {
                string sql = "select * from THELOAI";
                DataTable dt = cn.getDataTable(sql, "THELOAI");
                cbo_TL.DataSource = dt;
                cbo_TL.DisplayMember = "TenTL";
                cbo_TL.ValueMember = "MaTL";
                cbo_TL.DataBindings.Clear();
                cbo_TL.DataBindings.Add("text",dt,"TenTL");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }
    }
}