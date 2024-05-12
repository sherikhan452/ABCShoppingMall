using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABCShoppingMall.Data;
using ABCShoppingMall.Models;

namespace ABCShoppingMall.Controllers
{
    public class FoodCourtsController : Controller
    {
        private ABCShoppingMallContext db = new ABCShoppingMallContext();

        // GET: FoodCourts
        public ActionResult Index()
        {
            return View(db.FoodCourts.ToList());
        }

        // GET: FoodCourts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodCourt foodCourt = db.FoodCourts.Find(id);
            if (foodCourt == null)
            {
                return HttpNotFound();
            }
            return View(foodCourt);
        }

        // GET: FoodCourts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodCourts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FoodName,Food_Detail,Image,Items,File")] FoodCourt foodCourt)
        {
            string filename = Path.GetFileName(foodCourt.File.FileName);
            string _filename = DateTime.Now.ToString("hhmmssfff") + filename;
            string path = Path.Combine(Server.MapPath("~/Images/"), _filename);

            foodCourt.Image = "~/Images/" + _filename;
            db.FoodCourts.Add(foodCourt);




            if (db.SaveChanges() > 0)
            {
                foodCourt.File.SaveAs(path);
            };
            return RedirectToAction("Index");

        }

    

    // GET: FoodCourts/Edit/5
    public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodCourt foodCourt = db.FoodCourts.Find(id);
            if (foodCourt == null)
            {
                return HttpNotFound();
            }
            return View(foodCourt);
        }

        // POST: FoodCourts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FoodName,Food_Detail,Image,Items")] FoodCourt foodCourt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodCourt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodCourt);
        }

        // GET: FoodCourts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodCourt foodCourt = db.FoodCourts.Find(id);
            if (foodCourt == null)
            {
                return HttpNotFound();
            }
            return View(foodCourt);
        }

        // POST: FoodCourts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodCourt foodCourt = db.FoodCourts.Find(id);
            db.FoodCourts.Remove(foodCourt);
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
