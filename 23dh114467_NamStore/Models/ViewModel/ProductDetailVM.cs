using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using PagedList.Mvc;

namespace _23dh114467_NamStore.Models.ViewModel
{
    public class ProductDetailVM
    {
        public Product product { get; set; }
        public int quantity { get; set; } = 1;
        //Tinh gia tri tam thoi
        public decimal estimatedVValue => quantity * product.ProductPrice;
        //Cac thuoc tinh ho tro phan trang
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 3;
        //Ds 8 sp cung danh muc
        //public PagedList.IPagedList<Product> RelatedProducts { get; set; }
        public List<Product> RelatedProducts { get; set; }
        //Ds 8 sp ban chay nhat
        public PagedList.IPagedList<Product> TopProducts { get; set; }

    }
}