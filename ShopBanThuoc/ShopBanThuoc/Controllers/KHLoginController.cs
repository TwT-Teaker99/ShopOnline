using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Controllers
{
    public class KHLoginController : Controller
    {

        private MyDBContext Context = new MyDBContext();
        // GET: KHLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(KHACHHANG acc)
        {
            if (ModelState.IsValid)
            {
                var result = Context.KHACHHANGs.Where(a => a.SDT.Equals(acc.SDT) &&
                                                       a.MatKhau.Equals(acc.MatKhau)).FirstOrDefault();
                if (result != null)
                {
                    //acc.MaKH = result.MaKH;
                    Session["LoginKH"] = result;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["LoginKH"] = "Tài khoản hoặc mật khẩu không đúng!";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}