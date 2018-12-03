using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.Models
{
    public class ChauffeurInfoViewModel
    {
        public Vehicule Vehicule;
        public List<Trajet> Trajets;
        public Double Ponctualite;
        public Double Securite;
        public Double Fiabilite;
        public Double Confort;
        public Double Courtoisie;
    }
}