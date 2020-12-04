using System;
using System.Collections.Generic;
using System.Linq;
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
            var product = context.THUOCs.Where(X => X.MaThuoc == id).FirstOrDefault();
            var cart = (Cart)Session["CartSession"];
            if (cart != null)
            {
                cart.AddItem(product);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product);
                //Gán vào session
                Session["CartSession"] = cart;
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

            var product = context.THUOCs.Find(id);

            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                cart.RemoveLine(product);
                //Gán vào session
                Session["CartSession"] = cart;
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
                    var product = context.THUOCs.Find(masp[i]);
                    cart.UpdateItem(product, qty[i]);
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
            var cart = (Cart)Session["CartSession"];
            if (cart == null)
            {
                cart = new Cart();
            }
            return View(cart);
        }

        [HttpPost]
        public ActionResult Payment(DONHANG model)
        {
            //model. = DateTime.Now;
            try
            {
                context.DONHANGs.Add(model);
                context.SaveChanges();
                var cart = (Cart)Session["CartSession"];
                foreach (var item in cart.Lines)
                {
                    CHITIETDONHANG obj = new CHITIETDONHANG();
                    obj.MaDH = model.MaDH;
                    obj.MaThuoc = item.Thuoc.MaThuoc;
                    //obj.= item.Sanpham.GiaSP;
                    obj.SoLuong = item.Quantity;

                    context.CHITIETDONHANGs.Add(obj);
                    context.SaveChanges();
                }
                cart.Clear();
                Session["CartSession"] = cart;
            }
            catch (Exception ex)
            {
                //ghi log
                return RedirectToAction("/Loi");
            }
            return View("Complete");
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
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

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
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

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
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
