using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _23dh114467_NamStore.Models.ViewModel
{
    public class CheckoutVM
    {
        public List<CartItem> CartItems { get; set; }
        public int CustomerId { get; set; }
        [Display(Name ="Ngay dat hang")]
        public System.DateTime OrderDate { get; set; }
        [Display(Name ="Tong gia tri")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Trang thai thanh toan")]
        public string PaymentStatus { get; set; }
        [Display(Name = "Phuong thuc thanh toan")]
        public string PaymentMethod { get; set; }
        [Display(Name = "Phuong thuc giao hang")]
        public string ShippingMethod { get; set; }
        [Display(Name = "Dia chi giao hang")]
        public string ShippingAddress { get; set; }
        public string UserName { get; set; }
        //thuoc tinh khac
        public List<OrderDetail> OrderDetails { get; set; }
    }
}