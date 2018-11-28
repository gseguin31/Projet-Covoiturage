using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.Models
{
    public class Vehicule
    {
        public string Id { get; set; }
        public string Modele { get; set; }
        public DateTime DateMiseEnRoute { get; set; }
        public int NombrePlace{ get; set; }

    }
}