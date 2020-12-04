namespace ShopBanThuoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUOC")]
    public partial class THUOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUOC()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        [StringLength(15)]
        public string MaThuoc { get; set; }

        [StringLength(50)]
        public string TenThuoc { get; set; }

        [StringLength(50)]
        public string ThanhPhan { get; set; }

        [StringLength(50)]
        public string CongDung { get; set; }

        public string LieuLuong { get; set; }

        public int? SoLuongTon { get; set; }

        public int? DonGia { get; set; }

        public int? MaDanhMuc { get; set; }

        [Required]
        [StringLength(50)]
        public string DonVi { get; set; }

        [Required]
        [StringLength(50)]
        public string DangThuoc { get; set; }

        [StringLength(50)]
        public string URLAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual DANHMUC DANHMUC { get; set; }
    }
}
