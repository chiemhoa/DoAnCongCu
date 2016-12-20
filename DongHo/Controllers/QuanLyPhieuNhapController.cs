using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DongHo.Models;

namespace DongHo.Controllers
{
    public class QuanLyPhieuNhapController : Controller
    {
        //
        // GET: /QuanLyPhieuNhap/
        //
        // GET: /QuanLyPhieuNhap/
        dbQLDonghoDataContext db = new dbQLDonghoDataContext();
        [HttpGet]
        public ActionResult NhapHang()
        {
            ViewBag.MaNCC = db.NhaSXes;
            ViewBag.ListSanPham = db.SanPhams;
            return View();
        }
        [HttpPost]
        public ActionResult NhapHang(PhieuNhap model,IEnumerable<ChiTietPhieuNhap> lstModel)
        {
            ViewBag.MaNCC = db.NhaSXes;
            ViewBag.ListSanPham = db.SanPhams;
            //Sau khi các b?n dă ki?m tra t?t c? d? li?u d?u vào
            //Gán dă xóa: False
            model.DaXoa = false;
            db.PhieuNhaps.InsertOnSubmit(model);
            db.SubmitChanges();
            //SaveChanges d? l?y du?c mă phi?u nh?p gán cho lstChiTietPhieuNhap
            SanPham sp;
            foreach (var item in lstModel)
            {
                //C?p nh?t s? lu?ng t?n
                sp = db.SanPhams.Single(n => n.Masp == item.Masp);
                sp.Soluong += item.SoLuongNhap;
                //Gán mă phi?u nh?p cho t?t c? chi ti?t phi?u nh?p
                item.Mapn = model.Mapn;
            }
            db.ChiTietPhieuNhaps.InsertAllOnSubmit(lstModel);
            db.SubmitChanges();
        
            return View();
        }
        [HttpGet]
        public ActionResult DSSHetHang()
        {
            var lstSP = db.SanPhams.Where(n => n.Soluong <= 5);
            return View(lstSP);
        }
        [HttpGet]
        public ActionResult NhapHangDon(int? id)
        {
            ViewBag.MaNCC = new SelectList(db.NhaSXes.OrderBy(n => n.Tennsx), "Mansx", "Tennsx");
            //Tuong t? nhu trang ch?nh s?a s?n ph?m nhung ta không c?n ph?i show h?t các thu?c tính 
            //Ch? thu?c tính nào c?n thi?t mà thôi dó là s? lu?ng t?n h́nh ?nh... thông tin hi?n th? c?n thi?t
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.Masp == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);

        }
        [HttpPost]
        public ActionResult NhapHangDon(PhieuNhap model, ChiTietPhieuNhap ctpn)
        {
            ViewBag.MaNCC = new SelectList(db.NhaSXes.OrderBy(n => n.Tennsx), "Mansx", "Tennsx", model.Mansx);
            //Sau khi các b?n dă ki?m tra t?t c? d? li?u d?u vào
            //Gán dă xóa: False
            model.NgayNhap = DateTime.Now;
            model.DaXoa = false;
            db.PhieuNhaps.InsertOnSubmit(model);
            db.SubmitChanges();
            //SaveChanges d? l?y du?c mă phi?u nh?p gán cho lstChiTietPhieuNhap
            ctpn.Mapn = model.Mapn;
            //C?p nh?t t?n 
            SanPham sp = db.SanPhams.Single(n => n.Masp == ctpn.Masp);
            sp.Soluong += ctpn.SoLuongNhap;
            db.ChiTietPhieuNhaps.InsertOnSubmit(ctpn);
            db.SubmitChanges();
            return View(sp);

        }
        //Gi?i phóng bi?n cho vùng nh?
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                    db.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }

	}
	}
