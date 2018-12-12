using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Projet_Covoiturage.DAL.Services;
using Projet_Covoiturage.DAL.Services.Interface;
using Projet_Covoiturage.Models;
using Projet_Covoiturage.Models.ViewModel;

namespace Projet_Covoiturage.Controllers
{
    //[Authorize]
    public class TrajetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IServiceTrajet serviceTrajet;
        private IServiceReservation serviceReservation;
        private IServiceClient serviceClient;
        // GET: Trajets

        public TrajetsController(IServiceTrajet serviceTrajet, IServiceReservation serviceReservation, IServiceClient serviceClient)
        {
            //User manager n'est pas injectable. il va faloir trouver un autre facon d'avoir le user.
            this.serviceTrajet = serviceTrajet;
            this.serviceReservation = serviceReservation;
            this.serviceClient = serviceClient;
        }
        
        // GET: Trajets
        [Route]
        public ActionResult Index([Bind(Include = "Depard,Arriver")] FilteTrajet filtre)
        {
          
            return View("Index");
        }
        public ActionResult Indexfiltre(FilteTrajet filtreTrajet)
        {
            ////if(filtreTrajet == null ||  filtreTrajet.Arriver==null||filtreTrajet.Depart==null)
            {
               return PartialView(serviceTrajet.GetAllTrajet());
            }

            return PartialView(serviceTrajet.GetTrajetsFor(filtreTrajet.Depart, filtreTrajet.Arriver));
        }
        //public ActionResult Index()
        //{
        //    // List<Trajet> trajet = service.GetAllTrajet().ToList();
           
        //    return View(service.GetAllTrajet());
        //}

        // GET: Trajets/Details/5

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trajet trajet = serviceTrajet.GetTrajetById(id);
            if (trajet == null)
            {
                return HttpNotFound();
            }
            return View(trajet);
        }

        // POST: Trajets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Chaufeur")]
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
        [Authorize(Roles = "Client")]
        public void Reserver(string idTrajet, string userId)
        {
            Trajet trajetReserver = serviceTrajet.GetTrajetById(idTrajet);

            //User manager n'est pas injectable. il va faloir trouver un autre facon d'avoir le user.

           //ApplicationUser user = this.applicationManager.FindById(User.Identity.GetUserId());
            ApplicationUser user = serviceClient.GetClient(userId);

            Reservation reservation = new Reservation();

            reservation.ClientId = user.Id;
            reservation.TrajetId = trajetReserver.Id;

            serviceReservation.CreateReservation(reservation);
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
