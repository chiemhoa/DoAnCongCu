namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        public int ID { get; set; }

        [StringLength(50)]
        [DisplayName("Tên đăng nhập")]
        public string Tendangnhap { get; set; }

        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        public string Matkhau { get; set; }
    }
}
