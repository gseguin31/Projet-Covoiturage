using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet_Covoiturage.DAL.Services.interfa;
using Projet_Covoiturage.Models;

namespace Projet_Covoiturage.Controllers
{
    [Authorize]
    public class TrajetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IServiceTrajet service;
        // GET: Trajets

        public ActionResult Indexfiltre(String depart, String arriver)
        {
            return View(service.Filtre(depart, arriver));
        }

        public ActionResult Index()
        {

            return View();
        }

        // GET: Trajets/Details/5
    
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trajet trajet = db.Trajets.Find(id);
            if (trajet == null)
            {
                return HttpNotFound();
            }
            return View(trajet);
        }

        // POST: Trajets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Chaufeur")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VilleDepart,VilleDestination,DateDepart,HeureArrivee")] Trajet trajet)
        {
            if (ModelState.IsValid)
            {
                db.Trajets.Add(trajet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trajet);
        }

        // GET: Trajets/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Trajet trajet = db.Trajets.Find(id);
        //    if (trajet == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trajet);
        //}

        // POST: Trajets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VilleDepart,VilleDestination,DateDepart,HeureArrivee")] Trajet trajet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trajet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trajet);
        }

        // GET: Trajets/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Trajet trajet = db.Trajets.Find(id);
        //    if (trajet == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trajet);
        //}

        // POST: Trajets/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Trajet trajet = db.Trajets.Find(id);
        //    db.Trajets.Remove(trajet);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
