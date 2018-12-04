using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.Models
{
    public class Chauffeur 
    {
        public string Id { get; set; }
        public DateTime DatePermis { get; set; }
        public DateTime DateEmbauche { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        public virtual List<Trajet> Trajets { get; set; }
    }
}