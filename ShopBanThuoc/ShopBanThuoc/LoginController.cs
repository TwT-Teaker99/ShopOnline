using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Controllers
{
    public class LoginController : Controller
    {
        MyDBContext Context = new MyDBContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult Index(Account acc)
        //{
        //    if (acc.UserName=="admin" && acc.Password="123")
        //    {

        //        acc.Roles = (from a in Context.Roles
        //                     join b in Context.UserInRoles
        //                     on a.IDRole equals b.IDRole
        //                     where (a.RoleName != null && b.UserName.Equals(acc.UserName))
        //                     select a.RoleName).ToList();

        //        Session["Login"] = acc;
        //        if (string.IsNullOrEmpty(ReturnUrl))
        //        {

        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            return Redirect(ReturnUrl);
        //        }

        //    }
        //    return View();
        //}

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
