using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QL_HoaTuoi.Models
{
    
    public class item
    {
        QL_BanHoaDataContext db = new QL_BanHoaDataContext();
        public int maCL{ set; get; }
        public string tenCL{ set; get; }
        public string anhBia { set; get; }
        public Double donGia { set; get; }
        public int soLuong { set; get; }
        public Double thanhTien { get { return soLuong * donGia; } }
        public item(int MaCL)
        {
            maCL = MaCL;
            CHUNGLOAI cl = db.CHUNGLOAIs.Single(n => n.MaCL == maCL);
            tenCL = cl.TenCL;
            anhBia = cl.AnhBia;
            donGia = double.Parse(cl.GiaBan.ToString());
            soLuong = 1;
        }

        
    }
}