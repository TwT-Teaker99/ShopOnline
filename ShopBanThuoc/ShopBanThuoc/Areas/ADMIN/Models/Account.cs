using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Areas.ADMIN.Models
{
    
    public class Account
    {
        
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public List<string> Roles { get; set; }
    }
}