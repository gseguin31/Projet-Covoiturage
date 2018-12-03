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

        private IQueryable TheUltimateBadassQuery(string chauffeurId)
        {
            var query = uow.AppreciationRepository.dbSet   // your starting point - table in the "from" statement
            .Join(uow.TrajetRepository.dbSet,              // the source table of the inner join
            x => x.Trajet.Id,                              // Select the primary key (the first part of the "on" clause in an sql "join" statement)
            y => y.Id,                                     // Select the foreign key (the second part of the "on" clause)
            (x, y) => new { Appreciation = x, Trajet = y })
            .Join(uow.ChauffeurRepository.dbSet,
            x => x.Trajet.Chauffeur.Id,
            y => y.Id,
            (x, y) => new { Trajet = x, Chauffeur = y })
            .Where(AppreciationChauffeur => AppreciationChauffeur.Chauffeur.Id.Equals(chauffeurId));

            return query;
        }

        public ServiceChauffeur(IUnitOfWork uw)
        {
            uow = uw;
        }

        public Chauffeur GetChauffeurById(string chauffeurId)
        {
            return uow.ChauffeurRepository.GetByID(chauffeurId);
        }

        public double GetConfortAVGFor(string chauffeurId)
        {
            var query = uow.AppreciationRepository.dbSet
            .Join(GetTrajetsFor(chauffeurId),
            x => x.Trajet.Id,
            y => y.Id,
            (x, y) => new { Appreciation = x, Trajet = y }).
            Average(AppreciationChauffeur => AppreciationChauffeur.Appreciation.Confort);

            return query;//
        }

        public double GetCourtoisieAVGFor(string chauffeurId)
        {

            var query = uow.AppreciationRepository.dbSet
            .Join(GetTrajetsFor(chauffeurId),
            x => x.Trajet.Id,
            y => y.Id,
            (x, y) => new { Appreciation = x, Trajet = y }).
            Average(AppreciationChauffeur => AppreciationChauffeur.Appreciation.Courtoisie);

            return query;
        }

        public double GetFiabiliteAVGFor(string chauffeurId)
        {
            var query = uow.AppreciationRepository.dbSet
            .Join(GetTrajetsFor(chauffeurId),
            x => x.Trajet.Id,
            y => y.Id,
            (x, y) => new { Appreciation = x, Trajet = y }).
            Average(AppreciationChauffeur => AppreciationChauffeur.Appreciation.Fiabilite);

            return query;
        }

        public double GetPonctualiteAVGFor(string chauffeurId)
        {
            var query = uow.AppreciationRepository.dbSet
            .Join(GetTrajetsFor(chauffeurId),
            x => x.Trajet.Id,
            y => y.Id,
            (x, y) => new { Appreciation = x, Trajet = y }).
            Average(AppreciationChauffeur => AppreciationChauffeur.Appreciation.Ponctualite);

            return query;//
        }

        public double GetSecuriteAVGFor(string chauffeurId)
        {
            var query = uow.AppreciationRepository.dbSet
            .Join(GetTrajetsFor(chauffeurId),
            x => x.Trajet.Id,
            y => y.Id,
            (x, y) => new { Appreciation = x, Trajet = y }).
            Average(AppreciationChauffeur => AppreciationChauffeur.Appreciation.Securite);

            return query;
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
    }
}