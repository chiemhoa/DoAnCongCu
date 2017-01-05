using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.Dao
{
    public class ChuongDao
    {
        TruyenDbContext db = null;
        public ChuongDao()
        {
            db = new TruyenDbContext();
        }



        //---Insert-------------------------
        public long Insert(CHUONG entity,int maT)
        {
            entity.Matruyen = maT;
            entity.Capnhatchuong = DateTime.Now;
            db.CHUONG.Add(entity);
            db.SaveChanges();
            return entity.Machuong;
        }


        //-------Update------------------------------------
        public bool Update(CHUONG entity)
        {
            try
            {
                var chuong = db.CHUONG.Find(entity.Machuong);
                chuong.Tenchuong = entity.Tenchuong;
                chuong.Thutuchuong = entity.Thutuchuong;
                // chuong.Matruyen = entity.Matruyen;
                chuong.Noidong = entity.Noidong;
                chuong.Capnhatchuong = DateTime.Now;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CHUONG GetById(string tenChuong, int maTruyen)
        {
            if(db.CHUONG.SingleOrDefault(x => x.Matruyen == maTruyen)!=null)
            {
                return db.CHUONG.SingleOrDefault(x => x.Tenchuong == tenChuong);
            }
            return null;
        }

        public bool Delete(int id)
        {
            try
            {
                var chuong = db.CHUONG.Find(id);
                db.CHUONG.Remove(chuong);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public CHUONG ViewDetail(int maChuong)
        {
            return db.CHUONG.Find(maChuong);
        }
        public int Laymatruyen(int maC)
        {
            CHUONG ch = ViewDetail(maC);
            return ch.Matruyen.GetValueOrDefault();
        }
        public List<CHUONG> ListByChuongId(int maTruyen)
        {
            return db.CHUONG.Where(x => x.Matruyen == maTruyen).ToList();
        }
        //listAll phân trang
        public IEnumerable<CHUONG> ListAllpagelist(int maT,int page, int pageSize)
        {
            return db.CHUONG.Where(x=>x.Matruyen==maT).OrderBy(x => x.Thutuchuong).ToPagedList(page, pageSize);
        }

    }
}
