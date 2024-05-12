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
    public class MultiplexesController : Controller
    {
        private ABCShoppingMallContext db = new ABCShoppingMallContext();

        // GET: Multiplexes
        public ActionResult Index()
        {
            return View(db.Multiplexes.ToList());
        }

        // GET: Multiplexes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multiplex multiplex = db.Multiplexes.Find(id);
            if (multiplex == null)
            {
                return HttpNotFound();
            }
            return View(multiplex);
        }

        // GET: Multiplexes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Multiplexes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TotalSeats")] Multiplex multiplex)
        {
            if (ModelState.IsValid)
            {
                db.Multiplexes.Add(multiplex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(multiplex);
        }

        // GET: Multiplexes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multiplex multiplex = db.Multiplexes.Find(id);
            if (multiplex == null)
            {
                return HttpNotFound();
            }
            return View(multiplex);
        }

        // POST: Multiplexes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TotalSeats")] Multiplex multiplex)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multiplex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(multiplex);
        }

        // GET: Multiplexes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multiplex multiplex = db.Multiplexes.Find(id);
            if (multiplex == null)
            {
                return HttpNotFound();
            }
            return View(multiplex);
        }

        // POST: Multiplexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Multiplex multiplex = db.Multiplexes.Find(id);
            db.Multiplexes.Remove(multiplex);
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
