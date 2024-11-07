using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _23dh114467_NamStore.Models;
using _23dh114467_NamStore.Models.ViewModel;
using PagedList;
using System.Web.DynamicData;
using System.Net;

namespace _23dh114467_NamStore.Controllers
{
    public class HomeController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();
        public ActionResult Index(string searchTerm,int? page)
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            if(!string.IsNullOrEmpty(searchTerm))
            {
                model.SearchTerm = searchTerm;
                products = products.Where(p => p.ProductName.Contains(searchTerm)||
                p.Category.CategoryName.Contains(searchTerm)||
                p.ProductDescription.Contains(searchTerm)) ;
            }
            int pageNumber = page ?? 1;
            int pageSize = 6;
            model.FeaturedProducts = products.OrderByDescending(p => p.OrderDetails.Count()).Take(10).ToList();
            model.NewProducts = products.OrderBy(p => p.OrderDetails.Count()).Take(20).ToPagedList(pageNumber, pageSize);
            return View(model);
        }
        public ActionResult ProductDetail(int?id,int?quantity,int?page)

        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product pro = db.Products.Find(id);
            if(pro == null)
            {
                return HttpNotFound();
            }
            var product=db.Products.Where(p => p.CategoryID == pro.CategoryID && p.ProductID != pro.ProductID).OrderBy(p => p.OrderDetails.Count()).AsQueryable();
            ProductDetailVM model = new ProductDetailVM();
            int pageNumber = page ?? 1;
            int pageSize = model.PageSize;
            model.product = pro;
            model.RelatedProducts= product.OrderBy(p=>p.ProductID).Take(8).ToList();
            model.TopProducts=product.OrderByDescending(p => p.OrderDetails.Count()).Take(8).ToPagedList(pageNumber, pageSize);
            if(quantity.HasValue)
            {
                model.quantity = quantity.Value;
            }
            return View();
        }

        public ActionResult ProductList()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        
    }
}