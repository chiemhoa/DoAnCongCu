using Models.Dao;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webtruyen.Areas.Admin.Controllers
{
    public class TruyenaudioController : BaseController
    {
        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            //var listT = new TruyenModel();
            //var model = listT.ListAll();
            var dao = new TruyenaudioDao();
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
        public ActionResult Create(TRUYENAUDIO truyen)
        {
            if (ModelState.IsValid)
            {
                var dao = new TruyenaudioDao();
               
                long id = dao.Insert(truyen);
                if (id > 0)
                {
                    //ModelState.AddModelError("", "Thêm thành công");
                    return RedirectToAction("Index", "Truyenaudio");
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
            var truyen = new TruyenaudioDao().ViewDetail(id);
           
            return View(truyen);
        }

        // POST: Admin/Truyen/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(TRUYENAUDIO truyen)
        {
            if (ModelState.IsValid)
            {
                var dao = new TruyenaudioDao();
                var result = dao.Update(truyen);
                
                if (result)
                {
                    return RedirectToAction("Index", "Truyenaudio");
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
            var truyen = new TruyenaudioDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}