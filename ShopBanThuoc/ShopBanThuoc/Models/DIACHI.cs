namespace ShopBanThuoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIACHI")]
    public partial class DIACHI
    {
        public int ID { get; set; }

        [Column("DiaChi")]
        public string DiaChi1 { get; set; }

        public int? KhachHangID { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
