using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Projet_Covoiturage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Culture"] = new CultureInfo("fr");
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

        public ActionResult ChangeCultureEN()
        {
            Session["Culture"] = new CultureInfo("en-CA");
            return RedirectToAction("Index");
        }
        public ActionResult ChangeCultureFR()
        {
            Session["Culture"] = new CultureInfo("fr-CA");
            return RedirectToAction("Index");
        }
    }
}