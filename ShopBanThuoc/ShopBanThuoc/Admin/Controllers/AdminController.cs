using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private MyDBContext context = new MyDBContext();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhMuc()
        {
            var model = context.DANHMUCs.ToList();
            return View(model);
        }
        //GET
        public ActionResult DanhMucAdd()
        {
            var model = context.DANHMUCs.ToList();
            return View(model);
        }
        //POST
        [HttpPost]
        public ActionResult DanhMucAdd(DANHMUC model)
        {
            try
            {
                context.DANHMUCs.Add(model);
                context.SaveChanges();
                return RedirectToAction("DanhMuc");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DanhMucEdit(int id)
        {
            var model = context.DANHMUCs.Where(X => X.MaDM == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult DanhMucEdit(DANHMUC model)
        {
            try
            {
                var obj = context.DANHMUCs.Find(model.MaDM);
                obj.TenDM = model.TenDM;
                context.SaveChanges();

                return RedirectToAction("DanhMuc");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var model = context.DANHMUCs.Where(X => X.MaDM == id).FirstOrDefault();
            return View("DanhMucEdit",model);
        }

        [HttpPost]
        public ActionResult Delete(DANHMUC model)
        {
            try
            {
                var obj = context.DANHMUCs.Find(model.MaDM);
                context.DANHMUCs.Remove(obj);
                context.SaveChanges();
                return RedirectToAction("DanhMuc");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SanPham()
        {
            var model = context.THUOCs.ToList();
            return View(model);
        }
        //GET
        [HttpGet]
        public ActionResult SanPhamAdd()
        {
            var model = context.THUOCs.ToList();
            return View(model);
        }
        //POST
        [HttpPost]
        public ActionResult SanPhamAdd(THUOC model)
        {
            try
            {
                context.THUOCs.Add(model);
                context.SaveChanges();
                return RedirectToAction("SanPham");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SanPhamEdit()
        {
            return View();
        }

    }
}