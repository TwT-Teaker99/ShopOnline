using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Controllers.API
{
    [RoutePrefix("api/donhang")]
    public class DonHangController : ApiController
    {
        //lấy tất cả danh mục
        // GET: api/danhmuc
        [HttpGet]
        [Route("getlistdonhang")]
        public IEnumerable<DONHANG> GetListsDanhMuc()
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.DONHANGs.ToList();
            }
        }
        [HttpGet]
        [Route("getIDdonhang")]
        public int GetIDDonHang()
        {
            using (MyDBContext context = new MyDBContext())
            {
                var DonHang = context.DONHANGs.ToList();
                int ID = DonHang[0].MaDH;
                foreach (var it in DonHang)
                {
                    if (it.MaDH > ID)
                        ID = it.MaDH;
                }
                return ID + 1;
            }
        }


        //lấy theo mã đơn hàng
        [HttpGet]
        [Route("getdonhang/{id}")]
        public DONHANG GetDonhang(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.DONHANGs.Find(id);
            }
        }

        //thêm đơn hàng
        [HttpPost]
        [Route("adddonhang")]
        public bool ThemDonHang(DONHANG donhang)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                context.DONHANGs.Add(donhang);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //sửa đơn hàng
        [HttpPut]
        [Route("updatedonhang")]
        public bool SuaDonHang(DONHANG donhang)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                DONHANG DH = context.DONHANGs.Find(donhang.MaDH);
                if (DH == null) return false;
                DH.MaKH = donhang.MaKH;
                DH.NgayLap = donhang.NgayLap;
                DH.TinhTrang = donhang.TinhTrang;
                DH.TongTien = donhang.TongTien;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //sửa trạng thái đơn hàng
        [HttpPut]
        [Route("updateTTdonhang/{status}")]
        public bool SuaTTDonHang(string status, DONHANG donhang)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                DONHANG DH = context.DONHANGs.Find(donhang.MaDH);
                if (DH == null) return false;
                DH.TinhTrang = status;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //xoá đơn hàng + xoá các chi tiết đơn liên quan
        [HttpDelete]
        [Route("deldonhang/{id}")]
        public bool DelDonHang(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                var dh = context.DONHANGs.Find(id);
                if (dh == null)
                    return false;
                else
                {
                    var ctdh = context.CHITIETDONHANGs.Where(X => X.MaDH == id).ToList();
                    foreach(var it in ctdh)
                    {
                        context.CHITIETDONHANGs.Remove(it);
                    }    
                    context.DONHANGs.Remove(dh);
                    context.SaveChanges();
                    return true;
                }    

            }
        }
    }
}
