namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRUYENAUDIO")]
    public partial class TRUYENAUDIO
    {
        [Key]
        [DisplayName("Mã truyện")]
        public int Matruyen { get; set; }
        

        [Required(ErrorMessage = "Phải nhập tên truyện")]
        [StringLength(100, ErrorMessage = "Tối đa 100 kí tự")]
        [DisplayName("Tên truyện")]

        public string Tentruyen { get; set; }

        [StringLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        [DisplayName("Tác giả")]
        public string Tacgia { get; set; }

        [DisplayName("Mô tả")]
        public string Mota { get; set; }


        [DisplayName("Đường dẫn")]
        public string Duongdan { get; set; }

        [StringLength(200, ErrorMessage = "Tối đa 200 kí tự")]
        [DisplayName("Ảnh bìa")]
        public string Anhbia { get; set; }

        [DisplayName("Ngày cập nhật")]
        public DateTime? Ngaycapnhat { get; set; }

        [StringLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        [DisplayName("Nguồn")]
        public string Nguon { get; set; }

        [DisplayName("Số lần đọc")]
        public int? Solandoc { get; set; }
    }
}
