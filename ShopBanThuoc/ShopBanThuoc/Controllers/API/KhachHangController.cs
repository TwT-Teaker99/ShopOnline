using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Controllers.API
{
    [RoutePrefix("api/khachhang")]
    public class KhachHangController : ApiController
    {
        //lấy tất cả khach hang
        [HttpGet]
        [Route("getlistkhachhang")]
        public IEnumerable<KHACHHANG> GetListsKhachHang()
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.KHACHHANGs.ToList();
            }
        }

        //lấy theo mã khachhang
        [HttpGet]
        [Route("getkhachhang/{id}")]
        public KHACHHANG GetKhachHang(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.KHACHHANGs.Find(id);
            }
        }

        [HttpPost]
        [Route("addkhachhang")]
        public bool ThemKhachHang(KHACHHANG dc)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                context.KHACHHANGs.Add(dc);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("updateKhachHang")]
        public bool SuaKhachHang(KHACHHANG dc)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                KHACHHANG DC = context.KHACHHANGs.Find(dc.MaKH);
                if (DC == null) return false;
                DC.Ten = dc.Ten;
                DC.SDT = dc.SDT;
                DC.MatKhau = dc.MatKhau;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("delKhachHang/{id}")]
        public bool DelKhachHang(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                var dc = context.KHACHHANGs.Find(id);
                if (dc == null)
                    return false;
                else
                {
                    var temp = context.DIACHIs.Where(X => X.KhachHangID == id).ToList();
                    foreach(var it in temp)
                    {
                        context.DIACHIs.Remove(it);
                    }    
                    context.KHACHHANGs.Remove(dc);
                    context.SaveChanges();
                    return true;
                }    

            }
        }

    }
}
