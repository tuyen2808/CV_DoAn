using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DoAnNET.View;
using System.Data.SqlClient;
using QuanLyNhaSach;
//using DoAnNET.Controller;


namespace DoAnNET
{
    public partial class TrangChu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static String Hoten = null;
        public static String Quyen = null;
        public static int TrangThai = 0;
        public TrangChu()
        {
            InitializeComponent();
            

        }
        //theme cho form
        public static void Skin()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel theme = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            theme.LookAndFeel.SkinName = "Seven";
        }
        private void TrangChu_Load(object sender, EventArgs e)
        {
            TrangChu.Skin();
            //data.Enabled = false;
            
        }
        //an cac buton 
        public void DisEndMenuLogin(bool e)
        {
            
        }
        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
           DangNhap dn = null; 
            if (dn==null||dn.IsDisposed)
                dn=new DangNhap();
            if (dn.ShowDialog() == DialogResult.OK)
            {
                if (dn.txt_User.Text == "")
                {
                    XtraMessageBox.Show("Hãy nhập username!");
                    dn.ShowDialog();
                }
                if (dn.txt_Pass.Text == "")
                {
                    XtraMessageBox.Show("Hãy nhập password!");
                    dn.ShowDialog();
                }
                if (TrangChu.TrangThai == 1)
                {
                    txtUser.Text = TrangChu.Hoten;
                    bar_btn_DoiMatKhau.Enabled = true;
                    bar_btn_DangXuat.Enabled = true;
                    bar_btn_PhanQuyen.Enabled = true;
                }
            }
            //if (dn.ShowDialog() == DialogResult.Cancel)
            //{
                
            //}
        }



        private void bar_btn_DoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            DoiMatKhau dmk = null;
            if (dmk == null || dmk.IsDisposed)
                dmk = new DoiMatKhau();
            if (dmk.ShowDialog() == DialogResult.OK)
            {
                if (dmk.txt_User.Text == String.Empty || dmk.txt_Pass.Text ==String.Empty ||dmk.txt_RePass.Text ==String.Empty)
                {
                    XtraMessageBox.Show("Hãy nhập username!");
                }
                if (dmk.txt_Pass.Text == "")
                {
                    XtraMessageBox.Show("Hãy nhập password!");
                }
                if (dmk.txt_RePass.Text == "")
                {
                    XtraMessageBox.Show("Hãy nhập lại password!");
                }
            }
        }

        private void bar_btn_DangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrangChu.TrangThai = 0;
            txtUser.Text = null;
            bar_btn_DoiMatKhau.Enabled = bar_btn_DangXuat.Enabled =   bar_btn_PhanQuyen.Enabled = false;
        }

        private void btnThietBi_ItemClick(object sender, ItemClickEventArgs e)
        {
            //bool IsActive = false;
            //foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            //{
            //    if (form.GetType() == typeof(TrangChu.LapHoaDon))
            //    {
            //        form.Activate();
            //        IsActive = true;
            //    }
            //}
            //if (!IsActive)
            //{
            //    TrangChu.LapHoaDon PreTest = new TrangChu.LapHoaDon();
            //    PreTest.MdiParent = this;
            //    PreTest.Show();
            //}
        }

        public void LoaddataThietBi()
        {
            
        }
    }
}