namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRUYEN_TL
    {
        [Key]
        [DisplayName("Mã truyện thể loại")]
        public int Matruyentl { get; set; }

        [DisplayName("Mã truyện")]
        public int? Matruyen { get; set; }

        [DisplayName("Mã thể loại")]
        public int? Matheloai { get; set; }

        public virtual THELOAI THELOAI { get; set; }

        public virtual TRUYEN TRUYEN { get; set; }
    }
}
