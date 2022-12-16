using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private List<Product> myList = new List<Product>();
        private List<Account> accountList = new List<Account>();
        private List<Cart> shopCartList = new List<Cart>();
        private DbHelper db = new DbHelper();

        public HomeController()
        {
            myList = db.products.ToList();
            accountList = db.account.ToList();
            shopCartList = db.Cart.ToList();
        }

        public ActionResult Index()
        {
            return View(myList);
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

        /*
         * Sign In
         */

        public ActionResult Login()
        {
            ViewBag.Message = "Login page.";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string accountName, string password)
        {
            if (ModelState.IsValid)
            {
                var data = db.account.Where(s => s.AccountName.Equals(accountName) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["AccountName"] = data.FirstOrDefault().AccountName;
                    Session["Id"] = data.FirstOrDefault().Id;
                    Session["FullName"] = data.FirstOrDefault().FullName();
                    Session["FirstName"] = data.FirstOrDefault().FirstName;
                    Session["LastName"] = data.FirstOrDefault().LastName;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "SignIn failed";
                    return RedirectToAction("LogIn");
                }
            }
            return View();
        }


        /*
         * Sign Up
         */
        public ActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Account account)
        {
            if (ModelState.IsValid)
            {
                account.Role = "user";
                var check = db.account.FirstOrDefault(s => s.Email == account.Email);
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.account.Add(account);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        /*
         * Show detail or product
         */

        public ActionResult Details(int id)
        {
            Product product = myList.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int id, Product product)
        {
            product = (Product)db.products.FirstOrDefault(s => s.Id.Equals(id));

            Cart cart = new Cart();
            cart.product_id = product.Id;
            cart.img = product.Img;
            cart.name = product.Name;
            cart.description = product.Describe;
            cart.amount = 1;
            cart.price = product.Price;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.Cart.Add(cart);
            db.SaveChanges();
            return View(product);
        }

        public ActionResult Cart()
        {
            ViewBag.Message = "Shopping Cart";
            return View(shopCartList);
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Payment()
        {
            ViewBag.Message = "Payment";

            return View();
        }

        public ActionResult Success()
        {
            ViewBag.Message = "Success";
            db.Cart.RemoveRange(db.Cart.ToList());
            db.SaveChanges();
            return View();
        }
    }
}