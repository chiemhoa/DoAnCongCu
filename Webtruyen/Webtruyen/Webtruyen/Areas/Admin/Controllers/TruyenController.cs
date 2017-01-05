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
    public class TruyenController : BaseController//chinh dang nhap
    {
        // GET: Admin/Truyen
        [HttpGet]
        public ActionResult Index(int page= 1,int pageSize =10)
        {
            //var listT = new TruyenModel();
            //var model = listT.ListAll();
            var dao = new TruyenDao();
            var model = dao.ListAllpagelist(page, pageSize);
            return View(model);
        }

        // GET: Admin/Truyen/Details/5
        
        public ActionResult Details(int id, int page = 1, int pageSize = 10)
        {
            ViewBag.truyen = new TruyenDao().ViewDetail(id);
            ViewBag.theloai = new TruyentheloaiDao().ListTLT(id);
            ViewBag.Page = page;
            //var truyen = new TruyenDao().ViewDetail(id);
            var listC = new ChuongDao().ListAllpagelist(id, page, pageSize);
            return View(listC);
        }

        

        // GET: Admin/Truyen/Create
        [HttpGet]

        public ActionResult Create()
        {
            setViewBag();
            return View();
        }

        // POST: Admin/Truyen/Create
        [HttpPost]
     
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(TRUYEN truyen)
        {
            if(ModelState.IsValid)
            {
                var dao = new TruyenDao();
                setViewBag();
                long id = dao.Insert(truyen);
                if(id>0)
                {
                    //ModelState.AddModelError("", "Thêm thành công");
                    return RedirectToAction("Index", "Theloaitruyen",new { id = truyen.Matruyen});
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
            var dao= new LoaitruyenDao();
            try
            {
                ViewBag.Maloai = new SelectList(dao.ListAll(), "Maloai", "Tenloai", selectedId);
            }catch
            { Exception ex; }
            

        }


        // GET: Admin/Truyen/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var truyen = new TruyenDao().ViewDetail(id);
            setViewBag(truyen.Maloai);
            return View(truyen);
        }

        // POST: Admin/Truyen/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(TRUYEN truyen)
        {
            if (ModelState.IsValid)
            {
                var dao = new TruyenDao();
                var result = dao.Update(truyen);
                setViewBag(truyen.Maloai);
                if (result)
                {
                    return RedirectToAction("Index", "Truyen");
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
            var truyen = new TruyenDao().Delete(id);
            return RedirectToAction("Index");
        }






        // POST: Admin/Truyen/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
