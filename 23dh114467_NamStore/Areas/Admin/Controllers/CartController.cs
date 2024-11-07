using _23dh114467_NamStore.Models.ViewModel;
using _23dh114467_NamStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _23dh114467_NamStore.Areas.Admin.Controllers
{
    public class CartController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();
        //Ham lay dich vu gio hang
        private CartService GetCartService()
        {
            return new CartService(Session);
        }

        //Hien thi gio hang k gom nhom theo danh muc
        public ActionResult Index()
        {
            var cart = GetCartService().GetCart();
            return View(cart);
        }
        //Them san pham vao gio hang
        public ActionResult AddToCart(int id, int quantity = 1)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                var cartService = GetCartService();
                cartService.GetCart().AddItem(product.ProductID, product.ProductImage, product.ProductName, product.ProductPrice, quantity, product.Category.CategoryName);

            }
            return RedirectToAction("Index");
        }
        //Xoa san pham khoi gio hang
        public ActionResult RemoveFromCart(int id)
        {
            var cartService = GetCartService();
            cartService.GetCart().RemoveItem(id);
            return RedirectToAction("Index");
        }
        //Lam rong gio hang
        public ActionResult ClearCart()
        {
            GetCartService().ClearCart();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateQuantity(int id, int quantity)
        {
            var cartService = GetCartService();
            cartService.GetCart().UpdateItem(id, quantity);
            return RedirectToAction("Index");
        }
    }
}