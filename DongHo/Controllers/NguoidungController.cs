using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DongHo.Models;
namespace DongHo.Controllers
{
    public class NguoidungController : Controller
    {
        dbQLDonghoDataContext db = new dbQLDonghoDataContext();
        //
        // GET: /Nguoidung/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, KhachHang kh)
        {
            var hoten=collection["HotenKH"];
            var tendn=collection["TenDN"];
            var matkhau=collection["Matkhau"];
            var matkhaunhaplai=collection["Matkhaunhaplai"];
            var diachi=collection["DiaChi"];
            var email=collection["Email"];
            var dienthoai=collection["Dienthoai"];
            var ngaysinh = string.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);

            var mail = db.KhachHangs.SingleOrDefault(n => n.Email == email);
            if(String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên không được để trống";
            }
            else
                if(String.IsNullOrEmpty(tendn))
                {
                    ViewData["Loi2"] = "Tên đăng nhập không được để trống";
                }
                else
                    if (String.IsNullOrEmpty(matkhau))
                    {
                        ViewData["Loi3"] = "Mật khẩu không được để trống";
                    }
                    else
                        if (String.IsNullOrEmpty(matkhaunhaplai))
                        {
                            ViewData["Loi4"] = "Mật khẩu nhập lại không được để trống";
                        }
                        else
                            if (String.IsNullOrEmpty(matkhaunhaplai))
                            {
                                ViewData["Loi4"] = "Mật khẩu nhập lại không được để trống";
                            }
                            else if (String.IsNullOrEmpty(email))
                                {
                                    ViewData["Loi5"] = "Email không được để trống";
                                }
                                else if (String.IsNullOrEmpty(email))
                                {
                                    ViewData["Loi5"] = "Email không được để trống";
                                }
                                    else if (String.IsNullOrEmpty(diachi))
                                    {
                                        ViewData["Loi6"] = "Địa chỉ không được để trống";
                                    }
                                            else if(matkhau!=matkhaunhaplai)
                                            {
                                                ViewBag.ThongBao = "Mật khẩu nhập lại không đúng";
                                            }
                                                    
                                                else if(mail!=null)
                                                     {
                                                         ViewBag.ThongBao = "Email đã tồn tại";
                                                     }

                                                    else  {
                                                            kh.Tenkh = hoten;
                                                            kh.Taikhoan = tendn;
                                                            kh.Matkhau = matkhau;
                                                            kh.Diachi = diachi;
                                                            kh.Dienthoai = dienthoai;
                                                            kh.Ngaysinh = DateTime.Parse(ngaysinh);
                                                            db.KhachHangs.InsertOnSubmit(kh);
                                                            db.SubmitChanges();
                                                            ViewBag.ThongBao = "Đăng ký thành công";
                                                            //return RedirectToAction("Dangnhap");
                                                        }
            return this.Dangky();
                           
        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Ko được trống";
            }
            else if (String.IsNullOrEmpty(matkhau))
                {
                    ViewData["Loi2"] = "Ko được trống";
                }
                else
                {
                    KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.Taikhoan == tendn && n.Matkhau == matkhau);
                    
                    if (kh != null)
                    {
                        ViewBag.Thongbao = "Đăng nhập thành công";
                        Session["Taikhoan"] = kh;
                        Session["Tenkh"] = kh.Tenkh;
                        return RedirectToAction("Index", "DongHo");
                        
                        
                    }
                    else
                    {
                        ViewBag.Thongbao = "Đăng nhập thất bại";
                    }
                }
            return View();
        }
        public ActionResult Loginout()
        {
            if(Session["Taikhoan"]!=null)
            {
                ViewBag.Login = null;
            }
            else
            {
                ViewBag.Login = "Đăng Nhập";
            }
            if (Session["Taikhoan"] == null)
            {
                ViewBag.Logout = null;
            }
            else
            {
                ViewBag.Logout = "Đăng Xuất";
            }
            return PartialView();
        }
        
        public ActionResult Tenkh()
        {
            

            if (Session["Tenkh"] != null)
            {
                var ten = db.KhachHangs.Where(m => m.Tenkh == Session["Tenkh"]).First();
                var tenkh = ten.Tenkh;
                ViewBag.TenKhachHang = tenkh;

            }
            return PartialView();

        }
        public ActionResult Logout()
        {
            Session.Remove("Taikhoan");
            Session.Remove("Tenkh");
            return View("Dangnhap");
        }
	}
}