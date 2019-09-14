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
    public class HomeFirearmSafetiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HomeFirearmSafeties
        public ActionResult Index()
        {
            return View(db.HomeFirearmSafeties.ToList());
        }

        // GET: HomeFirearmSafeties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeFirearmSafety homeFirearmSafety = db.HomeFirearmSafeties.Find(id);
            if (homeFirearmSafety == null)
            {
                return HttpNotFound();
            }
            return View(homeFirearmSafety);
        }

        // GET: HomeFirearmSafeties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeFirearmSafeties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,Address,City,State,ZipCode,Phone,Email,CourseDate")] HomeFirearmSafety homeFirearmSafety)
        {
            if (ModelState.IsValid)
            {
                db.HomeFirearmSafeties.Add(homeFirearmSafety);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homeFirearmSafety);
        }

        // GET: HomeFirearmSafeties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeFirearmSafety homeFirearmSafety = db.HomeFirearmSafeties.Find(id);
            if (homeFirearmSafety == null)
            {
                return HttpNotFound();
            }
            return View(homeFirearmSafety);
        }

        // POST: HomeFirearmSafeties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,Address,City,State,ZipCode,Phone,Email,CourseDate")] HomeFirearmSafety homeFirearmSafety)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homeFirearmSafety).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeFirearmSafety);
        }

        // GET: HomeFirearmSafeties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeFirearmSafety homeFirearmSafety = db.HomeFirearmSafeties.Find(id);
            if (homeFirearmSafety == null)
            {
                return HttpNotFound();
            }
            return View(homeFirearmSafety);
        }

        // POST: HomeFirearmSafeties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeFirearmSafety homeFirearmSafety = db.HomeFirearmSafeties.Find(id);
            db.HomeFirearmSafeties.Remove(homeFirearmSafety);
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
