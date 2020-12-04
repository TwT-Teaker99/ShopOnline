using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanThuoc.Models;
using ShopBanThuoc.Areas.ADMIN.Models;
using System.IO;
using ShopBanThuoc.Security;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopBanThuoc.Areas.ADMIN.Controllers
{
    public class AdminController : Controller
    {
        private MyDBContext context = new MyDBContext();
        // GET: ADMIN/Admin


        public ActionResult _DangNhap()
        {
            var acc = (Account)Session["Login"];
            ViewBag.Username = acc.UserName;
            return View();
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        public ActionResult HoSo(string ID)
        {
            var model = context.TAIKHOANQUANTRIs.Where(x => x.UserName == ID).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult HoSo(TAIKHOANQUANTRI model, string NewPass, string Confirm)
        {
            var obj = context.TAIKHOANQUANTRIs.Where(x => x.UserName == model.UserName).FirstOrDefault();
            if (obj.PassWord.Contains(model.PassWord))
            {
                if (NewPass.CompareTo(Confirm) == 0)
                {
                    obj.HoTen = model.HoTen;
                    obj.PassWord = NewPass;
                    context.SaveChanges();
                    return RedirectToAction("Users");
                }
                else
                {
                    TempData["Alert"] = "Xác nhận mật khẩu không đúng! Vui lòng thử lại!";
                    return View("HoSo", obj);
                }
            }
            else
            {
                TempData["Alert"] = "Mật khẩu không đúng! Vui lòng thử lại!";
                return View("HoSo", obj);
            }
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        public ActionResult Index()
        {
            ViewBag.SLThanhVien = context.TAIKHOANQUANTRIs.Count();
            ViewBag.SLSanPham = context.THUOCs.Count();
            ViewBag.SLDanhMuc = context.DANHMUCs.Count();
            ViewBag.SLDonHang = context.DONHANGs.Count();
            return View();
        }

        [CustomAuthorize(Roles = "Admin,Member")]
        public ActionResult Users()
        {
            var model = context.TAIKHOANQUANTRIs.ToList();
            return View(model);
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Add_User()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_User(TAIKHOANQUANTRI model, string rePassWord,int ROLE)
        {
            try
            {
                if (model.PassWord.CompareTo(rePassWord) == 0)
                {
                    var role = context.ROLES.Where(x => x.IDRole==ROLE).FirstOrDefault();
                    model.ROLES = new List<ROLE>();
                    model.ROLES.Add(role);
                    context.TAIKHOANQUANTRIs.Add(model);
                    context.SaveChanges();
                 
                    return RedirectToAction("Users");
                    
                }
                else
                {
                    TempData["Alert"] = "Xác nhận mật khẩu không đúng! Vui lòng thử lại!";
                    return View();
                }

            }
            catch
            {
                TempData["Alert"] = "Username đã tồn tại! Vui lòng thử lại!";
                return View();
            }

        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit_User(string ID)
        {
            var model = context.TAIKHOANQUANTRIs.Where(x => x.UserName == ID).FirstOrDefault();
             return View(model);           
        }
        [HttpPost]
        public ActionResult Edit_User(TAIKHOANQUANTRI model,int ROLE)
        {
            var role = context.ROLES.Where(x => x.IDRole==ROLE).FirstOrDefault();
            var obj = context.TAIKHOANQUANTRIs.Where(x => x.UserName == model.UserName).FirstOrDefault();
            obj.ROLES.Clear();
            obj.ROLES.Add(role);
            obj.HoTen = model.HoTen;
            //obj.IDRole = model.IDRole;
            context.SaveChanges();
            return RedirectToAction("Users");

        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Del_User(string ID)
        {
            var obj = context.TAIKHOANQUANTRIs.Where(x => x.UserName.Equals(ID)).FirstOrDefault();
            obj.ROLES.Clear();
            context.TAIKHOANQUANTRIs.Remove(obj);
            context.SaveChanges();
            return RedirectToAction("Users");
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        [HttpPost]
        public ActionResult TimKiemUsers(string search)
        {

            var model = context.TAIKHOANQUANTRIs.Where(X => X.UserName.Contains(search)).ToList();
            ViewBag.search = search;
            return View("Users", model);
             
        }


        [CustomAuthorize(Roles = "Admin,Member")]
        public async Task<ActionResult> DanhMuc()
        {
            IEnumerable<DANHMUC> model = null;
            using (var client = new HttpClient())
            {
                //gọi api thêm đơn hàng
                client.BaseAddress = new Uri("https://localhost:44366/api/");     
                var responseTask = await client.GetAsync("danhmuc/getlistdanhmuc");
                if (responseTask.IsSuccessStatusCode)
                {
                    model = await responseTask.Content.ReadAsAsync<IList<DANHMUC>>();      
                }
                else
                    model = Enumerable.Empty<DANHMUC>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(model);
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        public ActionResult Add_DanhMuc()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Add_DanhMuc(DANHMUC model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //gọi api thêm đơn hàng
                    client.BaseAddress = new Uri("https://localhost:44366/api/");
                    var responseTask = await client.PostAsJsonAsync<DANHMUC>("danhmuc/adddanhmuc",model);
                    if (!responseTask.IsSuccessStatusCode)
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return RedirectToAction("DanhMuc");
            }
            catch
            {
                TempData["Alert"] = "Đã xảy ra lỗi. Có thể Mã danh mục đã tồn tại, Vui lòng thử lại!";
                return View("Add_DanhMuc");
            }
            
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        public async Task<ActionResult> Edit_DanhMuc(int ID)
        {
            DANHMUC model = null;
            using (var client = new HttpClient())
            {
                //gọi api thêm đơn hàng
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                var responseTask = await client.GetAsync("danhmuc/getdanhmuc/"+ID);
                if (responseTask.IsSuccessStatusCode)
                {
                    model = await responseTask.Content.ReadAsAsync<DANHMUC>();
                }
                else
                    model = null;
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit_DanhMuc(DANHMUC model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                var putTask = await client.PutAsJsonAsync<DANHMUC>("danhmuc/updatedanhmuc", model);
                if (!putTask.IsSuccessStatusCode)
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return RedirectToAction("DanhMuc");
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        public async Task<ActionResult> Del_DanhMuc(int ID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                var putTask = await client.DeleteAsync("danhmuc/deldanhmuc/"+ID.ToString());
                if (!putTask.IsSuccessStatusCode)
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return RedirectToAction("DanhMuc");
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        [HttpPost]
        public async Task<ActionResult> TimKiemDanhMuc(string search)
        {
            IEnumerable<DANHMUC> model = null;
            using (var client = new HttpClient())
            {
                //gọi api thêm đơn hàng
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                var responseTask = await client.GetAsync("danhmuc/searchdanhmuc/"+search);
                if (responseTask.IsSuccessStatusCode)
                {
                    model = await responseTask.Content.ReadAsAsync<IList<DANHMUC>>();
                }
                else
                    model = Enumerable.Empty<DANHMUC>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            ViewBag.search = search;
            return View("DanhMuc", model);
        }



        [CustomAuthorize(Roles = "Admin,Member")]
        public async Task<ActionResult> SanPham()
        {
            IEnumerable<THUOC> model = null;
            using (var client = new HttpClient())
            {
                //gọi api thêm đơn hàng
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                var responseTask = await client.GetAsync("thuoc/getlistthuoc");
                if (responseTask.IsSuccessStatusCode)
                {
                    model = await responseTask.Content.ReadAsAsync<IList<THUOC>>();
                }
                else
                    model = Enumerable.Empty<THUOC>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(model);
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        [HttpPost]
        public ActionResult TimKiemSP(string search)
        {
            var model = context.THUOCs.Where(X => X.TenThuoc.Contains(search)).ToList();
            ViewBag.search = search;
            return View("SanPham",model);
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        public ActionResult Add_SanPham()
        {
            var model = context.DANHMUCs.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add_SanPham(HttpPostedFileBase file, THUOC model)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    // lấy tên tệp tin
                    var fileName = Path.GetFileName(file.FileName);
                    // lưu trữ tệp tin vào folder ~/App_Data/uploads
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    file.SaveAs(path);
                    context.THUOCs.Add(model);
                    context.SaveChanges();

                    var obj = context.THUOCs.Where(x => x.MaThuoc == model.MaThuoc).FirstOrDefault();
                    obj.URLAnh = fileName;
                    context.SaveChanges();
                    return RedirectToAction("SanPham");
                }
                else
                {
                    return View("Add_SanPham");
                }
            }
            catch
            {
                return View("Add_SanPham");
            }
            
           
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        public ActionResult Del_SanPham(string ID)
        {
            var obj = context.THUOCs.Where(x => x.MaThuoc == ID).FirstOrDefault();
            context.THUOCs.Remove(obj);
            context.SaveChanges();
            return RedirectToAction("SanPham");
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        public ActionResult Edit_SanPham(string ID)
        {
            var model = context.THUOCs.Where(x => x.MaThuoc == ID).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit_SanPham(THUOC model)
        {
            var obj = context.THUOCs.Where(x => x.MaThuoc == model.MaThuoc).FirstOrDefault();
            obj.TenThuoc = model.TenThuoc;
            obj.ThanhPhan = model.ThanhPhan;
            obj.CongDung = model.CongDung;
            obj.LieuLuong = model.LieuLuong;
            obj.SoLuongTon = model.SoLuongTon;
            obj.DonGia = model.DonGia;
            obj.DonVi = model.DonVi;
            obj.DangThuoc = model.DangThuoc;
            obj.MaDanhMuc = model.MaDanhMuc;

            context.SaveChanges();

            return RedirectToAction("SanPham");
        }
        //Đơn Hàng
        [CustomAuthorize(Roles = "Admin,Member")]
        public async Task<ActionResult> DonHang()
        {
            IEnumerable<DONHANG> model = null;
            using (var client = new HttpClient())
            {
                //gọi api thêm đơn hàng
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                var responseTask = await client.GetAsync("donhang/getlistdonhang");
                if (responseTask.IsSuccessStatusCode)
                {
                    model = await responseTask.Content.ReadAsAsync<IList<DONHANG>>();
                }
                else
                    model = Enumerable.Empty<DONHANG>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(model);
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        public async Task<ActionResult> ChiTietDonHang(int ID)
        {
            IEnumerable<CTDonHang> model = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                var responseTask = await client.GetAsync("chitietdonhang/getCTDH/"+ID.ToString());
                if (responseTask.IsSuccessStatusCode)
                {
                    model = await responseTask.Content.ReadAsAsync<IList<CTDonHang>>();
                }
                else
                    model = Enumerable.Empty<CTDonHang>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            DONHANG modelDH = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                var responseTask = await client.GetAsync("donhang/getdonhang/"+ID.ToString());
                if (responseTask.IsSuccessStatusCode)
                {
                    modelDH = await responseTask.Content.ReadAsAsync<DONHANG>();
                }
                else
                    modelDH = null;
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            ViewBag.MaDonHang = ID;
            ViewBag.TinhTrang = modelDH.TinhTrang;
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> ChiTietDonHang(DONHANG model, int ID)
        {
            DONHANG obj = null;
            using (var client = new HttpClient())
            {
                //gọi api thêm đơn hàng
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                var responseTask = await client.GetAsync("donhang/getdonhang/" + ID.ToString());
                if (responseTask.IsSuccessStatusCode)
                {
                    obj = await responseTask.Content.ReadAsAsync<DONHANG>();
                }
                else
                    obj = null;
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            obj.TinhTrang = model.TinhTrang;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                var putTask = await client.PutAsJsonAsync<DONHANG>("donhang/updatedonhang", obj);
                if (!putTask.IsSuccessStatusCode)
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return RedirectToAction("DonHang");
        }
        [CustomAuthorize(Roles = "Admin,Member")]
        public ActionResult Del_DonHang(int ID)
        {
            var obj1 = context.CHITIETDONHANGs.Where(x => x.MaDH == ID).FirstOrDefault();
            context.CHITIETDONHANGs.Remove(obj1);
            context.SaveChanges();

            var obj2 = context.DONHANGs.Where(x => x.MaDH == ID).FirstOrDefault();
            context.DONHANGs.Remove(obj2);
            context.SaveChanges();

            return RedirectToAction("DonHang");
        }
        //[CustomAuthorize(Roles = "Admin,Member")]
        //[HttpPost]
        //public ActionResult TimKiemDH(string search)
        //{
        //    //var model = context.DONHANGs.Where(X => X.Email.Contains(search)).ToList();
        //    var model = context.DONHANGs.Where(X => X.Email.Contains(search) || X.SDT.Contains(search)
        //    || X.TinhTrang.Contains(search) || X.TenKhachHang.Contains(search)).ToList();
        //    ViewBag.search = search;
        //    return View("DonHang", model);
        //}
    }
}
