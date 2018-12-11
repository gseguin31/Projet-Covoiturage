using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projet_Covoiturage.DAL.Services.Interface;
using Projet_Covoiturage.DAL.UnitOfWork;
using Projet_Covoiturage.Models;

namespace Projet_Covoiturage.DAL.Services
{
    public class ServiceChauffeur : IServiceChauffeur
    {
        private IUnitOfWork uow;

        public ServiceChauffeur(IUnitOfWork uw)
        {
            uow = uw;
        }

        public void CreateChauffeur(Chauffeur chauffeur)
        {
            uow.ChauffeurRepository.Insert(chauffeur);
        }

        public void CreateVehicule(Vehicule vehicule)
        {
            uow.VehiculeRepository.Insert(vehicule);
        }

        public void DeleteChauffeur(string id)
        {
            uow.ChauffeurRepository.Delete(id);
        }

        public Chauffeur GetChauffeur(string chauffeurId)
        {
            return uow.ChauffeurRepository.GetByID(chauffeurId);
        }

        public double GetConfortAVGFor(string chauffeurId)
        {
            var query1 = uow.ChauffeurRepository.dbSet
                .Join(uow.TrajetRepository.dbSet,
                x => x.Id,
                y => y.Chauffeur.Id,
                (x, y) => new { Chauffeur = x, Trajet = y })
                .Join(uow.AppreciationRepository.dbSet,
                y => y.Trajet.Id,
                z => z.Trajet.Id,
                (y, z) => new { ChauffeurTrajet = y, Appreciation = z })
                .Where(c => c.ChauffeurTrajet.Chauffeur.Id.Equals(chauffeurId));


            double avg = query1.Count() > 0 ? query1
                .Average(AppreciationChauffeur => AppreciationChauffeur.Appreciation.Confort) : 0;

            return avg;
        }

        public double GetCourtoisieAVGFor(string chauffeurId)
        {

            var query1 = uow.ChauffeurRepository.dbSet
               .Join(uow.TrajetRepository.dbSet,
               x => x.Id,
               y => y.Chauffeur.Id,
               (x, y) => new { Chauffeur = x, Trajet = y })
               .Join(uow.AppreciationRepository.dbSet,
               y => y.Trajet.Id,
               z => z.Trajet.Id,
               (y, z) => new { ChauffeurTrajet = y, Appreciation = z })
               .Where(c => c.ChauffeurTrajet.Chauffeur.Id.Equals(chauffeurId));

            double avg = query1.Count() > 0 ? query1
                .Average(AppreciationChauffeur => AppreciationChauffeur.Appreciation.Courtoisie) : 0;

            return avg;
        }

        public double GetFiabiliteAVGFor(string chauffeurId)
        {
            var query1 = uow.ChauffeurRepository.dbSet
               .Join(uow.TrajetRepository.dbSet,
               x => x.Id,
               y => y.Chauffeur.Id,
               (x, y) => new { Chauffeur = x, Trajet = y })
               .Join(uow.AppreciationRepository.dbSet,
               y => y.Trajet.Id,
               z => z.Trajet.Id,
               (y, z) => new { ChauffeurTrajet = y, Appreciation = z })
               .Where(c => c.ChauffeurTrajet.Chauffeur.Id.Equals(chauffeurId));

            double avg = query1.Count() > 0 ? query1
                .Average(AppreciationChauffeur => AppreciationChauffeur.Appreciation.Fiabilite) : 0;

            return avg;
        }

        public double GetPonctualiteAVGFor(string chauffeurId)
        {
            var query1 = uow.ChauffeurRepository.dbSet
               .Join(uow.TrajetRepository.dbSet,
               x => x.Id,
               y => y.Chauffeur.Id,
               (x, y) => new { Chauffeur = x, Trajet = y })
               .Join(uow.AppreciationRepository.dbSet,
               y => y.Trajet.Id,
               z => z.Trajet.Id,
               (y, z) => new { ChauffeurTrajet = y, Appreciation = z })
               .Where(c => c.ChauffeurTrajet.Chauffeur.Id.Equals(chauffeurId));

            double avg = query1.Count() > 0 ? query1
                .Average(AppreciationChauffeur => AppreciationChauffeur.Appreciation.Ponctualite) : 0;

            return avg;
        }

        public double GetSecuriteAVGFor(string chauffeurId)
        {
            var query1 = uow.ChauffeurRepository.dbSet
               .Join(uow.TrajetRepository.dbSet,
               x => x.Id,
               y => y.Chauffeur.Id,
               (x, y) => new { Chauffeur = x, Trajet = y })
               .Join(uow.AppreciationRepository.dbSet,
               y => y.Trajet.Id,
               z => z.Trajet.Id,
               (y, z) => new { ChauffeurTrajet = y, Appreciation = z })
               .Where(c => c.ChauffeurTrajet.Chauffeur.Id.Equals(chauffeurId));

            double avg = query1.Count() > 0 ? query1
                .Average(AppreciationChauffeur => AppreciationChauffeur.Appreciation.Securite) : 0;

            return avg;
        }

        public double GetTotalKmFor(string chauffeurId)
        {
            GetTrajetsFor(chauffeurId).Average(x => x.Distance);
            return 12043.45;
        }

        public IEnumerable<Trajet> GetTrajetsFor(string chauffeurId)
        {
            return uow.TrajetRepository.Get().Where(x => x.Chauffeur.Id == chauffeurId).ToList();
        }

        public Vehicule GetVehiculeFor(string chauffeurId)
        {
            return uow.ChauffeurRepository.Get().Where(x => x.Id == chauffeurId).First().Vehicule;
        }

        public void UpdateChauffeur(Chauffeur chauffeur)
        {
            uow.ChauffeurRepository.Update(chauffeur);
        }
    }
}