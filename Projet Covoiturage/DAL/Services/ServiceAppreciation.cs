using Projet_Covoiturage.DAL.Services.Interface;
using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.DAL.Services
{
    public class ServiceAppreciation : IServiceAppreciation
    {
        public void CreateAppreciation(Appreciation appreciation)
        {
            throw new NotImplementedException();
        }

        public void DeleteAppreciation(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appreciation> GetAllAppreciation()
        {
            throw new NotImplementedException();
        }

        public Appreciation getAppreciation(string chauffeurId)
        {
            throw new NotImplementedException();
        }

        public Appreciation GetAppreciationById(string trajetId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appreciation> getAppreciationsFor(string chauffeurId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appreciation> GetAppreciationsFor(string chauffeurId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAppreciation(Appreciation trajet)
        {
            throw new NotImplementedException();
        }
    }
}