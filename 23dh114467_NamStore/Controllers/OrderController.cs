using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _23dh114467_NamStore.Models.ViewModel;
using _23dh114467_NamStore.Models;
using Microsoft.Ajax.Utilities;

namespace _23dh114467_NamStore.Controllers
{
    public class OrderController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        //GET:Order/Checkout
        [Authorize]
        public ActionResult Checkout()
        {
            var cart = Session["Cart"] as List<CartItem>;
            if (cart ==null ||cart.Any())
            {
                return RedirectToAction("Index", "Home");
            }
            var user = db.Users.SingleOrDefault(u => u.Username == User.Identity.Name);
            if(user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var customer = db.Customers.SingleOrDefault(c => c.Username == user.Username);
            if(customer==null)
            {
                return RedirectToAction("Login", "Account");
            }
            var model = new CheckoutVM
            {
               CartItems = cart,
               TotalAmount=cart.Sum(item=>item.TotalPrice),
               OrderDate= DateTime.Now,
               AddressDelivery= customer.CustomerAddress,
               CustomerId = customer.CustomerID,
               UserName=customer.Username
            };
            return View(model);
        }
        //POST:Order/Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Checkout(CheckoutVM model)
        {
            if (ModelState.IsValid)
            {
                var cart=Session["Cart"] as List<CartItem>;
                if (cart == null || cart.Any())
                {
                    return RedirectToAction("Index", "Home");
                }
               var user = db.Users.SingleOrDefault(u => u.Username == User.Identity.Name);
                if (user == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                var customer = db.Customers.SingleOrDefault(c => c.Username == user.Username);
                if (customer == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                if(model.PaymentMethod == "Paypal")
                {
                    return RedirectToAction("PaymentWithPaypal", "Paypal",model);
                }
                string paymentStatus = "Chua thanh toan";
                switch(model.PaymentMethod)
                {
                    case "Tien mat":
                        paymentStatus = "Da thanh toan bang tien mat";
                        break;
                    case "Paypal":
                        paymentStatus = "Da thanh toan bang Paypal";
                        break;
                    case "Tra gop":
                        paymentStatus = "Da thanh toan bang hinh thuc tra gop";
                        break;
                    default:
                        paymentStatus = "Chua thanh toan";
                        break;
                }
                //Tao don hang va chi tiet don hang lien quan
                var order = new Order
                {
                    CustomerID = customer.CustomerID,
                    OrderDate = model.OrderDate,
                    TotalAmount = model.TotalAmount,
                    PaymentStatus = paymentStatus,
                    PaymentMethod = model.PaymentMethod,
                    DeliveryMethod = model.DeliveryMethod,
                    AddressDelivery = model.AddressDelivery,
                    OrderDetails=cart.Select(item => new OrderDetail
                    {
                        ProductID = item.ProductId,
                        
                        
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        TotalPrice = item.TotalPrice
                    }).ToList()
                };
                //Luu don hang vao CSDL
                db.Orders.Add(order);
                db.SaveChanges();
                //Xoa gio hang sau khi dat hang thanh cong
                Session["Cart"] = null;
                //Dieu huong toi trang xac nhan dat hang
                return RedirectToAction("OrderSuccess", new {id = order.OrderID });
            }
            return View(model);
        }   
    }
}