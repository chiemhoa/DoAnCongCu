using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class TruyenaudioDao
    {
        TruyenDbContext db = null;
        public TruyenaudioDao()
        {
            db = new TruyenDbContext();
        }
        //-----Insert------------------------------
        public long Insert(TRUYENAUDIO entity)
        {
            try
            {
                entity.Ngaycapnhat = DateTime.Now;
                entity.Solandoc = 0;
                
                db.TRUYENAUDIO.Add(entity);
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
                var truyen = db.TRUYENAUDIO.Find(id);
                db.TRUYENAUDIO.Remove(truyen);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        public bool Update(TRUYENAUDIO entity)
        {
            try
            {
                var truyen = db.TRUYENAUDIO.Find(entity.Matruyen);
                truyen.Tentruyen = entity.Tentruyen;
                truyen.Tacgia = entity.Tacgia;
                
                truyen.Anhbia = entity.Anhbia;
                truyen.Mota = entity.Mota;
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
        public bool UpdateSLD(TRUYENAUDIO entity)
        {
            try
            {
                var truyen = db.TRUYENAUDIO.Find(entity.Matruyen);

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


        public TRUYENAUDIO GetById(string tenTruyen)
        {
            return db.TRUYENAUDIO.SingleOrDefault(x => x.Tentruyen == tenTruyen);
        }
        public TRUYENAUDIO ViewDetail(int maTruyen)
        {
            return db.TRUYENAUDIO.Find(maTruyen);
        }
        public IEnumerable<TRUYENAUDIO> ListAllpagelist(int page, int pageSize)
        {
            return db.TRUYENAUDIO.OrderBy(x => x.Tentruyen).ToPagedList(page, pageSize);
        }
        public List<TRUYENAUDIO> List10truyenaudio()
        {
            return db.TRUYENAUDIO.OrderByDescending(x => x.Ngaycapnhat).OrderByDescending(x=>x.Solandoc).Take(10).ToList();
        }
    }
}
