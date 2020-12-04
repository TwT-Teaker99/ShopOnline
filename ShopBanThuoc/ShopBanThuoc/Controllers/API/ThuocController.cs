using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Controllers.API
{
    [RoutePrefix("api/thuoc")]
    public class ThuocController : ApiController
    {

        //lấy tất cả thuốc
        // GET: api/Thuoc
        [HttpGet]
        [Route("getlistthuoc")]
        public IEnumerable<THUOC> GetThuocLists()
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.THUOCs.Where(X => X.TenThuoc != null).ToList();
            }
        }

        //lấy theo mã thuốc
        [HttpGet]
        [Route("getthuoc/{id}")]
        public THUOC GetThuoc(string id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.THUOCs.Find(id);
            }
        }

        //lấy theo mã loại thuốc
        [HttpGet]
        [Route("getthuoc1/{loai}")]
        public IEnumerable<THUOC> GetThuoc1(int loai)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.THUOCs.Where(X => X.MaDanhMuc == loai).ToList();
            }
        }

        //tìm thuốc theo tên & công dụng
        [HttpGet]
        [Route("searchthuoc")]
        public IEnumerable<THUOC> SearchThuoc(string search)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.THUOCs.Where(X => X.TenThuoc.Contains(search) || X.CongDung.Contains(search)).ToList();
            }
        }

        [HttpPost]
        [Route("addthuoc")]
        public bool ThemThuoc(THUOC thuoc)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                context.THUOCs.Add(thuoc);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPut]
        [Route("updateSLT/{id}/{sl}")]
        public bool SuaSLThuoc(string id,int sl)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                THUOC Thuoc = context.THUOCs.Find(id);
                if (Thuoc == null) return false;               
                Thuoc.SoLuongTon = Thuoc.SoLuongTon-sl;               
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("updatethuoc")]
        public bool SuaThuoc(THUOC thuoc)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                THUOC Thuoc = context.THUOCs.Find(thuoc.MaThuoc);
                if (Thuoc == null) return false;
                Thuoc.TenThuoc = thuoc.TenThuoc;
                Thuoc.ThanhPhan = thuoc.ThanhPhan;
                Thuoc.SoLuongTon = thuoc.SoLuongTon;
                Thuoc.MaDanhMuc = thuoc.MaDanhMuc;
                Thuoc.LieuLuong = thuoc.LieuLuong;
                Thuoc.URLAnh = thuoc.URLAnh;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("delthuoc/{id}")]
        public bool DeleteThuoc(string id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                var thuoc = context.THUOCs.Find(id);
                if (thuoc == null)
                    return false;
                else
                    context.THUOCs.Remove(thuoc);
                    context.SaveChanges();
                    return true;
            }
        }
    }
}
