using Models.Dao;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webtruyen.Areas.Admin.Controllers
{
    public class TruyentranhController : BaseController
    {
        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            //var listT = new TruyenModel();
            //var model = listT.ListAll();
            var dao = new TruyentranhDao();
            var model = dao.ListAllpagelist(page, pageSize);
            return View(model);
        }


        // GET: Admin/Truyen/Create
        [HttpGet]

        public ActionResult Create()
        {

            return View();
        }

        // POST: Admin/Truyen/Create
        [HttpPost]

        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(TRUYENTRANH truyen)
        {
            if (ModelState.IsValid)
            {
                var dao = new TruyentranhDao();

                long id = dao.Insert(truyen);
                if (id > 0)
                {
                    //ModelState.AddModelError("", "Thêm thành công");
                    return RedirectToAction("Index", "Truyentranh");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }

            return View();

        }

        // GET: Admin/Truyen/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var truyen = new TruyentranhDao().ViewDetail(id);

            return View(truyen);
        }

        // POST: Admin/Truyen/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(TRUYENTRANH truyen)
        {
            if (ModelState.IsValid)
            {
                var dao = new TruyentranhDao();
                var result = dao.Update(truyen);

                if (result)
                {
                    return RedirectToAction("Index", "Truyentranh");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View();
        }

        // GET: Admin/Truyen/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var truyen = new TruyentranhDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}