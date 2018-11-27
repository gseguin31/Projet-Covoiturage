using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Covoiturage.DAL.Services.interfa
{
        interface IServiceTrajet
    {
        List<Trajet> Filtre(string depar, string arriver);

        void Reserver(ApplicationUser client, int trajetId);

        void AnnuleReserver(ApplicationUser client, int trajetId);

        void CreateTrajet(ApplicationUser chaufeur, Trajet courrent);

        Trajet GetTrajet(int id);
    }
}
