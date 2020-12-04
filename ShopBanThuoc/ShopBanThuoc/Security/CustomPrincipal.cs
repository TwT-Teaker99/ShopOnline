using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using ShopBanThuoc.Areas.ADMIN.Models;

namespace ShopBanThuoc.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Account Account;
        public CustomPrincipal(Account account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.UserName);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            bool kq = roles.Any(r => this.Account.Roles.Contains(r));
            return kq;
        }
    }
}