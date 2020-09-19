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
    public partial class ThongKeThietBi : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_TKTB = new SqlDataAdapter();
        KetNoi cn = new KetNoi();
        public ThongKeThietBi()
        {
            InitializeComponent();
            LoadDataGridview_ThietBi();
            LoadCboMaTL();
            LoadCboMaNSX();
            LoadCboMaKho();
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
                cbo_MaTL.DataSource = dt;
                cbo_MaTL.DisplayMember = "TenTL";
                cbo_MaTL.ValueMember = "MaTL";
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
                if (rdo_MaNSX.Checked == false && rdo_MaKho.Checked == false && rdo_MaTL.Checked == false)
                {
                    string sql = "select * from ThietBi ";
                    da_TKTB = cn.getDataAdapter(sql, "TKTB");
                    DataColumn[] primarykey = new DataColumn[1];
                    primarykey[0] = cn.ds.Tables["TKTB"].Columns["MaTB"];
                    cn.ds.Tables["TKTB"].PrimaryKey = primarykey;
                    grid_TKTB.DataSource = cn.ds.Tables["TKTB"];
                }
                
                else if (rdo_MaNSX.Checked == true)
                {
                    cbo_MaKho.Enabled = false;
                    cbo_MaTL.Enabled = false;
                    cbo_MaKho.Text = "";
                    cbo_MaTL.Text = "";
                    string sql = "select * from ThietBi where MaNSX = '" + cbo_NSX.SelectedValue + "'";
                    da_TKTB = cn.getDataAdapter(sql, "TKTB1");
                    DataColumn[] primarykey = new DataColumn[1];
                    primarykey[0] = cn.ds.Tables["TKTB1"].Columns["MaTB"];
                    cn.ds.Tables["TKTB1"].PrimaryKey = primarykey;
                    grid_TKTB.DataSource = cn.ds.Tables["TKTB1"];
                }
                else if (rdo_MaKho.Checked == true)
                {
                    cbo_NSX.Enabled = false;
                    cbo_MaTL.Enabled = false;
                    cbo_NSX.Text = "";
                    cbo_MaTL.Text = "";
                    string sql = "select * from ThietBi where MaKho = '" + cbo_MaKho.SelectedValue + "'";
                    da_TKTB = cn.getDataAdapter(sql, "TKTB2");
                    DataColumn[] primarykey = new DataColumn[1];
                    primarykey[0] = cn.ds.Tables["TKTB2"].Columns["MaTB"];
                    cn.ds.Tables["TKTB2"].PrimaryKey = primarykey;
                    grid_TKTB.DataSource = cn.ds.Tables["TKTB2"];
                }
                else if (rdo_MaTL.Checked == true)
                {
                    cbo_NSX.Enabled = false;
                    cbo_MaKho.Enabled = false;
                    cbo_NSX.Text = "";
                    cbo_MaKho.Text = "";
                    string sql = "select * from ThietBi where MaTL = '" + cbo_MaTL.SelectedValue + "'";
                    da_TKTB = cn.getDataAdapter(sql, "TKTB3");
                    DataColumn[] primarykey = new DataColumn[1];
                    primarykey[0] = cn.ds.Tables["TKTB3"].Columns["MaTB"];
                    cn.ds.Tables["TKTB3"].PrimaryKey = primarykey;
                    grid_TKTB.DataSource = cn.ds.Tables["TKTB3"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadDataGridview_ThietBi();
        }
    }
}