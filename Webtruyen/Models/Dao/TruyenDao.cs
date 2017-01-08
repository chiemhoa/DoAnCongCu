using Models.Framework;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.Dao
{
    


    public class TruyenDao
    {
        TruyenDbContext db = null;
        public TruyenDao()
        {
            db = new TruyenDbContext();
        }

        //-----Insert------------------------------
        public long Insert(TRUYEN entity)
        {
            try
            {
                entity.Ngaycapnhat = DateTime.Now;
                entity.Solandoc = 0;
                if(entity.Maloai==null)
                {
                    entity.Maloai = 1;
                }
                db.TRUYEN.Add(entity);
                db.SaveChanges();
             return entity.Matruyen;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        //-----Delete-----------------
        public bool Delete(int id)
        {
            try
            {
                var truyen = db.TRUYEN.Find(id);
                db.TRUYEN.Remove(truyen);
                db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }

            
        }

        
        public bool Update(TRUYEN entity)
        {
            try
            {
                var truyen = db.TRUYEN.Find(entity.Matruyen);
                truyen.Tentruyen = entity.Tentruyen;
                truyen.Tacgia = entity.Tacgia;
                truyen.Sochuong = entity.Sochuong;
                truyen.Anhbia = entity.Anhbia;
                truyen.Mota = entity.Mota;
                truyen.Maloai = entity.Maloai;
                truyen.Nguon = entity.Nguon;
                truyen.Tinhtrang = entity.Tinhtrang;
                truyen.Ngaycapnhat = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }



            
        }

        //----------------
        public bool UpdateSLD(TRUYEN entity)
        {
            try
            {
                var truyen = db.TRUYEN.Find(entity.Matruyen);
               
                truyen.Solandoc = entity.Solandoc+1;
               
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }




        }

        //----------------


        public TRUYEN GetById(string tenTruyen)
        {
            return db.TRUYEN.SingleOrDefault(x => x.Tentruyen == tenTruyen);
        }
        public TRUYEN ViewDetail(int maTruyen)
        {
            return db.TRUYEN.Find(maTruyen);
        }
        public IEnumerable<TRUYEN> ListAllpagelist(int page,int pageSize)
        {
            return db.TRUYEN.OrderBy(x=>x.Matruyen).ToPagedList(page, pageSize);
        }
        public List<TRUYEN> Listtruyenfull()
        {

            return db.TRUYEN.Where(x => x.Tinhtrang == "Hoàn thành").OrderByDescending(x => x.Solandoc).Take(12).ToList();
        }
        public List<TRUYEN> Listtruyenmoi()
        {

            return db.TRUYEN.Where(x => x.Tinhtrang != "Hoàn thành").OrderByDescending(x => x.Solandoc).OrderByDescending(x=>x.Ngaycapnhat).Take(12).ToList();
        }
        //============Partial truyen hot===================
        public IEnumerable<TRUYEN> TruyenhotPartial()
        {
            return db.TRUYEN.OrderByDescending(x => x.Solandoc).Take(10);
        }


        public List<CHUONG> ListtruyenAll(int id)
        {
            var list = db.Database.SqlQuery<CHUONG>("sp_dt_@id", id).ToList();
            return list;
        }
        //======Lấy mã trước và tiếp======================
        public int Laymachuongtruoc(int? maT,int? ttc)
        {
            var chuong = db.CHUONG.SingleOrDefault(x => x.Matruyen == maT && x.Thutuchuong == ttc - 1);
            
            if(chuong==null)
            {
                return 0;
            }

            return chuong.Machuong;
        }
        public int Laymachuongtiep(int? maT, int? ttc)
        {
            var chuong = db.CHUONG.SingleOrDefault(x => x.Matruyen == maT && x.Thutuchuong == ttc + 1);
            if (chuong == null)
            {
                return 0;
            }
            return chuong.Machuong;
        }

        //======TIM KIEM===================================
        public List<TRUYEN> TruyentheoTL(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id",id),
            
            };
            var list = db.Database.SqlQuery<TRUYEN>("sp_tk_tl @id",sqlParams).ToList();
            return list;


        }
        public IEnumerable<TRUYEN> TruyentheoTLPagedList(int id,int page, int pageSize)
        {
            object[] sqlParams =
           {
                new SqlParameter("@id",id),

            };
            var list=db.Database.SqlQuery<TRUYEN>("sp_tk_tl @id", sqlParams).OrderBy(x=>x.Matruyen).ToList().ToPagedList(page, pageSize);
            return list;

        }

        public IEnumerable<TRUYEN> ListTabcpagelist(int page, int pageSize)
        {
            return db.TRUYEN.OrderBy(x => x.Tentruyen).ToPagedList(page, pageSize);
        }

        public IEnumerable<TRUYEN> ListTMpagelist(int page, int pageSize)
        {
            return db.TRUYEN.OrderByDescending(x => x.Ngaycapnhat).ToPagedList(page, pageSize);
        }
        public IEnumerable<TRUYEN> ListTHpagelist(int page, int pageSize)
        {
            return db.TRUYEN.OrderByDescending(x => x.Solandoc).ToPagedList(page, pageSize);
        }
        public IEnumerable<TRUYEN> ListTTGpagelist(string tg,int page, int pageSize)
        {
            object[] sqlParams =
           {
                new SqlParameter("@tg",tg),

            };
            var list = db.Database.SqlQuery<TRUYEN>("sp_tk_ttg @tg", sqlParams).OrderBy(x => x.Matruyen).ToList().ToPagedList(page, pageSize);
            return list;
        }
        public IEnumerable<TRUYEN> ListTCTG(string tg)
        {
            object[] sqlParams =
           {
                new SqlParameter("@tg",tg),

            };
            var list = db.Database.SqlQuery<TRUYEN>("sp_tk_ttg @tg", sqlParams).OrderBy(x => x.Matruyen).Take(10);
            return list;
        }
        public List<ChuongmoinhatViewModel> Chuongmoinhat()
        {
            //var model = from a in db.CHUONG
            //            join b in db.TRUYEN
            //            on a.Matruyen equals b.Matruyen
            //            where a.Matruyen == b.Matruyen
            //            select new ChuongmoinhatViewModel()
            //            {
            //                Matruyen = b.Matruyen,
            //                Tentruyen=b.Tentruyen,
            //                Tacgia=b.Tacgia,
            //                Sochuong=b.Sochuong,
            //                Anhbia=b.Anhbia,
            //                Tinhtrang=b.Tinhtrang,
            //                Solandoc=b.Solandoc,
            //                Machuong=a.Machuong,
            //                Tenchuong=a.Tenchuong,
            //                Thutuchuong=a.Thutuchuong,
            //                Capnhatchuong =a.Capnhatchuong
            //            };
            //model.OrderByDescending(x => x.Capnhatchuong).OrderByDescending(x => x.Thutuchuong).ToList();
           var list = db.Database.SqlQuery<ChuongmoinhatViewModel>("sp_show_cmn").ToList();
            return list;
        }


        public IEnumerable<TRUYEN> ListTtheoloaipagelist(int id,int page, int pageSize)
        {
            return db.TRUYEN.Where(x=>x.Maloai==id).OrderBy(x => x.Tentruyen).ToPagedList(page, pageSize);
        }

        public IEnumerable<TRUYEN> ListOTKpagelist(string tk, int page, int pageSize)
        {


            var list= db.TRUYEN.Where(x => x.Tentruyen.Contains(tk) || x.Tacgia.Contains(tk)).OrderBy(x => x.Tentruyen).ToPagedList(page, pageSize);
            //list = db.TRUYEN.Where(x => x.Tacgia.Contains(tk)).OrderBy(x => x.Tentruyen).ToPagedList(page, pageSize);
            //    list=(TimkiemtruyenViewModel)db.TRUYENAUDIO.Where(x => x.Tentruyen.Contains(tk)).OrderBy(x => x.Tentruyen).ToPagedList(page, pageSize);
            //list = (TimkiemtruyenViewModel)db.TRUYENAUDIO.Where(x => x.Tacgia.Contains(tk)).OrderBy(x => x.Tentruyen).ToPagedList(page, pageSize);
            //list = (TimkiemtruyenViewModel)db.TRUYENTRANH.Where(x => x.Tentruyen.Contains(tk)).OrderBy(x => x.Tentruyen).ToPagedList(page, pageSize);
            //list = (TimkiemtruyenViewModel)db.TRUYENTRANH.Where(x => x.Tacgia.Contains(tk)).OrderBy(x => x.Tentruyen).ToPagedList(page, pageSize);
            return list;
        }
        //============Thống kê trang chủ==================
        public List<TRUYEN> TKtruyenchuhot()
        {
            return db.TRUYEN.OrderByDescending(x => x.Solandoc).Take(10).ToList();
        }
        public List<TRUYENAUDIO> TKtruyenaudiohot()
        {
            return db.TRUYENAUDIO.OrderByDescending(x => x.Solandoc).Take(10).ToList();
        }
        public List<TRUYENTRANH> TKtruyentranhhot()
        {
            return db.TRUYENTRANH.OrderByDescending(x => x.Solandoc).Take(10).ToList();
        }

    }
}
