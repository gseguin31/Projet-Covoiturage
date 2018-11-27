using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projet_Covoiturage.DAL.Repository;
using Projet_Covoiturage.Models;

namespace Projet_Covoiturage.DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public ApplicationDbContext context;
        public GenericRepository<Chauffeur> chauffeurRepo;

        public UnitOfWork(ApplicationDbContext cx)
        {
            context = cx;
        }

        public GenericRepository<Chauffeur> ChauffeurRepository
        {
            get
            {
                if (chauffeurRepo == null)
                {
                    chauffeurRepo = new GenericRepository<Chauffeur>(context);
                }
                return chauffeurRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}