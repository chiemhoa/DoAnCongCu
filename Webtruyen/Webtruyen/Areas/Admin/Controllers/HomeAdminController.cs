using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webtruyen.Areas.Admin.Controllers
{
    public class HomeAdminController : BaseController
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            
            ViewBag.truyenchu = new TruyenDao().TKtruyenchuhot();
            ViewBag.truyenaudio = new TruyenDao().TKtruyenaudiohot();
            ViewBag.truyentranh = new TruyenDao().TKtruyentranhhot();
            return View();
        }
    }
}