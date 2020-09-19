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
    public partial class DanhMucThietBi : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_DMTB = new SqlDataAdapter();
        KetNoi cn = new KetNoi();

        public DanhMucThietBi()
        {
            InitializeComponent();
            LoadCboMaKho();
            LoadCboMaNSX();
            LoadCboMaTB();
            LoadCboMaTL();
            LoadDataGridview_ThietBi();
        }

        public void LoadCboMaTB()
        {
            try
            {
                string sql = "select * from ThietBi";
                DataTable dt = cn.getDataTable(sql, "ThietBi");
                cbo_MaTB.DataSource = dt;
                cbo_MaTB.DisplayMember = "TenTB";
                cbo_MaTB.ValueMember = "MaTB";
                txt_TenTB.DataBindings.Clear();
                txt_TenTB.DataBindings.Add("text",dt,"TenTB");
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
                cbo_MaKho.DataSource = dt;
                cbo_MaKho.DisplayMember = "TenKho";
                cbo_MaKho.ValueMember = "MaKho";
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
                cbo_TheLoai.DataSource = dt;
                cbo_TheLoai.DisplayMember = "TenTL";
                cbo_TheLoai.ValueMember = "MaTL";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        public void LoadDataGridview_ThietBi()
        {
            try
            {
                string sql = "select * from ThietBi";
                da_DMTB = cn.getDataAdapter(sql,"TB");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["TB"].Columns["MaTB"];
                cn.ds.Tables["TB"].PrimaryKey = primarykey;
                gridThietBi.DataSource = cn.ds.Tables["TB"];
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (rdo_MaTB.Checked == true)
            {
                cn.ds.Tables["TB"].Clear();
                string sql = "select * from ThietBi where MaTB = '" + cbo_MaTB.SelectedValue + "'";
                da_DMTB = cn.getDataAdapter(sql, "TB");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["TB"].Columns["MaTB"];
                cn.ds.Tables["TB"].PrimaryKey = primarykey;
                gridThietBi.DataSource = cn.ds.Tables["TB"];
            }
            else if (rdo_MaNSX.Checked == true)
            {
                cn.ds.Tables["TB"].Clear();
                string sql = "select * from ThietBi where MaNSX = '" + cbo_NSX.SelectedValue + "'";
                da_DMTB = cn.getDataAdapter(sql, "TB");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["TB"].Columns["MaTB"];
                cn.ds.Tables["TB"].PrimaryKey = primarykey;
                gridThietBi.DataSource = cn.ds.Tables["TB"];
            }
            else if (rdo_TenTB.Checked == true)
            {
                cn.ds.Tables["TB"].Clear();
                string sql = "select * from ThietBi where TenTB = '" + txt_TenTB.Text + "'";
                da_DMTB = cn.getDataAdapter(sql, "TB");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["TB"].Columns["MaTB"];
                cn.ds.Tables["TB"].PrimaryKey = primarykey;
                gridThietBi.DataSource = cn.ds.Tables["TB"];
            }
            else if (rdo_MaKho.Checked == true)
            {
                cn.ds.Tables["TB"].Clear();
                string sql = "select * from ThietBi where MaKho = '" + cbo_MaKho.SelectedValue + "'";
                da_DMTB = cn.getDataAdapter(sql, "TB");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["TB"].Columns["MaTB"];
                cn.ds.Tables["TB"].PrimaryKey = primarykey;
                gridThietBi.DataSource = cn.ds.Tables["TB"];
            }
            else if (rdo_TL.Checked == true)
            {
                cn.ds.Tables["TB"].Clear();
                string sql = "select * from ThietBi where MaTL = '" + cbo_TheLoai.SelectedValue + "'";
                da_DMTB = cn.getDataAdapter(sql, "TB");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["TB"].Columns["MaTB"];
                cn.ds.Tables["TB"].PrimaryKey = primarykey;
                gridThietBi.DataSource = cn.ds.Tables["TB"];
            }
        }

        private void rdo_TL_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_MaTB.Checked == true)
            {
                txt_TenTB.Enabled = false;
                cbo_NSX.Enabled = false;
                cbo_MaKho.Enabled = false;
                cbo_TheLoai.Enabled = false;
                cbo_MaTB.Enabled = true;
            }
            else if (rdo_MaNSX.Checked == true)
            {
                txt_TenTB.Enabled = false;
                cbo_MaTB.Enabled = false;
                cbo_MaKho.Enabled = false;
                cbo_TheLoai.Enabled = false;
                cbo_NSX.Enabled = true;
            }
            else if (rdo_TenTB.Checked == true)
            {
                cbo_NSX.Enabled = false;
                cbo_MaTB.Enabled = false;
                cbo_MaKho.Enabled = false;
                cbo_TheLoai.Enabled = false;
                txt_TenTB.Enabled = true;
            }
            else if (rdo_MaKho.Checked == true)
            {
                txt_TenTB.Enabled = false;
                cbo_NSX.Enabled = false;
                cbo_MaTB.Enabled = false;
                cbo_TheLoai.Enabled = false;
                cbo_MaKho.Enabled = true;
            }
            else if (rdo_TL.Checked == true)
            {
                txt_TenTB.Enabled = false;
                cbo_NSX.Enabled = false;
                cbo_MaKho.Enabled = false;
                cbo_MaTB.Enabled = false;
                cbo_TheLoai.Enabled = true;
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            txt_TenTB.Enabled = true;
            cbo_NSX.Enabled = true;
            cbo_MaKho.Enabled = true;
            cbo_MaTB.Enabled = true;
            cbo_TheLoai.Enabled = true;
        }
    }
}