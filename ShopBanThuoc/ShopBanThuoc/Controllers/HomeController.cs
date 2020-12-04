using ShopBanThuoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ShopBanThuoc.Controllers
{
    public class HomeController : Controller
    {
        /*
        public ActionResult TraCuuDon()
        {
            var model = context.DONHANGs;
            model = null;
            return View(model);
        }
        [HttpPost]
        public ActionResult TraCuuDon(string search)
        {
            try {
                int s = int.Parse(search);
                var model = context.DONHANGs.Where(X => X.MaDH == s).FirstOrDefault();
                return View(model);
            }
            catch
            {
                //TempData["Alert"] = "Mã hoá đơn không hợp lệ, Vui lòng thử lại!";
                return View();
            }
        }
        public ActionResult ChiTietDonHang(int ID)
        {
            var model = context.CTDonHangs.Where(x => x.MaDH == ID).ToList();
            var tt = context.DONHANGs.Where(x => x.MaDH == ID).FirstOrDefault();
            ViewBag.MaDonHang = ID;
            ViewBag.TinhTrang = tt.TinhTrang;
            return View(model);
        }
        [HttpPost]
        public ActionResult ChiTietDonHang(DONHANG model, int ID)
        {
            var obj = context.DONHANGs.Where(x => x.MaDH == ID).FirstOrDefault();
            obj.TinhTrang = model.TinhTrang;
            context.SaveChanges();
            return RedirectToAction("DonHang");
        }
        */
        public ActionResult Index()
        {
            IEnumerable<THUOC> model = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                //HTTP GET
                var responseTask = client.GetAsync("thuoc/getlistthuoc");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<THUOC>>();
                    readTask.Wait();

                    model = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    model = Enumerable.Empty<THUOC>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(model);
            //return View();
        }
        public ActionResult _Navbar()
        {
            IEnumerable<DANHMUC> model = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                //HTTP GET
                var responseTask = client.GetAsync("danhmuc/getlistdanhmuc");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<DANHMUC>>();
                    readTask.Wait();

                    model = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    model = Enumerable.Empty<DANHMUC>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(model);
            //return View();
        }
        public ActionResult Product(string id)
        {
            THUOC model = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                //HTTP GET
                var responseTask = client.GetAsync("thuoc/getthuoc/"+id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<THUOC>();
                    readTask.Wait();

                    model = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    model = null ;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(model);
            //ViewBag.maThuoc = id;
            //return View();
        }
        public ActionResult DANHMUC(int id)
        {
            IEnumerable<THUOC> model = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                //HTTP GET
                var responseTask = client.GetAsync("thuoc/getthuoc1/"+id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<THUOC>>();
                    readTask.Wait();

                    model = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    model = Enumerable.Empty<THUOC>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View("Index",model);
            //ViewBag.maDM = id;
            //return View();
        }

        public ActionResult Search(string search)
        {
            IEnumerable<THUOC> model = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                //HTTP GET
                var responseTask = client.GetAsync("thuoc/searchthuoc/"+search);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<THUOC>>();
                    readTask.Wait();

                    model = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    model = Enumerable.Empty<THUOC>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(model);
            //ViewBag.search = search;
            //return View();

        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Account()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

    }
}