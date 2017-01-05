using Models;
using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.Owin;

namespace Webtruyen.Controllers
{
    public class TimkiemController : Controller
    {
        // GET: Timkiem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Timkiemtheloai(int id, int page = 1, int pageSize = 10)
        {
            var tk = new TruyenDao().TruyentheoTLPagedList(id, page, pageSize);
            ViewBag.maTL = new TheLoaiDao().ViewDetail(id);
            ViewBag.sl=new TruyenDao().TruyentheoTL(id).Count();
                return View(tk);
        }
        public ActionResult Timkiemtruyenabc(int page = 1, int pageSize = 10)
        {
            var tk = new TruyenDao().ListTabcpagelist(page, pageSize);
            // ViewBag.sl =tk.Count();
            return View(tk);
        }
        public ActionResult Timkiemtruyenmoi(int page =1, int pageSize=10)
        {
            var tk = new TruyenDao().ListTMpagelist(page,pageSize);
           // ViewBag.sl =tk.Count();
            return View(tk);
        }
        public ActionResult Timkiemtruyenhot(int page = 1, int pageSize = 10)
        {
            var tk = new TruyenDao().ListTHpagelist(page, pageSize);
            return View(tk);
        }
        public ActionResult Timkiemtruyentacgia(string tg,int page = 1, int pageSize = 10)
        {
            var tk = new TruyenDao().ListTTGpagelist(tg,page, pageSize);
            ViewBag.tg = tg;
            return View(tk);
        }
        public ActionResult Timkiemloaitruyen(int id, int page = 1, int pageSize = 10)
        {
            var tk = new TruyenDao().ListTtheoloaipagelist(id, page, pageSize);
            ViewBag.loai = new LoaitruyenDao().ViewDetail(id);
            //ViewBag.sl = new TruyenDao().TruyentheoTL(id).Count();
            return View(tk);
        }
        //====================================
        public ActionResult Timkiemtruyenaudio(int page = 1, int pageSize = 10)
        {
            var tk = new TruyenaudioDao().ListAllpagelist(page, pageSize);
            return View(tk);
        }
        public ActionResult Timkiemtruyentranh(int page = 1, int pageSize = 10)
        {
            var tk = new TruyentranhDao().ListAllpagelist(page, pageSize);
            return View(tk);
        }
        public ActionResult Timkiemtukhoa(string q, int page = 1, int pageSize = 10)
        {
            //string tk = f["q"].ToString();

            var t = new TruyenDao().ListOTKpagelist(q, page, pageSize);
            ViewBag.tk = q;

            return View(t);
        }


    }
}