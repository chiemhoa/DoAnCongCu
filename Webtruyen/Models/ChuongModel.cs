using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ChuongModel
    {
        private TruyenDbContext context = null;
        public ChuongModel()
        {
            context = new TruyenDbContext();
        }
        public List<CHUONG> ListAll()
        {
            var list = context.Database.SqlQuery<CHUONG>("Sp_Chuong_ListAll").ToList();
            return list;
        }

    }
}
