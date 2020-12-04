using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Areas.ADMIN.Controllers.API
{
    public class TaiKhoanQuanTriController : ApiController
    {
        [HttpGet]
        [Route("getTKQT/{id}")]
        public TAIKHOANQUANTRI GetListsDanhMuc(string id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.TAIKHOANQUANTRIs.Where(x => x.UserName == id).FirstOrDefault();
            }
        }
    }
}
