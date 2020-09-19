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

namespace DoAnNET
{
    public partial class LapHoaDon : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da_CTHD = new SqlDataAdapter();
        KetNoi cn = new KetNoi();
        char TrangThai = '0';
        public LapHoaDon()
        {
            InitializeComponent();
            TrangChu.Skin();
            LoadCboMaNV();
            LoadSoHD();
            LoadCboMaTB();
            LoadDataGridview_CTHD();
            DisTextBox(false);
            btn_Luu.Enabled = btn_Huy.Enabled = false;
        }

        private void DataBingDing(DataTable tb)
        {
            txt_SoHD.DataBindings.Clear();
            cbo_MaNV.DataBindings.Clear();
            txt_MaKH.DataBindings.Clear();
            dateEdit_NgayLap.DataBindings.Clear();
            txt_Thue.DataBindings.Clear();
            txt_SoHD.DataBindings.Add("Text", tb, "SoHD");
            txt_Thue.DataBindings.Add("Text", tb, "VAT");
            cbo_MaNV.DataBindings.Add("Text", tb, "MaNV");
            txt_MaKH.DataBindings.Add("Text", tb, "MaKH");
            dateEdit_NgayLap.DataBindings.Add("Text", tb, "NgayLap_HD");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }

        public void LoadSoHD()
        {
            try
            {
                string sql = "select * from HoaDon";
                DataTable dt = cn.getDataTable(sql, "HoaDon");
                DataColumn[] primarykey = new DataColumn[1];
                primarykey[0] = cn.ds.Tables["HoaDon"].Columns["SoHD"];
                cn.ds.Tables["HoaDon"].PrimaryKey = primarykey;
                DataBingDing(dt);
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
                string sql = "select * from NhanVien where ChucVu = N'thu Ngân'";
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

        public void LoadDataGridview_CTHD()
        {
            try
            {
                String sql = "select * from CT_HoaDon";
                da_CTHD = cn.getDataAdapter(sql,"CT_HoaDon");
                DataColumn[] primarykey = new DataColumn[2];
                primarykey[0] = cn.ds.Tables["CT_HoaDon"].Columns["SoHD"];
                primarykey[1] = cn.ds.Tables["CT_HoaDon"].Columns["MaTB"];
                cn.ds.Tables["CT_HoaDon"].PrimaryKey = primarykey;
                gridCTHD.DataSource = cn.ds.Tables["CT_HoaDon"];
                txt_SoHD.DataBindings.Clear();
                txt_SoHD.DataBindings.Add("text", cn.ds.Tables["CT_HoaDon"], "SoHD");
                cbo_MaTB.DataBindings.Clear();
                cbo_MaTB.DataBindings.Add("text", cn.ds.Tables["CT_HoaDon"], "MaTB");
                txt_SL.DataBindings.Clear();
                txt_SL.DataBindings.Add("text", cn.ds.Tables["CT_HoaDon"], "SoLuong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }

        }

        public void XoaTextBox()
        {
            txt_Thue.Text = txt_DonGia.Text = cbo_MaNV.Text = cbo_MaTB.Text = txt_SoHD.Text = txt_MaKH.Text = dateEdit_NgayLap.Text = null;
        }

        public void DisTextBox(bool e)
        {
            txt_Thue.Enabled = txt_DonGia.Enabled = cbo_MaNV.Enabled = txt_SoHD.Enabled = txt_MaKH.Enabled = e;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            TrangThai = '1';
            XoaTextBox();
            btn_Luu.Enabled = btn_Huy.Enabled = true;
            btn_Sua.Enabled = btn_Xoa.Enabled = false;
            txt_SoHD.Focus();
            DisTextBox(true);
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (TrangThai == '1')
                {
                    //Them
                    if (txt_SoHD.Text == string.Empty)
                    {
                        MessageBox.Show("Chưa nhập Số hóa đơn");
                        txt_SoHD.Focus();
                        return;
                    }
                    else if (txt_MaKH.Text == string.Empty)
                    {
                        MessageBox.Show("Chưa nhập mã khách hàng");
                        txt_MaKH.Focus();
                        return;
                    }
                    else if (txt_Thue.Text == string.Empty)
                    {
                        MessageBox.Show("Chưa nhập thuế");
                        txt_Thue.Focus();
                        return;
                    }
                    else if (cbo_MaNV.Text == string.Empty)
                    {
                        MessageBox.Show("Chưa chọn Nhân Viên ");
                        cbo_MaNV.Focus();
                        return;
                    }
                    else if (dateEdit_NgayLap.Text == string.Empty)
                    {
                        MessageBox.Show("Chưa chọn NgayLap ");
                        cbo_MaNV.Focus();
                        return;
                    }
                    else if (txt_DonGia.Text == string.Empty)
                    {
                        MessageBox.Show("Chưa nhập Đơn Giá");
                        txt_DonGia.Focus();
                        return;
                    }

                    string SoHD = txt_SoHD.Text;
                    DataRow d = cn.ds.Tables["HoaDon"].Rows.Find(SoHD);
                    if (d != null)
                    {
                        MessageBox.Show(" Số Hóa Đơn đã tồn tại");
                        txt_SoHD.Focus();
                        return;
                    }
                    String sql = "InSert Into HoaDon(SoHD,NgayLap_HD,VAT,MaKH,MaNV)" +
                    "Values(" + txt_SoHD.Text + "," + dateEdit_NgayLap.Text + "," + txt_Thue.Text + "," + txt_MaKH.Text + "," + cbo_MaNV.SelectedValue + ")";
                    cn.thucthiketnoi(sql);
                    DataRow dr = cn.ds.Tables["CT_HoaDon"].NewRow();
                    dr = cn.ds.Tables["CT_HoaDon"].NewRow();
                    dr["SoHD"] = txt_SoHD.Text;
                    dr["MaTB"] = cbo_MaTB.SelectedValue;
                    dr["SoLuong"] = txt_SL.Text;
                    dr["DonGia"] = txt_DonGia.Text;
                    dr["ThanhTien"] = float.Parse(txt_DonGia.Text) * int.Parse(txt_SL.Text);
                    cn.ds.Tables["CT_HoaDon"].Rows.Add(dr);
                    SqlCommandBuilder buider1 = new SqlCommandBuilder(da_CTHD);
                    da_CTHD.Update(cn.ds, "CT_HoaDon");
                    LoadDataGridview_CTHD();
                    String UpDate = "Update HoaDon Set TongGiaTri =" +
                        " select Sum(ThanhTien) from CT_HonDon where SoHD = '" + txt_SoHD.Text + "'" +
                        "Where SoHD = '" + txt_SoHD.Text + "'";
                    cn.thucthiketnoi(UpDate);
                    DisTextBox(true);
                    btn_Luu.Enabled = btn_Huy.Enabled = false;
                    btn_Them.Enabled = btn_Xoa.Enabled = btn_Sua.Enabled = true;
                }
                else
                {
                    //Sua
                    if (dateEdit_NgayLap.Text != String.Empty && cbo_MaTB.SelectedValue != String.Empty && txt_MaKH.Text != String.Empty && txt_Thue.Text != String.Empty)
                    {
                        try
                        {
                            string sql = "update NSX set  = N'" + txtTenNSX.Text + "', DiaChi = N'" + txtDiaChi.Text + "', SDT = '" + txtSDT.Text + "' where MaNSX = '" + txtMaNSX.Text + "'";
                            cn.thucthiketnoi(sql);
                            cn.ds.Tables["NSX"].Clear();
                            LoadDataGridview_TTNL();
                            {
                                MessageBox.Show("Thành công !", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            Load();
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Không thành công !", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                    }
                }

            }
            catch
            {
                MessageBox.Show("Thất bại ");
            }
        }

    }
}