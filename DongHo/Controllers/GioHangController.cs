using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DongHo.Models;

namespace DongHo.Controllers
{
    public class GioHangController : Controller
    {
        dbQLDonghoDataContext data = new dbQLDonghoDataContext();
        //
        // GET: /Giohang/
        public ActionResult Index()
        {
            return View();
        }
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if(lstGiohang==null)
            {
                lstGiohang=new List<Giohang>();
                Session["Giohang"]=lstGiohang;
            }
            return lstGiohang;
        }
        public ActionResult Themgiohang(int iMasp, string strURL)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.Find(n => n.iMasp == iMasp);
            if(sanpham==null)
            {
                sanpham = new Giohang(iMasp);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        private int Tongsoluong()
        {
            int iTongsoluong = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if(lstGiohang!=null)
            {
                iTongsoluong = lstGiohang.Sum(n => n.iSoluong);
            }
            return iTongsoluong;
        }
        private double TongTien()
        {
            double iTongtien = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if(lstGiohang!=null)
            {
                iTongtien = lstGiohang.Sum(n => n.dThanhtien);
            }
            return iTongtien;
        }
        public ActionResult Giohang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            if(lstGiohang.Count==0)
            {
                return RedirectToAction("Index", "DongHo");
            }
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = TongTien();
            return View(lstGiohang);
        }
        public ActionResult GiohangPartial()
        {
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = String.Format("{0:0,0 vnđ}",TongTien());
            return PartialView();
        }
        public ActionResult XoaGioHang(int iMaSP)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang dh = lstGiohang.SingleOrDefault(n => n.iMasp == iMaSP);
            if(dh !=null)
            {
                lstGiohang.RemoveAll(n => n.iMasp == iMaSP);
                return RedirectToAction("Giohang");
            }
            if(lstGiohang.Count==0)
            {
                return RedirectToAction("Index", "DongHo");
            }
            return RedirectToAction("Giohang");
        }
        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang dh = lstGiohang.SingleOrDefault(n => n.iMasp == iMaSP);
            if(dh!=null)
            {
                dh.iSoluong=int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("Giohang");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<Giohang> lstgiohang = Laygiohang();
            lstgiohang.Clear();
            return RedirectToAction("Index", "DongHo");
        }
        [HttpGet]
        public ActionResult DatHang()
        { 
            if(Session["Taikhoan"]==null||Session["Taikhoan"].ToString()=="")
            {
                return RedirectToAction("Dangnhap", "Nguoidung");
            }
            if(Session["Giohang"]==null)
            {
                return RedirectToAction("Index", "DongHo");
            }
            List<Giohang> lstgiohang = Laygiohang();
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = TongTien();
            return View(lstgiohang);
        }
        public ActionResult DatHang(FormCollection collection)
        {
            DonHang ddh = new DonHang();
            KhachHang kh = (KhachHang)Session["Taikhoan"];
            List<Giohang> gh = Laygiohang();
            
            ddh.Makh = kh.Makh;
            ddh.Ngaydat = DateTime.Now;
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["Ngaygiao"]);
            ddh.Ngaygiao = DateTime.Parse(ngaygiao);
            ddh.Thanhtoan = null;
            ddh.Tinhtrang = null;
            var dcgiao = collection["dcgiao"];
            ddh.Diachigiao = dcgiao;
            ddh.Tinhtrang = false;
            ddh.Thanhtoan = false;
            data.DonHangs.InsertOnSubmit(ddh);
            data.SubmitChanges();
            foreach(var item in gh)
            {
                ChiTietDonHang ctdh = new ChiTietDonHang();
                ctdh.Madh = ddh.Madh;
                ctdh.Masp = item.iMasp;
                ctdh.Dongia = int.Parse(item.dDongia.ToString());
                ctdh.Soluong = item.iSoluong;
                data.ChiTietDonHangs.InsertOnSubmit(ctdh);
               
            }
            data.SubmitChanges();
            Session["Giohang"] = null;
            return RedirectToAction("Xacnhandonhang", "GioHang");

        }
        public ActionResult Xacnhandonhang()
        {
            return View();
        }
	}
}