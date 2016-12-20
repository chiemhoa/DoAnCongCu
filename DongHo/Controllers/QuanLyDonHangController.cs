using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DongHo.Models;
using System.Net;
using System.Net.Mail;

namespace DongHo.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        //
        // GET: /QuanLyDonHang/
        dbQLDonghoDataContext db = new dbQLDonghoDataContext();
        public ActionResult ChuaThanhToan()
        {
            //L?y danh sách các don hàng Chua duy?t
            var lst = db.DonHangs.Where(n => n.Thanhtoan == false).OrderBy(n => n.Ngaydat);
            return View(lst);
        }
        public ActionResult ChuaGiao()
        {
            //L?y danh sách don hàng chua giao 
            var lstDSDHCG = db.DonHangs.Where(n => n.Tinhtrang == false && n.Thanhtoan == true).OrderBy(n => n.Ngaygiao);
            return View(lstDSDHCG);
        }
        public ActionResult DaGiaoDaThanhToan()
        {
            //L?y danh sách don hàng chua giao 
            var lstDSDHCG = db.DonHangs.Where(n => n.Tinhtrang == true && n.Thanhtoan == true);
            return View(lstDSDHCG);
        }

        [HttpGet]
        public ActionResult DuyetDonHang(int? id)
        {
            //Ki?m tra xem id h?p l? không
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang model = db.DonHangs.SingleOrDefault(n => n.Madh == id);
            //Ki?m tra don hàng có t?n t?i không
            if (model == null)
            {
                return HttpNotFound();
            }
            //L?y danh sách chi ti?t don hàng d? hi?n th? cho ngu?i dùng th?y
            var lstChiTietDH = db.ChiTietDonHangs.Where(n => n.Madh == id);
            ViewBag.ListChiTietDH = lstChiTietDH;
            return View(model);
        }
        [HttpPost]
        public ActionResult DuyetDonHang(DonHang ddh)
        {
            //Truy v?n l?y ra d? li?u c?a don hàn dó 
            DonHang ddhUpdate = db.DonHangs.Single(n => n.Madh == ddh.Madh);
            ddhUpdate.Thanhtoan = ddh.Thanhtoan;
            ddhUpdate.Tinhtrang = ddh.Tinhtrang;
            db.SubmitChanges();

            //L?y danh sách chi ti?t don hàng d? hi?n th? cho ngu?i dùng th?y
            var lstChiTietDH = db.ChiTietDonHangs.Where(n => n.Madh == ddh.Madh);
            ViewBag.ListChiTietDH = lstChiTietDH;
            //G?i khách hàng 1 mail d? xác nh?n vi?c thanh toán 
            //GuiEmail("Xác don hàng ", "chiemhoa99@gmail.com", "ksshop.com.vn@gmail.com", "google123456", "Đon hàng của bạn đã đươc đặt thành công!");
            return View(ddhUpdate);
        }
        //public void GuiEmail(string Title, string ToEmail, string FromEmail, string PassWord, string Content)
        //{
        //    // goi email
        //    MailMessage mail = new MailMessage();
        //    mail.To.Add(ToEmail); // Đ?a ch? nh?n
        //    mail.From = new MailAddress(ToEmail); // Đ?a ch?i g?i
        //    mail.Subject = Title;  // tiêu d? g?i
        //    mail.Body = Content;                 // N?i dung
        //    mail.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com"; // host g?i c?a Gmail
        //    smtp.Port = 587;               //port c?a Gmail
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = new System.Net.NetworkCredential
        //    (FromEmail, PassWord);//Tài kho?n password ngu?i g?i
        //    smtp.EnableSsl = true;   //kích ho?t giao ti?p an toàn SSL
        //    smtp.Send(mail);   //G?i mail di
        //}
	}
}