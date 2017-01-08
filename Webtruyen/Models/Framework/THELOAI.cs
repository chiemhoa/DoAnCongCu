namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THELOAI")]
    public partial class THELOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THELOAI()
        {
            TRUYEN_TL = new HashSet<TRUYEN_TL>();
        }

        [Key]
        [DisplayName("Mã thể loại")]
        public int Matheloai { get; set; }

        [Required(ErrorMessage = "Phải nhập tên thể loại")]
        [StringLength(100, ErrorMessage = "Tối đa 100 kí tự")]
        [DisplayName("Tên thể loại")]
        public string Tentheloai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRUYEN_TL> TRUYEN_TL { get; set; }
    }
}
