﻿using System;
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
    public class PersonalProtectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonalProtections
        public ActionResult Index()
        {
            return View(db.PersonalProtections.ToList());
        }

        // GET: PersonalProtections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalProtection personalProtection = db.PersonalProtections.Find(id);
            if (personalProtection == null)
            {
                return HttpNotFound();
            }
            return View(personalProtection);
        }

        // GET: PersonalProtections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalProtections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,Address,City,State,ZipCode,Phone,Email,CourseDate")] PersonalProtection personalProtection)
        {
            if (ModelState.IsValid)
            {
                db.PersonalProtections.Add(personalProtection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personalProtection);
        }

        // GET: PersonalProtections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalProtection personalProtection = db.PersonalProtections.Find(id);
            if (personalProtection == null)
            {
                return HttpNotFound();
            }
            return View(personalProtection);
        }

        // POST: PersonalProtections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,Address,City,State,ZipCode,Phone,Email,CourseDate")] PersonalProtection personalProtection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalProtection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalProtection);
        }

        // GET: PersonalProtections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalProtection personalProtection = db.PersonalProtections.Find(id);
            if (personalProtection == null)
            {
                return HttpNotFound();
            }
            return View(personalProtection);
        }

        // POST: PersonalProtections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalProtection personalProtection = db.PersonalProtections.Find(id);
            db.PersonalProtections.Remove(personalProtection);
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
