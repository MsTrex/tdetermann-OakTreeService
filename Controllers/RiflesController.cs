using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GunSafety2.Models;

namespace GunSafety2.Controllers
{
    public class RiflesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rifles
        public ActionResult Index()
        {
            return View(db.Rifles.ToList());
        }

        // GET: Rifles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rifle rifle = db.Rifles.Find(id);
            if (rifle == null)
            {
                return HttpNotFound();
            }
            return View(rifle);
        }

        // GET: Rifles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rifles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,Address,City,State,ZipCode,Phone,Email,CourseDate")] Rifle rifle)
        {
            if (ModelState.IsValid)
            {
                db.Rifles.Add(rifle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rifle);
        }

        // GET: Rifles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rifle rifle = db.Rifles.Find(id);
            if (rifle == null)
            {
                return HttpNotFound();
            }
            return View(rifle);
        }

        // POST: Rifles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,Address,City,State,ZipCode,Phone,Email,CourseDate")] Rifle rifle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rifle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rifle);
        }

        // GET: Rifles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rifle rifle = db.Rifles.Find(id);
            if (rifle == null)
            {
                return HttpNotFound();
            }
            return View(rifle);
        }

        // POST: Rifles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rifle rifle = db.Rifles.Find(id);
            db.Rifles.Remove(rifle);
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
