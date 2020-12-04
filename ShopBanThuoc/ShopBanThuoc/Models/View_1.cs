namespace ShopBanThuoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_1
    {
        [Key]
        [Column(Order = 0)]
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

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string DonVi { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string DangThuoc { get; set; }

        [StringLength(50)]
        public string URLAnh { get; set; }
    }
}
