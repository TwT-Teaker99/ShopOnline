namespace ShopBanThuoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETGIOHANG")]
    public partial class CHITIETGIOHANG
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? MaGioHang { get; set; }

        [StringLength(15)]
        public string MaThuoc { get; set; }

        public int? SoLuong { get; set; }

        public virtual GIOHANG GIOHANG { get; set; }
    }
}
