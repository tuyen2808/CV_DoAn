using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QL_HoaTuoi.Models;
namespace QL_HoaTuoi.Controllers
{
    public class QuanLySPAPIController : ApiController
    {
        [HttpGet]
        public List<CHUNGLOAI> GetCLLists()
        {
            QL_BanHoaDataContext db = new QL_BanHoaDataContext();
            return db.CHUNGLOAIs.ToList();
        }
        [HttpGet]
        public CHUNGLOAI GetCL(int id)
        {
            QL_BanHoaDataContext db = new QL_BanHoaDataContext();
            return db.CHUNGLOAIs.FirstOrDefault(x => x.MaCL == id);
        }
        [HttpPost]
        public bool InsertNewCL(int ma , string name, int tl, string anhBia ,string diengia ,int price)
        {
            try
            {
                QL_BanHoaDataContext db = new QL_BanHoaDataContext();
                CHUNGLOAI cl = new CHUNGLOAI();
                cl.MaCL = ma;
                cl.MaTL = tl;
                cl.TenCL = name;
                cl.AnhBia = anhBia;
                cl.DienGia = diengia;
                cl.GiaBan = price;
                db.CHUNGLOAIs.InsertOnSubmit(cl);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
        [HttpDelete]
        public bool DeleteCL(int id)
        {
            QL_BanHoaDataContext db = new QL_BanHoaDataContext();
            CHUNGLOAI cl = db.CHUNGLOAIs.FirstOrDefault(x => x.MaCL == id);
            if (cl == null)
                return false;
            db.CHUNGLOAIs.DeleteOnSubmit(cl);
            db.SubmitChanges();
            return true;
        }
        //[HttpPut]
        //public bool UpdateSP(int ma, string name, int tl, string anhBia, string diengia, int price)
        //{
        //    try
        //    {
        //        QL_BanHoaDataContext db = new QL_BanHoaDataContext();
        //        CHUNGLOAI cl = db.CHUNGLOAIs.FirstOrDefault(n=>n.MaCL==ma);
        //        if (cl == null)
        //            return false;               
        //        cl.MaTL = tl;
        //        cl.TenCL = name;
        //        cl.AnhBia = anhBia;
        //        cl.DienGia = diengia;
        //        cl.GiaBan = price;
        //        db.CHUNGLOAIs.InsertOnSubmit(cl);
        //        db.SubmitChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;

        //    }
        //}
        [HttpPut]
        public bool UpdateSP(int ma, string name, int tl, string anhBia, string diengia, int price)
        {
            try
            {
                //lay sp da ton tai ra
                QL_BanHoaDataContext db = new QL_BanHoaDataContext();
                CHUNGLOAI cl = db.CHUNGLOAIs.FirstOrDefault(a => a.MaCL == ma);
                if (cl == null)
                    return false;// khong ton tai
                cl.TenCL = name;
                cl.MaTL = tl;
                cl.AnhBia = anhBia;
                cl.DienGia = diengia;
                cl.GiaBan = price;
                db.SubmitChanges();//xac nhan chinh sua
                return true;
            }
            catch
            {
                return false;
            }
        }
        
              


    }
}
