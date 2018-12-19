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

        public ActionResult EN()
        {
            Session["Culture"] = new CultureInfo("en");
            String url = Request.UrlReferrer.ToString();
            return Redirect(url);
       
        }
        public ActionResult FR()
        {
            Session["Culture"] = new CultureInfo("fr");
            String url = Request.UrlReferrer.ToString();
            return Redirect(url);

        }
    }
}