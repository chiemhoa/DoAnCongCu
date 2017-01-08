namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRUYEN")]
    public partial class TRUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRUYEN()
        {
            CHUONG = new HashSet<CHUONG>();
            TRUYEN_TL = new HashSet<TRUYEN_TL>();
        }

        [Key]
        public int Matruyen { get; set; }

        [Required(ErrorMessage ="Phải nhập tên truyện")]
        [StringLength(100,ErrorMessage ="Tối đa 100 kí tự")]
        [DisplayName("Tên truyện")]
        public string Tentruyen { get; set; }

        [StringLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        [DisplayName("Tác giả")]
        public string Tacgia { get; set; }

        [DisplayName("Loại truyện")]
        public int? Maloai { get; set; }

        [DisplayName("Mô tả")]
        public string Mota { get; set; }

        [Required(ErrorMessage = "Phải nhập số chương")]
        [Range(1,Int32.MaxValue,ErrorMessage ="Số chương phải lớn hơn 0")]
        [DisplayName("Số chương")]
        public int? Sochuong { get; set; }

        [StringLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        [DisplayName("Ảnh bìa")]
        public string Anhbia { get; set; }

        [DisplayName("Ngày cập nhật")]
        public DateTime? Ngaycapnhat { get; set; }

        [StringLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        [DisplayName("Nguồn")]
        public string Nguon { get; set; }

        [StringLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        [DisplayName("Tình trạng")]
        public string Tinhtrang { get; set; }

        [DisplayName("Số lần đọc")]
        public int? Solandoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHUONG> CHUONG { get; set; }

        public virtual LOAITRUYEN LOAITRUYEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRUYEN_TL> TRUYEN_TL { get; set; }
    }
}
