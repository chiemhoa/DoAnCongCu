using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DongHo.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace DongHo.Controllers
{
    public class Admin1Controller : Controller
    {
        dbQLDonghoDataContext db = new dbQLDonghoDataContext();
        //
        // GET: /Admin1/
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return RedirectToAction("Login", "Admin1");
            }
            return View();
        }
        public ActionResult DongHo(int? page)
        {
          
            int PageSize = 4;
            int PageNum = (page ?? 1);
            return View(db.SanPhams.ToList().OrderByDescending(n => n.Masp).ToPagedList(PageNum, PageSize));
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var ten = collection["user"];
            var matkhau = collection["password"];
            Admin ad = db.Admins.SingleOrDefault(n => n.Id == ten && n.Matkhau == matkhau);
            if (ad != null)
            {
                Session["Taikhoanadmin"] = ad;
                return RedirectToAction("Index", "Admin1");
            }
            else
            {
                ViewBag.Thongbao = "Tên hoặc mật khẩu không đúng";
            }
            return View();

        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            ViewBag.Mansx = new SelectList(db.NhaSXes.ToList().OrderBy(n => n.Tennsx), "Mansx", "Tennsx");
            ViewBag.Maloai = new SelectList(db.LoaiSPs.ToList().OrderBy(n => n.Tenloai), "Maloai", "Tenloai");
            //ViewBag.Gioitinh = new SelectList(db.Gioitinhs.ToList().OrderBy(n => n.Namnu), "Namnu", "Gioitinh1");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(SanPham dongho, HttpPostedFileBase fileupload)
        {
            ViewBag.Mansx = new SelectList(db.NhaSXes.ToList().OrderBy(n => n.Tennsx), "Mansx", "Tennsx");
            ViewBag.Maloai = new SelectList(db.LoaiSPs.ToList().OrderBy(n => n.Tenloai), "Maloai", "Tenloai");
            //ViewBag.Gioitinh = new SelectList(db.Gioitinhs.ToList().OrderBy(n => n.Namnu), "Namnu", "Gioitinh1");
            if (fileupload == null)
            {
                ViewBag.Thongbai = "Chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình đã tồn tại ";
                    }
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                    dongho.Anh = fileName;
                    db.SanPhams.InsertOnSubmit(dongho);
                    db.SubmitChanges();
                }
                return RedirectToAction("DongHo");
            }



        }
        public ActionResult Details(int id)
        {
            SanPham dongho = db.SanPhams.SingleOrDefault(n => n.Masp == id);
            ViewBag.Masp = dongho.Masp;
            if (dongho == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dongho);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            SanPham dongho = db.SanPhams.SingleOrDefault(n => n.Masp == id);
            ViewBag.Masp = dongho.Masp;
            if (dongho == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dongho);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            SanPham dongho = db.SanPhams.SingleOrDefault(n => n.Masp == id);
            ViewBag.Masp = dongho.Masp;
            if (dongho == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SanPhams.DeleteOnSubmit(dongho);
            db.SubmitChanges();
            return RedirectToAction("DongHo");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SanPham dongho = db.SanPhams.SingleOrDefault(m => m.Masp == id);
            if (dongho == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.Mansx = new SelectList(db.NhaSXes.ToList().OrderBy(n => n.Mansx), "Mansx", "Tennsx", dongho.Mansx);
            ViewBag.Maloai = new SelectList(db.LoaiSPs.ToList().OrderBy(n => n.Maloai), "Maloai", "Tenloai", dongho.Maloai);
            //ViewBag.Gioitinh = new SelectList(db.Gioitinhs.ToList().OrderBy(n => n.Namnu), "Namnu", "Gioitinh1",dongho.Namnu);
            return View(dongho);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SanPham dongho, HttpPostedFileBase fileUpLoad, int id)
        {
            var sua = db.SanPhams.First(n => n.Masp == id);
            ViewBag.Mansx = new SelectList(db.NhaSXes.ToList().OrderBy(n => n.Mansx), "Mansx", "Tennsx");
            ViewBag.Maloai = new SelectList(db.LoaiSPs.ToList().OrderBy(n => n.Maloai), "Maloai", "Tenloai");
            //ViewBag.Gioitinh = new SelectList(db.Gioitinhs.ToList().OrderBy(n => n.Namnu), "Namnu", "Gioitinh1");
            if (fileUpLoad == null)
            {
                ViewBag.Thongbao = "Vui long chon anh bia";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpLoad.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hinh anh da ton tai";
                    else
                    {
                        fileUpLoad.SaveAs(path);
                    }

                    sua.Anh = fileName;
                    sua.Masp = id;
                    UpdateModel(sua);
                    db.SubmitChanges();
                }
                return RedirectToAction("DongHo");
            }
        }
        
        
        
        
        
        //Loại Sản Phẩm
        public ActionResult LoaiSP()
        {
            return View(db.LoaiSPs.ToList());
        }
        [HttpGet]
        public ActionResult ThemLoaiSP()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemLoaiSP(LoaiSP dongho)
        {  
            db.LoaiSPs.InsertOnSubmit(dongho);
            db.SubmitChanges();
            return RedirectToAction("LoaiSP");
        }
        [HttpGet]
        public ActionResult XoaLoaiSP(int id)
        {
            LoaiSP dongho = db.LoaiSPs.SingleOrDefault(n => n.Maloai == id);
            ViewBag.Masp = dongho.Maloai;
            if (dongho == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dongho);
        }
        [HttpPost, ActionName("XoaLoaiSP")]
        public ActionResult XacnhanxoaLoaiSP(int id)
        {
            LoaiSP dongho = db.LoaiSPs.SingleOrDefault(n => n.Maloai == id);
            ViewBag.Masp = dongho.Maloai;
            if (dongho == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SanPham sp = db.SanPhams.FirstOrDefault(n => n.Maloai == id);
            if (sp != null)
            {

                Response.StatusCode = 404;
                return null;
               
                
            }
            else
            {
                db.LoaiSPs.DeleteOnSubmit(dongho);
                db.SubmitChanges();
                return RedirectToAction("LoaiSP");
            } 
       }
        [HttpGet]
        public ActionResult SuaLoaiSP(int id)
        {
            LoaiSP dongho = db.LoaiSPs.SingleOrDefault(m => m.Maloai == id);
            if (dongho == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dongho);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaLoaiSP(LoaiSP dongho, int id)
        {
            var sua = db.LoaiSPs.First(n => n.Maloai == id); 
            if (ModelState.IsValid)
            {
                UpdateModel(sua);
                db.SubmitChanges();
            }
            return RedirectToAction("LoaiSP");
            
        }



        //Nhà Sản Xuất
        public ActionResult NhaSX()
        {
            return View(db.NhaSXes.ToList());
        }
        [HttpGet]
        public ActionResult ThemNhaSX()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemNhaSX(NhaSX dongho)
        {
            db.NhaSXes.InsertOnSubmit(dongho);
            db.SubmitChanges();
            return RedirectToAction("NhaSX");
        }
        [HttpGet]
        public ActionResult XoaNhaSX(int id)
        {
            NhaSX dongho = db.NhaSXes.SingleOrDefault(n => n.Mansx == id);
            ViewBag.Masp = dongho.Mansx;
            if (dongho == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dongho);
        }
        [HttpPost, ActionName("XoaNhaSX")]
        public ActionResult XacnhanxoaLoaiNhaSX(int id)
        {
            NhaSX dongho = db.NhaSXes.SingleOrDefault(n => n.Mansx == id);
            ViewBag.Masp = dongho.Mansx;
            if (dongho == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SanPham sp = db.SanPhams.FirstOrDefault(n => n.Mansx== id);
            if (sp != null)
            {

                Response.StatusCode = 404;
                return null;


            }
            else
            {
                db.NhaSXes.DeleteOnSubmit(dongho);
                db.SubmitChanges();
                return RedirectToAction("NhaSX");
            }
        }

        [HttpGet]
        public ActionResult SuaNhaSX(int id)
        {
            NhaSX dongho = db.NhaSXes.SingleOrDefault(m => m.Mansx == id);
            if (dongho == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dongho);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaNhaSX(NhaSX dongho, int id)
        {
            var sua = db.NhaSXes.First(n => n.Mansx == id); 
            if (ModelState.IsValid)
            {
                UpdateModel(sua);
                db.SubmitChanges();
            }
            return RedirectToAction("NhaSX");

        }

        //Tai Khoang KH
        public ActionResult KhachHang()
        {
            return View(db.KhachHangs.ToList());
        }
        [HttpGet]
        public ActionResult XoaKH(int id)
        {
            KhachHang dongho = db.KhachHangs.SingleOrDefault(n => n.Makh == id);
            ViewBag.MaKH = dongho.Makh;
            if (dongho == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dongho);
        }
        [HttpPost, ActionName("XoaKH")]
        public ActionResult XacnhanxoaKH(int id)
        {
            KhachHang dongho = db.KhachHangs.SingleOrDefault(n => n.Makh == id);
            ViewBag.Masp = dongho.Makh;
            if (dongho == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            DonHang sp = db.DonHangs.FirstOrDefault(n => n.Makh == id);
            if (sp != null)
            {

                Response.StatusCode = 404;
                return null;


            }
            else
            {
                db.KhachHangs.DeleteOnSubmit(dongho);
                db.SubmitChanges();
                return RedirectToAction("KhachHang");
            }
        }




        //Thong kê
        public ActionResult TongTien()
        {
            var c = db.ChiTietDonHangs.Sum(x => x.Dongia);
            ViewBag.tien = c;
            return PartialView();

        }
        public ActionResult DHchuagui()
        {
           // var c = db.DonHangs.Count(x=>x.Tinhtrang==false);
            var c = (from p in db.DonHangs
                     where p.Tinhtrang == false && p.Thanhtoan ==false
                     select p).Count();

            ViewBag.dh = c;
            return PartialView();

        }
        public ActionResult SPhet()
        {
            var c = db.SanPhams.Count(x => x.Soluong < 5);
            ViewBag.het = c;
            return PartialView();
        }
        public ActionResult SLkhach()
        {
            var c = db.KhachHangs.Count();
            ViewBag.het = c;
            return PartialView();
        }
        

        
	}
}