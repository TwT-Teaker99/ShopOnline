using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Controllers.API
{
    [RoutePrefix("api/danhmuc")]
    public class DanhmucController : ApiController
    {
        //lấy tất cả danh mục
        // GET: api/danhmuc
        [HttpGet]
        [Route("getlistdanhmuc")]
        public IEnumerable<DANHMUC> GetListsDanhMuc()
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.DANHMUCs.ToList();
            }
        }

        //lấy theo mã danh muc
        [HttpGet]
        [Route("getdanhmuc/{id}")]
        public DANHMUC GetDanhMuc(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.DANHMUCs.Find(id);
            }
        }

        [HttpGet]
        [Route("searchdanhmuc/{search}")]
        public IEnumerable<DANHMUC> SearchDanhMuc(string search)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.DANHMUCs.Where(X => X.TenDM.Contains(search)).ToList();
            }
        }

        [HttpPost]
        [Route("adddanhmuc")]
        public bool ThemDanhMuc(DANHMUC danhmuc)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                context.DANHMUCs.Add(danhmuc);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("updatedanhmuc")]
        public bool SuaDanhMuc( DANHMUC danhmuc)
        {
            try
            {
                MyDBContext context = new MyDBContext();
                DANHMUC DM = context.DANHMUCs.Find(danhmuc.MaDM);
                if (DM == null)
                    return false;
                else
                    DM.TenDM = danhmuc.TenDM;
                    context.SaveChanges();
                    return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("deldanhmuc/{id}")]
        public bool DelDanhMuc(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                var dm = context.DANHMUCs.Find(id);
                if (dm == null)
                    return false;
                else
                {
                    var temp = context.THUOCs.Where(X => X.MaDanhMuc == id).ToList();
                    foreach(var it in temp)
                    {
                        it.MaDanhMuc = null;
                    }    
                    context.DANHMUCs.Remove(dm);
                    context.SaveChanges();
                    return true;
                }

            }
        }
    }
}
