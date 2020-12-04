using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Controllers.API
{
    [RoutePrefix("api/chitietdonhang")]
    public class ChiTietDonHangController : ApiController
    {
        //lấy tất cả chi tiết đơn hàng
        [HttpGet]
        [Route("getlistCTdonhang")]
        public IEnumerable<CHITIETDONHANG> GetListCTDonHang()
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.CHITIETDONHANGs.ToList();
            }
        }

        //lấy theo mã đơn hàng
        [HttpGet]
        [Route("getCTdonhang/{id}")]
        public IEnumerable<CHITIETDONHANG> GetCTDonhang(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.CHITIETDONHANGs.Where(X => X.MaDH == id).ToList();
            }
        }

        //lấy theo mã đơn hàng
        [HttpGet]
        [Route("getCTDH/{id}")]
        public IEnumerable<CTDonHang> GetCTDH(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.CTDonHangs.Where(X => X.MaDH == id).ToList();
            }
        }

        //thêm chi tiết đơn hàng
        [HttpPost]
        [Route("addCTdonhang")]
        public bool ThemCTDonHang(CHITIETDONHANG dh)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                context.CHITIETDONHANGs.Add(dh);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //sửa chi tiết đơn hàng
        [HttpPut]
        [Route("updateCTdonhang")]
        public bool SuaDonHang(CHITIETDONHANG dh)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                CHITIETDONHANG DH = context.CHITIETDONHANGs.Find(dh.MaDH);
                if (DH == null) return false;
                DH.MaThuoc = dh.MaThuoc;
                DH.SoLuong = dh.SoLuong;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //xoá chi tiết đơn hàng
        [HttpDelete]
        [Route("delCTdonhang/{id}")]
        public bool DelCTDonHang(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                var dh = context.CHITIETDONHANGs.Find(id);
                if (dh == null)
                    return false;
                else
                    context.CHITIETDONHANGs.Remove(dh);
                context.SaveChanges();
                return true;
            }
        }
    }
}
