using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _23dh114467_NamStore.Models.ViewModel;
using _23dh114467_NamStore.Models;
using System.Runtime.Remoting.Messaging;
using System.Web.Security;

namespace _23dh114467_NamStore.Controllers
{
    public class AccountController : Controller
    {
        private MyStoreEntities db= new MyStoreEntities();
        // GET: Account/Register
        public ActionResult Register()
        {

            return View();
        }
        //POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
               //ktra ten dang nhap co ton tai chua
               var existingUser=db.Users.SingleOrDefault(u => u.Username == model.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("UserName", "Ten dang nhap da ton tai");
                return View(model);
                }
                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    UserRole = "Customer"   
                };
                db.Users.Add(user);
                //tao ban ghi thong tin khach hang trong bang Customers
                var customer = new Customer
                {
                    CustomerName = model.CustomerName,
                    CustomerEmail = model.CustomerEmail,
                    CustomerPhone = model.CustomerPhone,

                    CustomerAddress = model.CustomerAddress,
                    Username = model.Username,
                };
                db.Customers.Add(customer);
                //luu thong tin khach hang va thong tin tai khoan vao csdl
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(model);

        }
    }
}