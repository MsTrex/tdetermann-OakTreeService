using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GunSafety2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Courses()
        {
            ViewBag.Message = "Courses We Offer.";

            return View();
        }

        public ActionResult HomeFirearmSafeties()
        {
            ViewBag.Message = "Safety In The Home";
            return View();
        }

        public ActionResult PersonalProtections()
        {
            ViewBag.Message = "Protect yourself.";
            return View();
        }

        public ActionResult Pistols()
        {
            ViewBag.Message = "Safety With Pistols";
            return View();
        }

        public ActionResult Rifles()
        {
            ViewBag.Message = "Safety With Rifles.";
            return View();
        }

        public ActionResult Shotguns()
        {
            ViewBag.Message = "Safety With Shotguns.";
            return View();
        }

    }
}