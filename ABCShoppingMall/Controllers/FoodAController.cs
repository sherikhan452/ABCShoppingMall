using ABCShoppingMall.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCShoppingMall.Controllers
{
    public class FoodAController : Controller
    {
        private ABCShoppingMallContext db = new ABCShoppingMallContext();
        // GET: FoodA
        public ActionResult Index()
        {
            var images = db.FoodCourts.ToList();
            ViewBag.ImageId = images;

            return View(images);

        }

        public ActionResult DisplayImage(int id)
        {

            //var image = db.ShoppingCenters.Find(id);
            var image = db.FoodCourts.FirstOrDefault(x => x.Id == id);

            return File(image.Image, "image/jpeg");
        }

    }
}