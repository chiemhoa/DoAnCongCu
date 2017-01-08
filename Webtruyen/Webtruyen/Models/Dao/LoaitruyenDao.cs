using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class LoaitruyenDao
    {
        TruyenDbContext db = null;
        public LoaitruyenDao()
        {
            db = new TruyenDbContext();
        }

        public List<LOAITRUYEN> ListAll()
        {
            return db.LOAITRUYEN.ToList();
        }
        public LOAITRUYEN ViewDetail(int ma)
        {
            return db.LOAITRUYEN.Find(ma);
        }
        //-----Insert------------------------------
        public long Insert(LOAITRUYEN entity)
        {

            db.LOAITRUYEN.Add(entity);
            db.SaveChanges();
            return entity.Maloai;
        }
        //-----Delete-----------------
        public bool Delete(int id)
        {
            try
            {
                var lt = db.LOAITRUYEN.Find(id);
                db.LOAITRUYEN.Remove(lt);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        public bool Update(LOAITRUYEN entity)
        {
            try
            {
                var lt = db.LOAITRUYEN.Find(entity.Maloai);

                lt.Maloai = entity.Maloai;
                lt.Tenloai = entity.Tenloai;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }




        }

        //----------------
    }
}
