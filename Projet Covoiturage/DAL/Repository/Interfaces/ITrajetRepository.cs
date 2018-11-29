using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.DAL.Repository.Interfaces
{
    public interface ITrajetRepository : IDisposable
    {
        Trajet GetTrajet(string id);
        IEnumerable<Trajet> GetAllTrajet();
        void CreateTrajet(Trajet trajet);
        void DeleteTrajet(string id);
        void UpdateTrajet(Trajet trajet);
        void Save();
    }
}