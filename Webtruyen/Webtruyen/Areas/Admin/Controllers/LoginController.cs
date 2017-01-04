using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webtruyen.Areas.Admin.Code;
using Webtruyen.Areas.Admin.Models;
using Models;
using Models.Dao;

namespace Webtruyen.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new TaikhoanModel().Login(model.UserName, model.Passwork);
            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                return RedirectToAction("Index", "HomeAdmin");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View(model);
        }


       
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = new TaikhoanDao().Login(model.UserName, model.Passwork);
                if (result && ModelState.IsValid)
                {
                    var user = new TaikhoanDao().GetbyId(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Tendangnhap;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng điền đầy đủ thông tin");
            }
            return View("Index");
        }
    }
}