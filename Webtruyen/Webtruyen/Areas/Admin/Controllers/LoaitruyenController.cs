using Models.Dao;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webtruyen.Areas.Admin.Controllers
{
    public class LoaitruyenController : BaseController
    {
        // GET: Admin/Loaitruyen
        public ActionResult Index()
        {
            var listTL = new LoaitruyenDao();
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
        public ActionResult Create(LOAITRUYEN lt)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaitruyenDao();
                //setViewBag();
                long id = dao.Insert(lt);
                if (id > 0)
                {
                    //ModelState.AddModelError("", "Thêm thành công");
                    return RedirectToAction("Index", "Loaitruyen");
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
            var lt = new LoaitruyenDao().ViewDetail(id);

            return View(lt);
        }

        // POST: Admin/Theloai/Edit/5
        [HttpPost]

        [ValidateInput(false)]
        public ActionResult Edit(LOAITRUYEN lt)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaitruyenDao();
                var result = dao.Update(lt);

                if (result)
                {
                    return RedirectToAction("Index", "Loaitruyen");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View();
        }

        //GET: Admin/Theloai/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Admin/Theloai/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            bool lt = new LoaitruyenDao().Delete(id);
            ViewBag.lt = lt;
            if (lt==false)
            {
                return Content("Không thể xóa");

            }
            else
            {
                return RedirectToAction("Index");
            }
            
           
        }
    }
}