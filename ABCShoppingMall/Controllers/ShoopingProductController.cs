using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABCShoppingMall.Data;
using ABCShoppingMall.Models;

namespace ABCShoppingMall.Controllers
{
    public class ShoopingProductController : Controller
    {
        private ABCShoppingMallContext db = new ABCShoppingMallContext();

        // GET: ShoopingProduct
        public ActionResult Index()
        {
            return View(db.ShoppingCenters.ToList());
        }

        // GET: ShoopingProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCenter shoppingCenter = db.ShoppingCenters.Find(id);
            if (shoppingCenter == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCenter);
        }

        // GET: ShoopingProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoopingProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShopName,Shop_Detail,Image")] ShoppingCenter shoppingCenter)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingCenters.Add(shoppingCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingCenter);
        }

        // GET: ShoopingProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCenter shoppingCenter = db.ShoppingCenters.Find(id);
            if (shoppingCenter == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCenter);
        }

        // POST: ShoopingProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShopName,Shop_Detail,Image")] ShoppingCenter shoppingCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingCenter);
        }

        // GET: ShoopingProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCenter shoppingCenter = db.ShoppingCenters.Find(id);
            if (shoppingCenter == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCenter);
        }

        // POST: ShoopingProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingCenter shoppingCenter = db.ShoppingCenters.Find(id);
            db.ShoppingCenters.Remove(shoppingCenter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
