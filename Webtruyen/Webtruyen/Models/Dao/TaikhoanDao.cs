using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class TaikhoanDao
    {
        TruyenDbContext db = null;
        public TaikhoanDao()
        {
            db = new TruyenDbContext();
        }
        public bool Login(string userName, string passwork)
        {
            var result = db.TAIKHOAN.Count(x => x.Tendangnhap == userName && x.Matkhau == passwork);
                if(result>0)
            {
                return true;
            }
                else
            {
                return false;
            }
        }
        public TAIKHOAN GetbyId(string userName)
        {
            return db.TAIKHOAN.SingleOrDefault(x => x.Tendangnhap == userName);
        }
    }
}
