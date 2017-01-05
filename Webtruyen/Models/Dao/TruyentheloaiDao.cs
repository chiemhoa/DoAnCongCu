using Models.Framework;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class TruyentheloaiDao
    {
        TruyenDbContext db = null;
        public TruyentheloaiDao()
        {
            db = new TruyenDbContext();
        }
        public long Insert(TRUYEN_TL entity,int id)
        {
            entity.Matruyen = id;
            db.TRUYEN_TL.Add(entity);
            db.SaveChanges();
            return entity.Matruyentl;
        }
        public bool Update(TRUYEN_TL entity)
        {
            try
            {
                var truyen = db.TRUYEN_TL.Find(entity.Matruyentl);
                truyen.Matheloai = entity.Matheloai;
                
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                var truyentl = db.TRUYEN_TL.Find(id);
                db.TRUYEN_TL.Remove(truyentl);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        public TRUYEN_TL ViewDetail(int id)
        {
            return db.TRUYEN_TL.Find(id);
        }


        public List<TRUYEN_TL> ListAll(int id)
        {
            return db.TRUYEN_TL.Where(x=>x.Matruyentl==id).ToList();
        }
        public List<TheloaitruyenViewModel> ListTLT(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id",id),

            };
            var list = db.Database.SqlQuery<TheloaitruyenViewModel>("Sp_qltl_truyen @id", sqlParams).ToList();
            return list;
        }
    }
}
