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
        public List<Trajet> Filtre(string depar, string arriver)
        {
            throw new NotImplementedException();
        }

        public void Reserver(ApplicationUser client, int trajetId)
        {

        }

        public void AnnuleReserver(ApplicationUser client, int trajetId)
        {

        }

        public void CreateTrajet(ApplicationUser chaufeur, Trajet courrent)
        {

        }

        public Trajet GetTrajet(int id)
        {
            throw new NotImplementedException();
        }
    }
}