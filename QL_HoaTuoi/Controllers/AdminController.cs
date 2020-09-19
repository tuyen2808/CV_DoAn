using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_HoaTuoi.Models;
using System.IO;
namespace QL_HoaTuoi.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        QL_BanHoaDataContext db = new QL_BanHoaDataContext();
        QuanLySPAPIController df = new QuanLySPAPIController();
        public ActionResult Index()
        {
            //List<CHUNGLOAI> lst = db.CHUNGLOAIs.ToList();
            List<CHUNGLOAI> lst =df.GetCLLists();
            return View(lst);
        }
        public ActionResult DangNhapAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XuLyDangNhapAdmin(FormCollection c)
        {
            var a = c["txtDN"];
            var b = c["txtMK"];

            ADMIN ad = db.ADMINs.SingleOrDefault(t => t.USENAME == a && t.PASS == b);
            if (ad != null)
            {
                Session["dna"] = ad;
                return RedirectToAction("Index", "Admin");
            }
            {
                ViewBag.tb = "Sai mật khẩu. Vui lòng nhập lại";
                return RedirectToAction("DangNhapAdmin");
            }

        }
        public ActionResult them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult them(FormCollection c)
        {
            var a = int.Parse(c["txtMa"]);
            var b = c["txtTen"];
            var d = int.Parse(c["txtTheLoai"]);
            string hinh = c["FileHinh"].ToString();
            var gia = int.Parse(c["txtGia"]);
            var mota = c["txtMoTa"];
            df.InsertNewCL(a, b, d, hinh, mota, gia);
            return RedirectToAction("Index","Admin");
        }
        [HttpGet]
        public ActionResult xoa(int id)
        {
            df.DeleteCL(id);
            return RedirectToAction("Index","Admin");
        }
        public ActionResult Sua(int ma, string name, int tl, string anhBia, string diengia, int price)
        {
            ViewData["txtMa"]=ma;
            ViewData["txtTen"] = name;
            ViewData["txtTheLoai"] = tl;
            ViewData["FileHinh"] = anhBia;
            ViewData["txtMoTa"] = diengia;
            ViewData["txtGia"] = price;
            return View();
        }
        [HttpPost]
        public ActionResult XLSua(FormCollection c)
        {
            //List<CHUNGLOAI> lst = df.GetCLLists();
            //CHUNGLOAI cl = lst.FirstOrDefault(t=>t.MaCL == ma );
            var a = int.Parse(c["txtMa"]);
            var b = c["txtTen"];
            var d = int.Parse(c["txtTheLoai"]);
            string hinh = c["FileHinh"].ToString();
            var gia = int.Parse(c["txtGia"]);
            var mota = c["txtMoTa"];
            df.UpdateSP(a, b, d, hinh, mota, gia);
            return RedirectToAction("Index","Admin");
        }

      

    }
}
