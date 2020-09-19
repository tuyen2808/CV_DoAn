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
    public partial class DanhMucThanhLyThietBi : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_DMTL = new SqlDataAdapter();
        KetNoi cn = new KetNoi();
        public DanhMucThanhLyThietBi()
        {
            InitializeComponent();
            LoadCboMaTL();
            LoadDataGridview_DMTL();
        }


        public void LoadCboMaTL()
        {
            try
            {
                string sql = "select * from CB_ThanhLy";
                DataTable dt = cn.getDataTable(sql, "CB_ThanhLy");
                cbo_MaThanhLy.DataSource = dt;
                cbo_MaThanhLy.DisplayMember = "MaThanhLy";
                cbo_MaThanhLy.ValueMember = "MaThanhLy";
                dateEdit_NgayThanhLy.DataBindings.Clear();
                dateEdit_NgayThanhLy.DataBindings.Add("text", dt, "NgayThanhLy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        public void LoadDataGridview_DMTL()
        {
            try
            {
                string sql = "select * from CB_ThanhLy";
                da_DMTL = cn.getDataAdapter(sql,"ThanhLy");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["ThanhLy"].Columns["MaThanhLy"];
                cn.ds.Tables["ThanhLy"].PrimaryKey = primarykey;
                gridCBTL.DataSource = cn.ds.Tables["ThanhLy"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        private void btn_TiimKiem_Click(object sender, EventArgs e)
        {
            if (rdo_MaThanhLy.Checked == true)
            {
                cn.ds.Tables["ThanhLy"].Clear();
                string sql = "select * from CB_ThanhLy where MaThanhLy = '" + cbo_MaThanhLy.SelectedValue + "'";
                da_DMTL = cn.getDataAdapter(sql, "ThanhLy");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["ThanhLy"].Columns["MaThanhLy"];
                cn.ds.Tables["ThanhLy"].PrimaryKey = primarykey;
                gridCBTL.DataSource = cn.ds.Tables["ThanhLy"];
            }
            else if (rdo_NgayThanhLy.Checked == true)
            {
                string sql = "select * from CB_ThanhLy where MaThanhLy = '" + dateEdit_NgayThanhLy.Text + "'";
                da_DMTL = cn.getDataAdapter(sql, "ThanhLy");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["ThanhLy"].Columns["MaThanhLy"];
                cn.ds.Tables["ThanhLy"].PrimaryKey = primarykey;
                gridCBTL.DataSource = cn.ds.Tables["ThanhLy"];
            }
        }

        private void rdo_MaThanhLy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_MaThanhLy.Checked == true)
            {
                dateEdit_NgayThanhLy.Enabled = false;
                cbo_MaThanhLy.Enabled = true;
            }
            else if (rdo_NgayThanhLy.Checked == true)
            {
                cbo_MaThanhLy.Enabled = false;
                dateEdit_NgayThanhLy.Enabled = true;
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            cbo_MaThanhLy.Enabled = true;
            dateEdit_NgayThanhLy.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string id = gV_CBTL.GetRowCellValue(gV_CBTL.FocusedRowHandle, gV_CBTL.Columns[0]).ToString();
                String sql = "delete from CT_ThanhLy where MaThanhLy = '" + id + "'";
                cn.thucthiketnoi(sql);
                cn.ds.Tables["ThanhLy"].Clear();
                string delete = "delete from CB_ThanhLy where MaThanhLy = '" + id + "'";
                da_DMTL = cn.getDataAdapter(delete, "ThanhLy");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["ThanhLy"].Columns["MaThanhLy"];
                cn.ds.Tables["ThanhLy"].PrimaryKey = primarykey;
                gridCBTL.DataSource = cn.ds.Tables["ThanhLy"];
                LoadDataGridview_DMTL();
            }
        }

    }
}