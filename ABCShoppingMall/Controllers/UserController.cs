using ABCShoppingMall.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCShoppingMall.Controllers
{
    public class UserController : Controller
    {
       

       public ABCShoppingMallContext db = new ABCShoppingMallContext();
        

     

        // GET: User
        public ActionResult Index()
        {
            var images = db.ShoppingCenters.ToList();
            ViewBag.ImageId = images;

            return View(images);

            //int imageId = db.ShoppingCenters.Where(a=>a.Id).FirstOrDefault().ID;
            //ViewBag.ImageId = imageId;
            //return View();

        }

        public ActionResult DisplayImage(int id)
        {

            //var image = db.ShoppingCenters.Find(id);
            var image = db.ShoppingCenters.FirstOrDefault(x => x.Id == id);
            
            return File(image.Image, "image/jpeg");
        }


       
    }
}