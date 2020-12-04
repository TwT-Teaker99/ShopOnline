using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopBanThuoc.Models;

namespace ShopBanThuoc.Controllers
{
    public class CartController : Controller
    {

        
        // GET: Cart
        private MyDBContext context = new MyDBContext();       //
        // GET: /Cart/

        public ActionResult Index()
        {
            var cart = (Cart)Session["CartSession"];
            if (cart == null)
            {
                cart = new Cart();
            }
            return View(cart);
        }



        public ActionResult AddItem(string id, string returnURL)
        {
            THUOC model = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                //HTTP GET
                var responseTask = client.GetAsync("thuoc/getthuoc/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<THUOC>();
                    readTask.Wait();
                    model = readTask.Result;

                    var cart = (Cart)Session["CartSession"];
                    if (cart != null)
                    {
                        cart.AddItem(model);
                        //Gán vào session
                        Session["CartSession"] = cart;
                    }
                    else
                    {
                        //tạo mới đối tượng cart item
                        cart = new Cart();
                        cart.AddItem(model);
                        //Gán vào session
                        Session["CartSession"] = cart;
                    }
                }
                else //web api sent error response 
                {
                    model = null;
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            if (string.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("Index");
            }
            return Redirect(returnURL);
        }

        //

        // GET: /Cart/Details/5
        public ActionResult RemoveLine(string id)
        {

            THUOC model = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                //HTTP GET
                var responseTask = client.GetAsync("thuoc/getthuoc/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<THUOC>();
                    readTask.Wait();
                    model = readTask.Result;

                    var cart = (Cart)Session["CartSession"];
                    if (cart != null)
                    {
                        cart.RemoveLine(model);
                        if (cart.Lines.Count() == 0)
                        {
                            cart = null;
                        }
                        //Gán vào session
                        Session["CartSession"] = cart;
                    }
                }
                else //web api sent error response 
                {
                    model = null;
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCart(string[] masp, int[] qty)
        {
            var cart = (Cart)Session["CartSession"];
            if (cart != null)
            {
                for (int i = 0; i < masp.Count(); i++)
                {
                    THUOC model = null;
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44366/api/");
                        //HTTP GET
                        var responseTask = client.GetAsync("thuoc/getthuoc/" + masp[i]);
                        responseTask.Wait();

                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsAsync<THUOC>();
                            readTask.Wait();
                            model = readTask.Result;

                            cart.UpdateItem(model, qty[i]);
                        }
                        else //web api sent error response 
                        {
                            model = null;
                             ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }                  
                }
                Session["CartSession"] = cart;
            }

            return RedirectToAction("Index");

        }


        //
        // GET: /Cart/Details/5
        [HttpGet]
        public ActionResult Payment()
        {
            var account = (KHACHHANG)Session["LoginKH"];
            var cart = (Cart)Session["CartSession"];

            if (account == null)
            {
                return RedirectToAction("Index", "KHLogin");
            }    
            
            if (cart == null)
            {
                cart = new Cart();
            }
            ViewBag.account = account;
            return View(cart);
        }

        [HttpPost]
        public async Task<ActionResult> Payment(DONHANG model)
        {
            var account = (KHACHHANG)Session["LoginKH"];
            model.NgayLap = DateTime.Now;
            try
            {
                model.TinhTrang = "Chưa Xác Nhận";
                model.MaKH = account.MaKH;

                //gọi api thêm đơn hàng

                //HTTP POST
                using (var client = new HttpClient())
                {
                    //gọi api thêm đơn hàng
                    client.BaseAddress = new Uri("https://localhost:44366/api/");

                    var responseTask = await client.GetAsync("donhang/getIDdonhang");
                    model.MaDH = await responseTask.Content.ReadAsAsync<int>();

                    var postTask = await client.PostAsJsonAsync<DONHANG>("donhang/adddonhang", model);
                    if (postTask.IsSuccessStatusCode)
                    {                        
                        var cart = (Cart)Session["CartSession"];
                        foreach (var item in cart.Lines)
                        {
                            CHITIETDONHANG obj = new CHITIETDONHANG();
                            obj.MaDH = model.MaDH;
                            ViewBag.MDH = obj.MaDH;
                            obj.MaThuoc = item.Thuoc.MaThuoc;
                            obj.DonGia = item.Thuoc.DonGia;
                            obj.SoLuong = item.Quantity;

                            //gọi api cập nhập thuốc để sửa lại SLTon
                            item.Thuoc.SoLuongTon = item.Thuoc.SoLuongTon - item.Quantity;
                            var putTask = await client.PutAsJsonAsync<THUOC>("thuoc/updatethuoc/", item.Thuoc);
                          //gọi api thêm chi tiết đơn
                            var postTask1 = await client.PostAsJsonAsync<CHITIETDONHANG>("chitietdonhang/addCTdonhang", obj);
                            if(!postTask1.IsSuccessStatusCode)
                                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        }
                        cart.Clear();
                        Session["CartSession"] = cart;
                    }
                    else
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                }               
            }
            catch (Exception ex)
            {
                //ghi log
                return RedirectToAction("/Loi");
            }
            return View("Complete");
        }      
        
    }
}
