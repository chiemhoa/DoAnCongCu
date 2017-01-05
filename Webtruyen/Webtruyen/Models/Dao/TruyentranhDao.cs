using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class TruyentranhDao
    {
        TruyenDbContext db = null;
        public TruyentranhDao()
        {
            db = new TruyenDbContext();
        }
        //-----Insert------------------------------
        public long Insert(TRUYENTRANH entity)
        {
            try
            {
                entity.Ngaycapnhat = DateTime.Now;
                entity.Solandoc = 0;

                db.TRUYENTRANH.Add(entity);
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
                var truyen = db.TRUYENTRANH.Find(id);
                db.TRUYENTRANH.Remove(truyen);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        public bool Update(TRUYENTRANH entity)
        {
            try
            {
                var truyen = db.TRUYENTRANH.Find(entity.Matruyen);
                truyen.Tentruyen = entity.Tentruyen;
                truyen.Tacgia = entity.Tacgia;

                truyen.Anhbia = entity.Anhbia;
                //truyen.Mota = entity.Mota;
                truyen.Duongdan = entity.Duongdan;
                truyen.Nguon = entity.Nguon;

                truyen.Ngaycapnhat = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }




        }

        //----------------
        public bool UpdateSLD(TRUYENTRANH entity)
        {
            try
            {
                var truyen = db.TRUYENTRANH.Find(entity.Matruyen);

                truyen.Solandoc = entity.Solandoc + 1;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }




        }

        //----------------


        public TRUYENTRANH GetById(string tenTruyen)
        {
            return db.TRUYENTRANH.SingleOrDefault(x => x.Tentruyen == tenTruyen);
        }
        public TRUYENTRANH ViewDetail(int maTruyen)
        {
            return db.TRUYENTRANH.Find(maTruyen);
        }
        public IEnumerable<TRUYENTRANH> ListAllpagelist(int page, int pageSize)
        {
            return db.TRUYENTRANH.OrderBy(x => x.Tentruyen).ToPagedList(page, pageSize);
        }
        public List<TRUYENTRANH> List10truyenaudio()
        {
            return db.TRUYENTRANH.OrderByDescending(x => x.Ngaycapnhat).OrderByDescending(x => x.Solandoc).Take(10).ToList();
        }
    }
}
