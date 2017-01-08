using Models;
using Models.Dao;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webtruyen.Areas.Admin.Controllers
{
    public class TheloaiController : BaseController
    {
        // GET: Admin/Theloai
        public ActionResult Index()
        {
            var listTL = new TheLoaiDao();
            var model = listTL.ListAll();
            return View(model);
        }

        // GET: Admin/Theloai/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        // GET: Admin/Theloai/Create
        public ActionResult Create()
        {
            //setViewBag();
            return View();
        }

        // POST: Admin/Theloai/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(THELOAI theloai)
        {
            if (ModelState.IsValid)
            {
                var dao = new TheLoaiDao();
                //setViewBag();
                long id = dao.Insert(theloai);
                if (id > 0)
                {
                    //ModelState.AddModelError("", "Thêm thành công");
                    return RedirectToAction("Index", "Theloai");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }

            return View();
        }

        // GET: Admin/Theloai/Edit/5
        public ActionResult Edit(int id)
        {
            var theloai = new TheLoaiDao().ViewDetail(id);
            
            return View(theloai);
        }

        // POST: Admin/Theloai/Edit/5
        [HttpPost]

        [ValidateInput(false)]
        public ActionResult Edit(THELOAI theloai)
        {
            if (ModelState.IsValid)
            {
                var dao = new TheLoaiDao();
                var result = dao.Update(theloai);
                
                if (result)
                {
                    return RedirectToAction("Index", "Theloai");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View();
        }

        // GET: Admin/Theloai/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Admin/Theloai/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var theloai = new TheLoaiDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
