using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DongHo.Models
{
    public class Giohang
    {
        dbQLDonghoDataContext data=new dbQLDonghoDataContext();
        public int iMasp { set; get; }
        public string sTensp { set; get; }
        public string sAnh { set; get; }

        public Double dDongia { set; get; }

        public int iSoluong { set; get; }

        public Double dThanhtien
        {
            get { return iSoluong* dDongia; }
        }
        public Giohang(int Masp)
        {
            iMasp = Masp;
            SanPham dh = data.SanPhams.Single(n => n.Masp == Masp);
            sTensp= dh.Tensp;
            sAnh=dh.Anh;
            dDongia = double.Parse(dh.Gia.ToString());
            iSoluong = 1;
        }
    }
}