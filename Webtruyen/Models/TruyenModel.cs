using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TruyenModel
    {
        private TruyenDbContext context = null;
        public TruyenModel()
        {
            context = new TruyenDbContext();
        }
        public List<TRUYEN> ListAll()
        {
            var list = context.Database.SqlQuery<TRUYEN>("Sp_Truyen_ListAll").ToList();
            return list;
        }
    }
}
