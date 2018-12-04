using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Covoiturage.DAL.Services.Interface
{
    public interface IServiceChauffeur
    {
        Chauffeur GetChauffeur(string chauffeurId);
        IEnumerable<Trajet> GetTrajetsFor(string chauffeurId);
        double GetTotalKmFor(string chauffeurId);
        double GetPonctualiteAVGFor(string chauffeurId);
        double GetSecuriteAVGFor(string chauffeurId);
        double GetConfortAVGFor(string chauffeurId);
        double GetCourtoisieAVGFor(string chauffeurId);
        double GetFiabiliteAVGFor(string chauffeurId);
        Vehicule GetVehiculeFor(string chauffeurId);
    }
}
