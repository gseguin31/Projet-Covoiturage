using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Covoiturage.DAL.Services
{
    public interface IServiceChauffeur
    {
        Chauffeur GetChauffeurById(string chauffeurId);
        IEnumerable<Trajet> GetTrajetsFor(int chauffeurId);
        double GetTotalKmFor(int chauffeurId);
        double GetPonctualiteAVGFor(int chauffeurId);
        double GetSecuriteAVGFor(int chauffeurId);
        double GetConfortAVGFor(int chauffeurId);
        double GetCourtoisieAVGFor(int chauffeurId);
        double GetFiabiliteAVGFor(int chauffeurId);
        Vehicule GetVehiculeFor(int chauffeurId);
    }
}
