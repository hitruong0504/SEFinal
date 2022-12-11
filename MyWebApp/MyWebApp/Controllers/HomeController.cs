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
        private DbHelper db = new DbHelper();


        public HomeController()
        {
            myList = db.products.ToList();
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


        public ActionResult SignUp()
        {
            return View();
        }
    }
}