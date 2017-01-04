namespace Models.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TruyenDbContext : DbContext
    {
        public TruyenDbContext()
            : base("name=TruyenDbContext")
        {
        }

        public virtual DbSet<CHUONG> CHUONG { get; set; }
        public virtual DbSet<LOAITRUYEN> LOAITRUYEN { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOAN { get; set; }
        public virtual DbSet<THELOAI> THELOAI { get; set; }
        public virtual DbSet<TRUYEN> TRUYEN { get; set; }
        public virtual DbSet<TRUYEN_TL> TRUYEN_TL { get; set; }
       
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Tendangnhap)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<TRUYEN>()
                .Property(e => e.Anhbia)
                .IsUnicode(false);

           

           
        }
    }
}
