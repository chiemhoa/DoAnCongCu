using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public class ChuongmoinhatViewModel
    {
        public int Matruyen { get; set; }
        public string Tentruyen { get; set; }
        public string Tacgia { get; set; }
       
        public int? Sochuong { get; set; }
        public string Anhbia { get; set; }
     
        public string Tinhtrang { get; set; }
        public int? Solandoc { get; set; }
        public int Machuong { get; set; }
        
        public string Tenchuong { get; set; }

        public int? Thutuchuong { get; set; }

        public DateTime? Capnhatchuong { get; set; }
    }
}
