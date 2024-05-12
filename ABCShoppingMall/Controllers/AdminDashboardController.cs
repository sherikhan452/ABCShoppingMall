using ABCShoppingMall.Data;
using ABCShoppingMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCShoppingMall.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: AdminDashboard

        ABCShoppingMallContext c = new ABCShoppingMallContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(AdminLogin L)
        {
            var x = c.AdminLogins.Where(a => a.AdminName == L.AdminName && a.Password == L.Password).SingleOrDefault();
            if (x != null)
            {
                Session["username"] = L.AdminName;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.m = "Wrong Id or Password";
                return View();
            }


        }


        public ActionResult Dashboard()
        {

            return View();
        }
    }
}