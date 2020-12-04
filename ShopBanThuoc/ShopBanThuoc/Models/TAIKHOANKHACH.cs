namespace ShopBanThuoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOANKHACH")]
    public partial class TAIKHOANKHACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOANKHACH()
        {
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(15)]
        public string MatKhau { get; set; }

        public int? DiaChiID { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        public virtual DIACHI DIACHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
