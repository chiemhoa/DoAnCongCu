using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    
    public class TheloaiModel
    {
        private TruyenDbContext context = null;
        public TheloaiModel()
        {
            context = new TruyenDbContext();
        }
       public List<THELOAI> ListAll()
        {
            var list = context.Database.SqlQuery<THELOAI>("Sp_Theloai_ListAll").ToList();
            return list;
        }
    }
}
