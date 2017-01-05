using Models;
using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webtruyen.Controllers
{
    public class HomeClientController : Controller
    {
        // GET: HomeClient
        public ActionResult Index()
        {
            //var listT = new TruyenModel();
            //var model = listT.ListAll();
            var model = new TruyenDao().Listtruyenfull();
            ViewBag.truyenmoi = new TruyenDao().Listtruyenmoi();
            ViewBag.Chuongmoinhat = new TruyenDao().Chuongmoinhat();
            return View(model);
        }
        //menu
        //[ChildActionOnly]
        public ActionResult _TheloaiPartial()
        {
            var model = new TheLoaiDao().ListAll();
            return PartialView(model);
        }
        public ActionResult TruyenhotPartial()
        {
            var model = new TruyenDao().TruyenhotPartial();
            return PartialView(model);
        }
        public ActionResult LoaitruyenPartial()
        {
            var model = new LoaitruyenDao().ListAll();
            return PartialView(model);
        }
        public ActionResult OtimkiemPartial()
        {
            return View();
        }



    }
}