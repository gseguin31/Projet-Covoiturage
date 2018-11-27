using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public Chauffeur GetChauffeurById(int chauffeurId)
        {
            return uow.ChauffeurRepository.GetByID(chauffeurId);
        }

        public double GetConfortAVGFor(int chauffeurId)
        {
            //retourner fausse valeur pour le moment
            return 3.45;
        }

        public double GetCourtoisieAVGFor(int chauffeurId)
        {
            //retourner fausse valeur pour le moment
            return 5;
        }

        public double GetFiabiliteAVGFor(int chauffeurId)
        {
            //retourner fausse valeur pour le moment
            return 4.45;
        }

        public double GetPonctualiteAVGFor(int chauffeurId)
        {
            //retourner fausse valeur pour le moment
            return 2.45;
        }

        public double GetSecuriteAVGFor(int chauffeurId)
        {
            //retourner fausse valeur pour le moment
            return 3.8;
        }

        public double GetTotalKmFor(int chauffeurId)
        {
            //retourner fausse valeur pour le moment
            return 12043.45;
        }

        public IEnumerable<Trajet> GetTrajetsFor(int chauffeurId)
        {
            throw new NotImplementedException();
        }

        public Vehicule GetVehiculeFor(int chauffeurId)
        {
            throw new NotImplementedException();
        }
    }
}