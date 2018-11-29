using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet_Covoiturage.DAL.Services.Interface;
using Projet_Covoiturage.Models;

namespace Projet_Covoiturage.Controllers
{
    public class ChauffeursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private IServiceChauffeur serviceChauffeur;

        public ChauffeursController(IServiceChauffeur serviceChauffeur)
        {
            this.serviceChauffeur = serviceChauffeur;
        }

        // GET: Chauffeurs
        public ActionResult Index(string id)
        {
            return View(serviceChauffeur.GetChauffeurById(id));
        }

        // GET: Chauffeurs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chauffeur chauffeur = (Chauffeur)db.Users.Find(id);
            if (chauffeur == null)
            {
                return HttpNotFound();
            }
            return View(chauffeur);
        }

        // GET: Chauffeurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chauffeurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,Courriel,Telephone,Ville,Age,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,DatePermis,DateEmbauche")] Chauffeur chauffeur)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(chauffeur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chauffeur);
        }

        // GET: Chauffeurs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chauffeur chauffeur = (Chauffeur)db.Users.Find(id);
            if (chauffeur == null)
            {
                return HttpNotFound();
            }
            return View(chauffeur);
        }

        // POST: Chauffeurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,Courriel,Telephone,Ville,Age,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,DatePermis,DateEmbauche")] Chauffeur chauffeur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chauffeur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chauffeur);
        }

        // GET: Chauffeurs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chauffeur chauffeur = (Chauffeur)db.Users.Find(id);
            if (chauffeur == null)
            {
                return HttpNotFound();
            }
            return View(chauffeur);
        }

        // POST: Chauffeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chauffeur chauffeur = (Chauffeur)db.Users.Find(id);
            db.Users.Remove(chauffeur);
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
