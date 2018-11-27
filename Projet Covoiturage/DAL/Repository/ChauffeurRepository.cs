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
            //euh.. à voir
            return (Chauffeur)context.Users.Find(chauffeurId);
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