using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Covoiturage.DAL.Services.Interface
{
    public interface IServiceTrajet
    {
        Trajet GetTrajetById(string trajetId);
        IEnumerable<Trajet> GetAllTrajet();
        IEnumerable<Trajet> GetAllTrajetWithRemainingSpace();
        IEnumerable<Trajet> GetTrajetsFor(string villeDepard,string villeArriver);
        IEnumerable<Trajet> GetTrajetsFor(string chauffeurId);
        void CreateTrajet(Trajet trajet);
        void DeleteTrajet(string id);
        void UpdateTrajet(Trajet trajet);
        
    }
}
