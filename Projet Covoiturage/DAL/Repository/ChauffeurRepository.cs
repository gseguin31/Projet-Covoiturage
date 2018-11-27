using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.DAL.Repository
{
    public class ChauffeurRepository : IChauffeurRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ChauffeurRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Chauffeur GetChauffeurById(int chauffeurId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trajet> GetTrajetsFor(int chauffeurId)
        {
            throw new NotImplementedException();
        }

        public int GetTotalKmFor(int chauffeurId)
        {
            throw new NotImplementedException();
        }

        public int GetPonctualiteAVGFor(int chauffeurId)
        {
            throw new NotImplementedException();
        }

        public int GetSecuriteAVGFor(int chauffeurId)
        {
            throw new NotImplementedException();
        }

        public int GetConfortAVGFor(int chauffeurId)
        {
            throw new NotImplementedException();
        }

        public int GetCourtoisieAVGFor(int chauffeurId)
        {
            throw new NotImplementedException();
        }

        public int GetFiabiliteAVGFor(int chauffeurId)
        {
            throw new NotImplementedException();
        }

        public Vehicule GetVehiculeFor(int chauffeurId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}