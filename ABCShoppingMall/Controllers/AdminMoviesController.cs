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
    public class AdminMoviesController : Controller
    {
        private ABCShoppingMallContext db = new ABCShoppingMallContext();

        // GET: AdminMovies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Multiplex);
            return View(movies.ToList());
        }

        // GET: AdminMovies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: AdminMovies/Create
        public ActionResult Create()
        {
            ViewBag.MultiplexId = new SelectList(db.Multiplexes, "Id", "Name");
            return View();
        }

        // POST: AdminMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MultiplexId,SeatsAvailable,Image,File")] Movie movie)
        {
            string filename = Path.GetFileName(movie.File.FileName);
            string _filename = DateTime.Now.ToString("hhmmssfff") + filename;
            string path = Path.Combine(Server.MapPath("~/Images/"), _filename);

            movie.Image = "~/Images/" + _filename;
            ViewBag.Image = movie.Image;
            db.Movies.Add(movie);




            if (db.SaveChanges() > 0)
            {
                movie.File.SaveAs(path);
            };
            return RedirectToAction("Index");

        }

        // GET: AdminMovies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.MultiplexId = new SelectList(db.Multiplexes, "Id", "Name", movie.MultiplexId);
            return View(movie);
        }

        // POST: AdminMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MultiplexId,SeatsAvailable,Image")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MultiplexId = new SelectList(db.Multiplexes, "Id", "Name", movie.MultiplexId);
            return View(movie);
        }

        // GET: AdminMovies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: AdminMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
