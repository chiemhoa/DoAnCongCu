using Models.Dao;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webtruyen.Areas.Admin.Controllers
{
    public class TheloaitruyenController : BaseController
    {
        // GET: Admin/Theloaitruyen
        public ActionResult Index(int id)
        {
            //var model = new TruyentheloaiDao().ListTLT(id);
            ViewBag.theloaitruyen = new TruyentheloaiDao().ListTLT(id);
            ViewBag.mattruyen = id;
            return View();
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            setViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(TRUYEN_TL entity,int id)
        {
            if (ModelState.IsValid)
            {
                var dao = new TruyentheloaiDao();
               
                setViewBag();
                long flat = dao.Insert(entity,id);
                if (flat > 0)
                {
                    ModelState.AddModelError("", "Thêm thành công");
                    return RedirectToAction("Index", "Theloaitruyen",new { id= id });
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
    
            return View();
        }
        public void setViewBag(int? selectedId = null)
        {
            var dao = new TheLoaiDao();
            ViewBag.Matheloai = new SelectList(dao.ListAll(), "Matheloai", "Tentheloai", selectedId);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ttl = new TruyentheloaiDao().ViewDetail(id);
            setViewBag();
            return View(ttl);
        }
        [HttpPost]
        public ActionResult Edit(TRUYEN_TL entity, int id)
        {
            if (ModelState.IsValid)
            {
                var dao = new TruyentheloaiDao();
                setViewBag();
                bool flat = dao.Update(entity);
                if (flat)
                {
                    ModelState.AddModelError("", "Cập nhật thành công");
                    return RedirectToAction("Index", "Theloaitruyen", new { id = id });
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }

            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var truyen = new TruyentheloaiDao().Delete(id);
            return View();
        }



    }
}