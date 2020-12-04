using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBanThuoc.Models
{
    [Serializable]
    public class CartItem
    {
        public THUOC Thuoc { get; set; }
        public int Quantity { set; get; }
    }
    public class Cart
    {
        private List<CartItem> lineCollection = new List<CartItem>();

        public void AddItem(THUOC sp)
        {
            CartItem line = lineCollection.Where(p => p.Thuoc.MaThuoc == sp.MaThuoc).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartItem
                {
                    Thuoc = sp,
                    Quantity = 1
                });
            }
            else
            {
                line.Quantity += 1;
                if (line.Quantity <= 0)
                {
                    lineCollection.RemoveAll(l => l.Thuoc.MaThuoc == sp.MaThuoc);
                }
            }
        }
        public void UpdateItem(THUOC sp, int quantity)
        {
            CartItem line = lineCollection.Where(p => p.Thuoc.MaThuoc == sp.MaThuoc).FirstOrDefault();

            if (line != null)
            {
                if (quantity > 0)
                {
                    line.Quantity = quantity;
                }
                else
                {
                    lineCollection.RemoveAll(l => l.Thuoc.MaThuoc == sp.MaThuoc);
                }
            }
        }
        public void RemoveLine(THUOC sp)
        {
            lineCollection.RemoveAll(l => l.Thuoc.MaThuoc == sp.MaThuoc);
        }

        public int? ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Thuoc.DonGia * e.Quantity);

        }
        public int? ComputeTotalProduct()
        {
            return lineCollection.Sum(e => e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartItem> Lines
        {
            get { return lineCollection; }
        }
    }
}