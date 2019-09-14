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
    public class PistolsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pistols
        public ActionResult Index()
        {
            return View(db.Pistols.ToList());
        }

        // GET: Pistols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pistol pistol = db.Pistols.Find(id);
            if (pistol == null)
            {
                return HttpNotFound();
            }
            return View(pistol);
        }

        // GET: Pistols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pistols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,Address,City,State,ZipCode,Phone,Email,CourseDate")] Pistol pistol)
        {
            if (ModelState.IsValid)
            {
                db.Pistols.Add(pistol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pistol);
        }

        // GET: Pistols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pistol pistol = db.Pistols.Find(id);
            if (pistol == null)
            {
                return HttpNotFound();
            }
            return View(pistol);
        }

        // POST: Pistols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,Address,City,State,ZipCode,Phone,Email,CourseDate")] Pistol pistol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pistol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pistol);
        }

        // GET: Pistols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pistol pistol = db.Pistols.Find(id);
            if (pistol == null)
            {
                return HttpNotFound();
            }
            return View(pistol);
        }

        // POST: Pistols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pistol pistol = db.Pistols.Find(id);
            db.Pistols.Remove(pistol);
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
