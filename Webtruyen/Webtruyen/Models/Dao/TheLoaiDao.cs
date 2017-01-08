using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class TheLoaiDao
    {
        TruyenDbContext db = null;
        public TheLoaiDao()
        {
            db = new TruyenDbContext();
        }
        public List<THELOAI> ListAll()
        {
            return db.THELOAI.OrderBy(x => x.Tentheloai).ToList();//.Where(x => x.Matheloai == list );
        }


        public THELOAI ViewDetail(int maTL)
        {
            return db.THELOAI.Find(maTL);
        }
        //-----Insert------------------------------
        public long Insert(THELOAI entity)
        {
            
            db.THELOAI.Add(entity);
            db.SaveChanges();
            return entity.Matheloai;
        }
        //-----Delete-----------------
        public bool Delete(int id)
        {
            try
            {
                var theloai = db.THELOAI.Find(id);
                db.THELOAI.Remove(theloai);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        public bool Update(THELOAI entity)
        {
            try
            {
                var theloai = db.THELOAI.Find(entity.Matheloai);

                theloai.Matheloai = entity.Matheloai;
                theloai.Tentheloai = entity.Tentheloai;
               
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
