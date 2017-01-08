namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHUONG")]
    public partial class CHUONG
    {
        [Key]
        public int Machuong { get; set; }

        [Required(ErrorMessage = "Phải nhập tên chương")]
        [StringLength(100, ErrorMessage = "Tối đa 100 kí tự")]
        [DisplayName("Tên chuong")]
        public string Tenchuong { get; set; }

        [DisplayName("Mã truyện")]
        public int? Matruyen { get; set; }

        [DisplayName("Nội dung")]
        public string Noidong { get; set; }

        [Required(ErrorMessage = "Phải nhập thứ tự chương")]
        [DisplayName("Thứ tự chương")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Thứ tự chương phải lớn hơn 0")]
        public int? Thutuchuong { get; set; }

        [DisplayName("Cập nhật chương")]
        public DateTime? Capnhatchuong { get; set; }

        public virtual TRUYEN TRUYEN { get; set; }
    }
}
