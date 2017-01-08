namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAITRUYEN")]
    public partial class LOAITRUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAITRUYEN()
        {
            TRUYEN = new HashSet<TRUYEN>();
        }

        [Key]
        [DisplayName("Mã loại")]
        public int Maloai { get; set; }

        [Required(ErrorMessage = "Phải nhập loại")]
        [StringLength(100, ErrorMessage = "Tối đa 100 kí tự")]
       
        [DisplayName("Tên loại")]
        public string Tenloai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRUYEN> TRUYEN { get; set; }
    }
}
