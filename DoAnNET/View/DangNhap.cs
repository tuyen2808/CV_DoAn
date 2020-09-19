using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using QuanLyNhaSach;

namespace DoAnNET
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_ChiTietPN = new SqlDataAdapter();
        DataColumn[] key = new DataColumn[2];
        KetNoi cn = new KetNoi();
        SqlDataAdapter da_PhieuNhap = new SqlDataAdapter();
        public DangNhap()
        {
            InitializeComponent();
            
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_User.Text != String.Empty && txt_Pass.Text != String.Empty)
            {
                string sql = "select Username,Pass,Quyen,TenNV from Admin,NhanVien where username='" + txt_User.Text + "' and Pass='" + txt_Pass.Text + "' and Admin.MaNV=NhanVien.MaNV";
                DataTable dt = cn.getDataTable(sql, "DangNhap");
                if (dt.Rows.Count > 0)
                {
                    XtraMessageBox.Show("Đăng nhập thành công");
                    DataRow dr = dt.Rows[0];
                    TrangChu.Hoten = dr[3].ToString();
                    TrangChu.Quyen = dr[2].ToString();
                    TrangChu.TrangThai = 1;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
                }

            }
        }
    }
}