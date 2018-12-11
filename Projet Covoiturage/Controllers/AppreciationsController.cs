using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet_Covoiturage.Models;

namespace Projet_Covoiturage.Controllers
{
    [Authorize]
    public class AppreciationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Appreciations
        public ActionResult Index()
        {
            return View(db.Appreciations.ToList());
        }

        // GET: Appreciations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appreciation appreciation = db.Appreciations.Find(id);
            if (appreciation == null)
            {
                return HttpNotFound();
            }
            return View(appreciation);
        }

        // GET: Appreciations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appreciations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Commentaire,Ponctualite,Securite,Fiabilite,Confort,Courtoisie")] Appreciation appreciation)
        {
            if (ModelState.IsValid)
            {
                db.Appreciations.Add(appreciation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appreciation);
        }

        // GET: Appreciations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appreciation appreciation = db.Appreciations.Find(id);
            if (appreciation == null)
            {
                return HttpNotFound();
            }
            return View(appreciation);
        }

        // POST: Appreciations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Commentaire,Ponctualite,Securite,Fiabilite,Confort,Courtoisie")] Appreciation appreciation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appreciation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appreciation);
        }

        // GET: Appreciations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appreciation appreciation = db.Appreciations.Find(id);
            if (appreciation == null)
            {
                return HttpNotFound();
            }
            return View(appreciation);
        }

        // POST: Appreciations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Appreciation appreciation = db.Appreciations.Find(id);
            db.Appreciations.Remove(appreciation);
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
