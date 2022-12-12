using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private List<Product> myList = new List<Product>();
        private List<Account> accountList = new List<Account>();
        private DbHelper db = new DbHelper();


        public HomeController()
        {
            myList = db.products.ToList();
            accountList = db.account.ToList();
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

        public ActionResult Login()
        {
            ViewBag.Message = "Login page.";
            return View();
        }

        public ActionResult Details(int id)
        {
            Product product = myList.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
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
         * Đăng Ký Tài Khoản
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

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}