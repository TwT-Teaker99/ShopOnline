using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanThuoc.Models;
using ShopBanThuoc.Areas.ADMIN.Models;
using System.Data.Entity;

namespace ShopBanThuoc.Areas.ADMIN.Controllers
{
    public class LoginController : Controller
    {

        // GET: ADMIN/Login
        MyDBContext Context = new MyDBContext();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account acc)
        {
            
            if (ModelState.IsValid)
            {
                //Context.Configuration.LazyLoadingEnabled = true;
                var result = Context.TAIKHOANQUANTRIs.Where(a => a.UserName.Equals(acc.UserName) &&
                                                       a.PassWord.Equals(acc.PassWord)).Include(b=>b.ROLES).FirstOrDefault();
                if (result != null)
                {
                    acc.Roles = new List<string>();
                    foreach (ROLE it in result.ROLES)
                    {
                        acc.Roles.Add(it.RoleName);
                    }
                    Session["Login"] = acc;

                    return RedirectToAction("Index", "Admin");

                }
                else
                {
                    TempData["Login"] = "Tài khoản hoặc mật khẩu không đúng!";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Exit()
        {
            Session["Login"] = null;
            return RedirectToAction("Login");
        }

    }
}
