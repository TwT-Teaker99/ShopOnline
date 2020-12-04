using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanThuoc.Areas.ADMIN.Models;


namespace ShopBanThuoc.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current == null)
            {
                filterContext.Result = new RedirectResult("/ADMIN/Login/Login");
                return;
            }
            var acc = (Account)HttpContext.Current.Session["Login"];

            if (acc == null)
            {
                filterContext.Result = new RedirectResult("/ADMIN/Login/Login");
            }
            else
            {
                var cp = new CustomPrincipal(acc);
                if (!cp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new { Controller = "Login", Action = "Login" }));
                }
            }
        }
    }
}