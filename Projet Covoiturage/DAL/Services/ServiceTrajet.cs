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
        }

        public void DeleteTrajet(string id)
        {
            uow.TrajetRepository.Delete(id);
        }

        public IEnumerable<Trajet> GetAllTrajet()
        {
            return uow.TrajetRepository.Get().ToList();
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
        }
    }
}