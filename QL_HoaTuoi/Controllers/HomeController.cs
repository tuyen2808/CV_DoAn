using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_HoaTuoi.Models;
namespace QL_HoaTuoi.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //QuanLyBanSachDataContext db = new QuanLyBanSachDataContext();
        QL_BanHoaDataContext db = new QL_BanHoaDataContext();
        public ActionResult Index(String id)
        {
            List<CHUNGLOAI> lst = db.CHUNGLOAIs.ToList();
            return View(lst);
        }
        public ActionResult HienThiLoai()
        {     
            List<THELOAI> lstLoai = db.THELOAIs.ToList();
            return PartialView(lstLoai);
        }
        public ActionResult HienThiChiTietNhom(int id)
        {
            //int ma = int.Parse(id);
            List<CHUNGLOAI> lst = db.CHUNGLOAIs.ToList();
            List<CHUNGLOAI> lst2 = lst.Where(t => t.MaTL == id).ToList();
            return View(lst2);
        }
        public ActionResult HienThiSP(string id)
        {
            int m = int.Parse(id);
            List<CHUNGLOAI> lst1 = db.CHUNGLOAIs.ToList();
            CHUNGLOAI lst2 = lst1.FirstOrDefault(t => t.MaCL == m);
            return View(lst2);
        }
        [HttpPost]
        public ActionResult TimKiem(FormCollection c)
        {
            var tukhoa = c["txtSearch"];
            List<CHUNGLOAI> lst = db.CHUNGLOAIs.ToList();
            List<CHUNGLOAI> lst2 = lst.Where(t => t.TenCL.Contains(tukhoa) == true).ToList();

            return View(lst2);
        }
        public ActionResult ChiTietSP(string id)
        {
            int m = int.Parse(id);
            List<CHUNGLOAI> lst = db.CHUNGLOAIs.ToList();
            CHUNGLOAI sp = lst.FirstOrDefault(t => t.MaCL == m);
            return View(sp);
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        

        

    }
}
