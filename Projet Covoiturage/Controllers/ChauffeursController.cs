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

        public ActionResult Details(Chauffeur chauffeur)
        {
            if (chauffeur == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChauffeurInfoViewModel vm = new ChauffeurInfoViewModel
            {
                Confort = serviceChauffeur.GetConfortAVGFor(chauffeur.Id),
                Courtoisie = serviceChauffeur.GetCourtoisieAVGFor(chauffeur.Id),
                Fiabilite = serviceChauffeur.GetFiabiliteAVGFor(chauffeur.Id),
                Ponctualite = serviceChauffeur.GetPonctualiteAVGFor(chauffeur.Id),
                Securite = serviceChauffeur.GetSecuriteAVGFor(chauffeur.Id),

                // a mettre lorsque le service acceptera
                Trajets = serviceChauffeur.GetTrajetsFor(chauffeur.Id).ToList(),
                Vehicule = serviceChauffeur.GetVehiculeFor(chauffeur.Id)

                //// a enlever lorsque le service acceptera
                //Trajets = new List<Trajet> { new Trajet { Id = "grosN", Appreciations = new List<Appreciation>(),
                //    Chauffeur = chauffeur, DateDepart = DateTime.Now, HeureArrivee = DateTime.Now.AddHours(2),
                //    Reservations = new List<Reservation>(), VilleDepart = "tamere", VilleDestination = "ton autre mere"},
                //new Trajet { Id = "grosN", Appreciations = new List<Appreciation>(),
                //    Chauffeur = chauffeur, DateDepart = DateTime.Now, HeureArrivee = DateTime.Now.AddHours(2),
                //    Reservations = new List<Reservation>(), VilleDepart = "tasoeur", VilleDestination = "ton autre soeur"}},
                //Vehicule = new Vehicule { DateMiseEnRoute = DateTime.Now, Id = "char", Modele = "subaru malade", NombrePlace = 3 }
            };

            return View(vm);
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
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,Courriel,Telephone,Ville,Age,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,DatePermis,DateEmbauche")] ApplicationUser chauffeur)
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
            ApplicationUser chauffeur = db.Users.Find(id);
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
            ApplicationUser chauffeur = db.Users.Find(id);
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
            ApplicationUser chauffeur = db.Users.Find(id);
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
