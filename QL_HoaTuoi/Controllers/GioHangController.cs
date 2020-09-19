using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_HoaTuoi.Models;
namespace QL_HoaTuoi.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        QL_BanHoaDataContext db = new QL_BanHoaDataContext();
        public ActionResult XemGioHang()
        {
            List<item> lstGioHang = LayGioHang();
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.sl = tongSL();
            ViewBag.tt = tongTien();
            return View(lstGioHang);
        }
        public ActionResult GioDungHang()
        {
            ViewBag.sl = tongSL();
            return PartialView();
        }
        public List<item> LayGioHang()
        {
            List<item> lstGioHang = Session["GioHang"] as List<item>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<item>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(string ms,string url)
        {
            List<item> lstGioHang = LayGioHang();
            int a = int.Parse(ms);
            item s = lstGioHang.FirstOrDefault(n => n.maCL == a);
            if (s == null)
            {
                item ss = new item(a);
                lstGioHang.Add(ss);
                return Redirect(url);
            }
            else
            {
                s.soLuong++;
                return Redirect(url);

            }
            //return RedirectToAction("XemGioHang");
        }
        public int tongSL()
        {
            int tongSoLuong = 0;
            List<item> lstGioHang = Session["GioHang"] as List<item>;
            if (lstGioHang != null)
            {
                tongSoLuong = lstGioHang.Sum(n => n.soLuong);
            }
            return tongSoLuong;
        }
        public double tongTien()
        {
            double tongThanhTien = 0;
            List<item> lstGioHang = Session["GioHang"] as List<item>;
            if (lstGioHang != null)
            {
                tongThanhTien = lstGioHang.Sum(n => n.thanhTien);
            }
            return tongThanhTien;

        }
        public ActionResult XoaGioHang(int id)
        {
            List<item> lstGioHang = LayGioHang();
            item sp = lstGioHang.SingleOrDefault(n => n.maCL == id);
            if (sp != null)
            {
                lstGioHang.RemoveAll(n => n.maCL == id);
                return RedirectToAction("XemGioHang");
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("XemGioHang");
        }
      
        public ActionResult DatHang()
        {
            if (Session["luu"] == null)
                return RedirectToAction("DangNhap", "KhachHang");
            KHACHHANG x = Session["luu"] as KHACHHANG;
            List<item> lstGioHang = LayGioHang();
            return View(x);
        }
        //[HttpPost]
        public ActionResult XLDatHang()
        {
            List<item> lstGioHang = Session["GioHang"] as List<item>;
            if (lstGioHang == null)
            {
                RedirectToAction("Index", "Home");
            }
            KHACHHANG kh = Session["luu"] as KHACHHANG;
            HOADON hd = new HOADON();
            hd.MaKH = kh.MaKH;
            hd.NgaLap_HD = DateTime.Now;
            db.HOADONs.InsertOnSubmit(hd);
            db.SubmitChanges();
            foreach (var sp in lstGioHang)
            {
                CT_HOADON cthd = new CT_HOADON();
                cthd.SoHD = hd.SoHD;
                cthd.MaCL = sp.maCL;
                cthd.SoLuong = sp.soLuong;
                cthd.DonGia = Convert.ToInt32(sp.donGia);
                cthd.ThanhTien = Convert.ToInt32(sp.thanhTien);
                db.CT_HOADONs.InsertOnSubmit(cthd);
            }
            db.SubmitChanges();
            Session["GioHang"] = null;
            return RedirectToAction("ThanhToan");
        }
        public ActionResult ThanhToan()
        {
            return View();
        }


    }
}
