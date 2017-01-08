using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TaikhoanModel
    {
        private TruyenDbContext context = null;
        public TaikhoanModel()
        {
            context = new TruyenDbContext();
        }
        public bool Login(string userName, string passwork)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Tendangnhap",userName),
                new SqlParameter("@Matkhau",passwork)
            };
            var res = context.Database.SqlQuery<bool>("taikhoandangnhap @Tendangnhap, @Matkhau", sqlParams).SingleOrDefault();
            return res;
        }
        
    }
}
