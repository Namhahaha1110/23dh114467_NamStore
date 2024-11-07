using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _23dh114467_NamStore.Models.ViewModel
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}