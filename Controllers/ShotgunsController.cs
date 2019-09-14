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
    public class ShotgunsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Shotguns
        public ActionResult Index()
        {
            return View(db.Shotguns.ToList());
        }

        // GET: Shotguns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shotgun shotgun = db.Shotguns.Find(id);
            if (shotgun == null)
            {
                return HttpNotFound();
            }
            return View(shotgun);
        }

        // GET: Shotguns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shotguns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,Address,City,State,ZipCode,Phone,Email,CourseDate")] Shotgun shotgun)
        {
            if (ModelState.IsValid)
            {
                db.Shotguns.Add(shotgun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shotgun);
        }

        // GET: Shotguns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shotgun shotgun = db.Shotguns.Find(id);
            if (shotgun == null)
            {
                return HttpNotFound();
            }
            return View(shotgun);
        }

        // POST: Shotguns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,Address,City,State,ZipCode,Phone,Email,CourseDate")] Shotgun shotgun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shotgun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shotgun);
        }

        // GET: Shotguns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shotgun shotgun = db.Shotguns.Find(id);
            if (shotgun == null)
            {
                return HttpNotFound();
            }
            return View(shotgun);
        }

        // POST: Shotguns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shotgun shotgun = db.Shotguns.Find(id);
            db.Shotguns.Remove(shotgun);
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
