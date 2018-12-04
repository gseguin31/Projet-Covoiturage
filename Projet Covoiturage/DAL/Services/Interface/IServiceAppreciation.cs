using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Covoiturage.DAL.Services.Interface
{
    interface IServiceAppreciation
    {
        IEnumerable<Appreciation> getAppreciationsFor(string chauffeurId);
        Appreciation getAppreciation(string chauffeurId);
        Appreciation GetAppreciationById(string trajetId);
        IEnumerable<Appreciation> GetAllAppreciation();
        IEnumerable<Appreciation> GetAppreciationsFor(string chauffeurId);
        void CreateAppreciation(Appreciation appreciation);
        void DeleteAppreciation(string id);
        void UpdateAppreciation(Appreciation trajet);



    }
}
