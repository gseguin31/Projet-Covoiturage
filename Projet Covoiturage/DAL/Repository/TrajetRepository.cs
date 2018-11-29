using Projet_Covoiturage.DAL.Repository.Interfaces;
using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.DAL.Repository
{
    public class TrajetRepository : ITrajetRepository
    {
        private ApplicationDbContext context;

        public TrajetRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Trajet GetTrajet(string id)
        {
            return context.Trajets.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Trajet> GetAllTrajet()
        {
            return context.Trajets.ToList();
        }

        public void CreateTrajet(Trajet trajet)
        {
            context.Trajets.Add(trajet);
            Save();
        }

        public void DeleteTrajet(string id)
        {
            Trajet trajet = context.Trajets.Find(id);
            if (trajet != null)
            {
                context.Trajets.Remove(trajet);
                Save();
            }
        }

        public void UpdateTrajet(Trajet trajet)
        {
            if (trajet != null)
            {
                context.Entry(trajet).State = EntityState.Modified;
                Save();
            }
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