using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DongHo.Models;

using PagedList;
using PagedList.Mvc;
namespace DongHo.Controllers
{
    public class DongHoController : Controller
    {
        dbQLDonghoDataContext data = new dbQLDonghoDataContext();
        //
        // GET: /DongHo/
        private List<SanPham> Layspmoi(int count)
        {
            return data.SanPhams.OrderByDescending(m => m.Masp).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var donghomoi = Layspmoi(4);
            return View(donghomoi);
        }
        private List<SanPham> Laysp()
        {
            return data.SanPhams.OrderByDescending(m => m.Masp).ToList();
        }
        public ActionResult Sanpham(int? page)
        {
            int PageSize = 8;
            int PageNum = (page ?? 1);
            
            var dongho = Laysp();
            return View(dongho.ToPagedList(PageNum, PageSize));
        }
        private List<SanPham> Donghonam(int count)
        {
            return data.SanPhams.Where(m => m.Maloai == 2).OrderByDescending(m => m.Masp).Take(count).ToList();
        }
        public ActionResult Spmuanhieu()
        {
            var dongho = Donghonam(4);
            return View(dongho);
        }
        private List<SanPham> Donghonu(int count)
        {
            return data.SanPhams.Where(m => m.Maloai == 3).OrderByDescending(m => m.Masp).Take(count).ToList();
        }
        public ActionResult Sanphamnu()
        {
            var dongho = Donghonu(4);
            return View(dongho);
        }
        public ActionResult Nhasx()
        {
            var Nhasx = from nsx in data.NhaSXes select nsx;
            return View(Nhasx);
        }
        public ActionResult SPTheonsx(int id)
        {
            var dongho = from dh in data.SanPhams where dh.Mansx == id select dh;
            return View(dongho);
        }
        public ActionResult Details(int id)
        {
            var chitiet = from s in data.SanPhams where s.Masp == id select s;
            return View(chitiet.Single());
        }
        
        public ActionResult Mapapi()
        {
            return View();
        }
        private List<SanPham> Timsp(string key)
        {
            return data.SanPhams.Where(m => m.Tensp.Contains(key)).ToList();
        }
        public ActionResult Timkiem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TimKiem(FormCollection collection)
        {
            string key = collection["text"];
            var sp = Timsp(key);
            return View(sp);
        }
        public ActionResult SanPhamLienQuan(int id)
        {
            var sp = data.SanPhams.SingleOrDefault(n => n.Masp == id);
            var loaisp = data.SanPhams.Where(n => n.LoaiSP.Maloai == sp.LoaiSP.Maloai).ToList();
            return PartialView(loaisp);
        }
	}
}