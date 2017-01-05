using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class TimkiemtruyenViewModel
    {
        [Key]
        public int Matruyen { get; set; }
        public string Tentruyen { get; set; }
        public string Tacgia { get; set; }

       
        public string Anhbia { get; set; }

        public DateTime? Ngaycapnhat { get; set; }
        public int? Solandoc { get; set; }
        public string Duongdan { get; set; }
    }
}
