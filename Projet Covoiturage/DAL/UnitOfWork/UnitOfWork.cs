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
        public GenericRepository<Client> clientRepo;
        public GenericRepository<Trajet> trajetRepo;
        public GenericRepository<Appreciation> appreciationRepo;

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

        public GenericRepository<Appreciation> AppreciationRepository
        {
            get
            {
                if (appreciationRepo == null)
                {
                    appreciationRepo = new GenericRepository<Appreciation>(context);
                }
                return appreciationRepo;
            }
        }

        public GenericRepository<Client> ClientRepository
        {
            get
            {
                if (chauffeurRepo == null)
                {
                    chauffeurRepo = new GenericRepository<Chauffeur>(context);
                }
                return clientRepo;
            }
        }

        public GenericRepository<Trajet> TrajetRepository
        {
            get
            {
                if (trajetRepo == null)
                {
                    trajetRepo = new GenericRepository<Trajet>(context);
                }
                return trajetRepo;
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