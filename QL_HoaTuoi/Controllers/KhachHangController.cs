using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_HoaTuoi.Models;
namespace QL_HoaTuoi.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/
        QL_BanHoaDataContext db = new QL_BanHoaDataContext();
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XuLyDangNhap(FormCollection c)
        {
            //try
            //{
                var a = c["txtDN"];
                var b = c["txtMK"];
                if (string.IsNullOrEmpty(a))
                {
                    ViewData["loia"] = "Bạn phải nhập tài khoản";
                }
                else if (string.IsNullOrEmpty(b))
                {
                    ViewData["loia"] = "Bạn phải nhập mật khẩu";
                }
                else
                {
                    KHACHHANG k = db.KHACHHANGs.SingleOrDefault(t => t.TenKH == a && t.MatKhau == b);
                    if (k != null)
                    {
                        Session["luu"] = k;
                        Session["dn"] = k.HoTen;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ViewBag.ThongBao = "Tài khoản không đúng!!";
                }
            
            //catch
            //{
                return RedirectToAction("DangNhap");
            //}

        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XuLyDangKy(FormCollection c, KHACHHANG kh)
        {
            //var tk = c["txtFullName"];
            
            kh.TenKH = c["txtFullName"];
            kh.MatKhau= c["txtPass"];
            kh.DiaChi = c["txtDiaChi"];
            kh.GioiTinh = c["txtGioiTinh"];
            kh.SDT = c["txtSDT"];
            kh.HoTen = c["txtHoTen"];
            kh.MST = c["txtMST"];
            db.KHACHHANGs.InsertOnSubmit(kh);
            db.SubmitChanges();
            return RedirectToAction("DangNhap");
        }
        public ActionResult deleteSS()
        {
            Session.Clear();
            return RedirectToAction("DangNhap", "KhachHang");
        }


    }
}
