using Models;
using Models.Dao;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Webtruyen.Areas.Admin.Controllers;

namespace Webtruyen.Areas.Admin.Controllers
{
    public class ChuongController : BaseController
    {
        // GET: Admin/Chuong
        public ActionResult Index()
        {
             
            var listC = new ChuongModel();
            var model = listC.ListAll();
            return View(model);

        }

        // GET: Admin/Chuong/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult ChuongtrongtruyenPartial(int id, int page = 1, int pageSize = 5)
        {

           var listC = new ChuongDao().ListAllpagelist(id,page,pageSize);
            ViewBag.dsC = listC;
            ViewBag.maT = new TruyenDao().ViewDetail(id);
            return PartialView(listC);
        }




        // GET: Admin/Chuong/Create
        [HttpGet]
        public ActionResult Create(int id)
        {
            //ViewBag.maT = id;
            return View();        
        }

        // POST: Admin/Chuong/Create
        [HttpPost]

        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(CHUONG chuong,int id)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChuongDao();
                //string maT = Request["matruyen"];
                //int ma = Int32.Parse(maT);
                long flat = dao.Insert(chuong,id);
                if (flat > 0)
                {
                    return RedirectToAction("Details", "Truyen", new { id = id });
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }

            return View();
        }

        // GET: Admin/Chuong/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var chuong = new ChuongDao().ViewDetail(id);
            return View(chuong);
        }

        // POST: Admin/Chuong/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(CHUONG chuong)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChuongDao();
                var result = dao.Update(chuong);
                if (result)
                {
                    return RedirectToAction("Details", "Truyen",new { id = chuong.Matruyen });
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View();
        }

        // GET: Admin/Chuong/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Admin/Chuong/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            bool flat = new ChuongDao().Delete(id);
            if(!flat)
            {
                ModelState.AddModelError("", "Xóa không thành công");
            }
            return View();
        }
    }
}
