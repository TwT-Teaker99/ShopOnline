using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Controllers.API
{
    [RoutePrefix("api/diachi")]
    public class DiaChiController : ApiController
    {
        //lấy tất cả danh mục
        [HttpGet]
        [Route("getlistdiachi")]
        public IEnumerable<DIACHI> GetListsDiaChi()
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.DIACHIs.ToList();
            }
        }

        //lấy theo mã dia chi
        [HttpGet]
        [Route("getdiachi/{id}")]
        public DIACHI GetDiaChi(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.DIACHIs.Find(id);
            }
        }

        //lấy theo mã khach hang
        [HttpGet]
        [Route("getdiachiKH/{id}")]
        public IEnumerable<DIACHI> GetDiaChi1(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.DIACHIs.Where(X => X.KhachHangID == id).ToList();
            }
        }

        //thêm dc cho khách hàng
        [HttpPost]
        [Route("adddiachi")]
        public bool ThemDiaChi(DIACHI dc)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                context.DIACHIs.Add(dc);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("updatediachi")]
        public bool SuaDiaChi(DIACHI dc)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                DIACHI DC = context.DIACHIs.Find(dc.ID);
                if (DC == null) return false;
                DC.DiaChi1 = dc.DiaChi1;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("deldiachi/{id}")]
        public bool DelDiaChi(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                var dc = context.DIACHIs.Find(id);
                if (dc == null)
                    return false;
                else
                    context.DIACHIs.Remove(dc);
                context.SaveChanges();
                return true;
            }
        }
    }
}
