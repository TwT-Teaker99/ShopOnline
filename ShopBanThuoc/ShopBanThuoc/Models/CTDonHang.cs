namespace ShopBanThuoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDonHang")]
    public partial class CTDonHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string MaThuoc { get; set; }

        [StringLength(50)]
        public string TenThuoc { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGia { get; set; }
    }
}
