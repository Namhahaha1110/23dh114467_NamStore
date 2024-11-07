using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _23dh114467_NamStore.Models.ViewModel
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items => items;
        //Them sp vao gio hang
        public void AddItem(int productId, string productImage,string productName,decimal unitPrice,int quantity,string category)
        {
            var existingItem = items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem == null)
            {
                items.Add(new CartItem
                {
                    ProductId = productId,
                    ProductImage = productImage,
                    ProductName = productName,
                    UnitPrice = unitPrice,
                    Quantity = quantity
               
                });
            }
            else
            {
               existingItem.Quantity += quantity;
            }
        }
        //Xoa sp khoi gio hang
        public void RemoveItem(int productId)
        {
            items.RemoveAll(i => i.ProductId== productId);
        }
        //Tinh tong gia tri san pham
        public decimal TotalValue()
        {
            return items.Sum(i => i.TotalPrice);
        }
        //Lam rong gio hang
        public void Clear()
        {
            items.Clear();
        }
        //Cap nhat sp da chon
        public void UpdateItem(int productId, int quantity)
        {
            var item = items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity = quantity;
            }
        }
    }
}