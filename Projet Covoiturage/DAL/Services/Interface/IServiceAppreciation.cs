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
        IEnumerable<Appreciation> GetAppreciationsFor(string chauffeurId);
        Appreciation GetAppreciation(string appreciationId);
        IEnumerable<Appreciation> GetAllAppreciations();
        void CreateAppreciation(Appreciation appreciation);
        void DeleteAppreciation(string id);
        void UpdateAppreciation(Appreciation appreciation);



    }
}
