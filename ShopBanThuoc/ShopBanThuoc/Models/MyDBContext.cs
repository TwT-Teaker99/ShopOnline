using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopBanThuoc.Models
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=MyDBContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
            //base.Configuration.ProxyCreationEnabled = false;

        }

        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual DbSet<DANHMUC> DANHMUCs { get; set; }
        public virtual DbSet<DIACHI> DIACHIs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<ROLE> ROLES { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOANQUANTRI> TAIKHOANQUANTRIs { get; set; }
        public virtual DbSet<THUOC> THUOCs { get; set; }
        public virtual DbSet<CTDonHang> CTDonHangs { get; set; }
        public virtual DbSet<View_1> View_1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.MaThuoc)
                .IsFixedLength();

            modelBuilder.Entity<DANHMUC>()
                .HasMany(e => e.THUOCs)
                .WithOptional(e => e.DANHMUC)
                .HasForeignKey(e => e.MaDanhMuc);

            modelBuilder.Entity<DONHANG>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.DONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DIACHIs)
                .WithOptional(e => e.KHACHHANG)
                .HasForeignKey(e => e.KhachHangID);

            modelBuilder.Entity<ROLE>()
                .HasMany(e => e.TAIKHOANQUANTRIs)
                .WithMany(e => e.ROLES)
                .Map(m => m.ToTable("USERinROLES").MapLeftKey("IDRole").MapRightKey("UserName"));

            modelBuilder.Entity<TAIKHOANQUANTRI>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<TAIKHOANQUANTRI>()
                .Property(e => e.PassWord)
                .IsFixedLength();

            modelBuilder.Entity<THUOC>()
                .Property(e => e.MaThuoc)
                .IsFixedLength();

            modelBuilder.Entity<THUOC>()
                .Property(e => e.URLAnh)
                .IsFixedLength();

            modelBuilder.Entity<THUOC>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.THUOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CTDonHang>()
                .Property(e => e.MaThuoc)
                .IsFixedLength();

            modelBuilder.Entity<View_1>()
                .Property(e => e.MaThuoc)
                .IsFixedLength();

            modelBuilder.Entity<View_1>()
                .Property(e => e.URLAnh)
                .IsFixedLength();
        }
    }
}
