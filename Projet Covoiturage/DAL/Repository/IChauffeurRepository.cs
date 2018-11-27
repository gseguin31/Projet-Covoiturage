using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Covoiturage.DAL.Repository
{
    interface IChauffeurRepository : IDisposable
    {
        Chauffeur GetChauffeurById(int chauffeurId);
        IEnumerable<Trajet> GetTrajetsFor(int chauffeurId);
        int GetTotalKmFor(int chauffeurId);
        int GetPonctualiteAVGFor(int chauffeurId);
        int GetSecuriteAVGFor(int chauffeurId);
        int GetConfortAVGFor(int chauffeurId);
        int GetCourtoisieAVGFor(int chauffeurId);
        int GetFiabiliteAVGFor(int chauffeurId);
        Vehicule GetVehiculeFor(int chauffeurId);
        void Save();
    }
}
