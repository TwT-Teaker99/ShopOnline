using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Controllers
{
    public class TestAPIController : ApiController
    {

        private MyDBContext context = new MyDBContext();
        // GET: api/TestAPI
        public IEnumerable<THUOC> Get()
        {
            var model = context.THUOCs.ToList();
            return model;
        }

        // GET: api/TestAPI/5
        public THUOC Get(string id)
        {
            var model = context.THUOCs.Find(id);
            return model;
            //return "value";
        }

        // POST: api/TestAPI
        public void Post(THUOC model)
        {
            context.THUOCs.Add(model);
            context.SaveChanges();
        }

        // PUT: api/TestAPI/5
        public void Put(string id, THUOC sp)
        {
            var obj = context.THUOCs.Find(id);
            obj.TenThuoc = sp.TenThuoc;

              
            context.SaveChanges();
        }

        // DELETE: api/TestAPI/5
        public void Delete(string id)
        {
            var obj = context.THUOCs.Find(id);
            context.THUOCs.Remove(obj);
            context.SaveChanges();
        }
    }
}
 