using Models.Dao;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Webtruyen.Controllers
{
    public class DoctruyenController : Controller
    {
        // GET: Doctruyen
        public ActionResult Chitiettruyen(int id, int page = 1, int pageSize = 15)
        {    

             var truyen = new TruyenDao().ViewDetail(id);
            var flat = new TruyenDao().UpdateSLD(truyen);
            ViewBag.truyen = truyen;
            ViewBag.theloai = new TruyentheloaiDao().ListTLT(id);
            //var t = new TruyenDao().ViewDetail(id);
            ViewBag.Page = page;
            ViewBag.Cungtacgia = new TruyenDao().ListTCTG(truyen.Tacgia);

            var listC = new ChuongDao().ListAllpagelist(id, page, pageSize);
            return View(listC);
        }

        public ActionResult ChuongtruyenPartial(int id)
        {
            List<CHUONG>  listC= new ChuongDao().ListByChuongId(id);
            return PartialView(listC);
        }


        public ActionResult DocChuong(int id)
        {
            
            CHUONG chuong = new ChuongDao().ViewDetail(id);

            int maT = chuong.Matruyen.GetValueOrDefault();

            ViewBag.chuongT = chuong;
            ViewBag.truyen = new TruyenDao().ViewDetail(maT);
            ViewBag.listC = new ChuongDao().ListByChuongId(maT);

            var tr = new TruyenDao().ViewDetail(maT);
            ViewBag.chuongtruoc = new TruyenDao().Laymachuongtruoc(chuong.Matruyen, chuong.Thutuchuong);
            ViewBag.chuongtiep = new TruyenDao().Laymachuongtiep(chuong.Matruyen, chuong.Thutuchuong);
            ViewBag.Tentruyen = tr.Tentruyen;
            

            return View(chuong);
        }
        public ActionResult TentruyenPartial(int id)
        {
            var truyen = new TruyenDao().ViewDetail(id);
            return View(truyen);
        }
        public ActionResult CungtacgiaPartial(string tg)
        {
            var tk = new TruyenDao().ListTCTG(tg);
            return View(tk);
        }

        //====================================================

       
    }
}