using Projet_Covoiturage.DAL.Services.Interface;
using Projet_Covoiturage.DAL.UnitOfWork;
using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.DAL.Services
{
    public class ServiceTrajet : IServiceTrajet
    {
        private IUnitOfWork uow;

        public ServiceTrajet(IUnitOfWork uw)
        {
            uow = uw;
        }

        public void CreateTrajet(Trajet trajet)
        {
            uow.TrajetRepository.Insert(trajet);
            uow.Save();
        }
        public void DeleteTrajet(string id)
        {
            uow.TrajetRepository.Delete(id);
            uow.Save();
        }
        public IEnumerable<Trajet> GetAllTrajet()
        {
            return uow.TrajetRepository.Get().ToList();
        }
        public IEnumerable<Trajet> GetAllTrajetWithRemainingSpace()
        {
            List<Trajet> results = new List<Trajet>();
            List<Trajet> trajet = uow.TrajetRepository.Get().ToList();
            foreach (Trajet trajetCourrant in trajet)
            {
                int placeDePrise = uow.TrajetRepository.GetByID(trajetCourrant.Id).Reservations.Count;
                if (placeDePrise < trajetCourrant.NombreDePlaceDuVehicule)
                {
                    results.Add(trajetCourrant);
                
                }
            }
            return results;
        }

        public Trajet GetTrajetById(string trajetId)
        {
            return uow.TrajetRepository.GetByID(trajetId);

        }

        public IEnumerable<Trajet> GetTrajetsFor(string chauffeurId)
        {
            return uow.TrajetRepository.Get(x => x.Chauffeur.Id == chauffeurId).ToList();
        }

        public IEnumerable<Trajet> GetTrajetsFor(string villeDepard, string villeArriver)
        {
            return uow.TrajetRepository.Get(x => x.VilleDepart == villeDepard && x.VilleDestination==villeArriver).ToList();
        }

        public void UpdateTrajet(Trajet trajet)
        {
            uow.TrajetRepository.Update(trajet);
            uow.Save();
        }
        public void ReserveTrajet(string idTrajet,string idClient)
        {
            
            uow.ReservationRepository.Insert(new Reservation() {TrajetId=idTrajet,ClientId=idClient});
        }
    }
}