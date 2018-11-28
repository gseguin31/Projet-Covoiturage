using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.Models
{
    public class Appreciation
    {
        public string Id{ get; set; }
        public string Commentaire { get; set; }
        public int Ponctualite { get; set; }
        public int Securite { get; set; }
        public int Fiabilite { get; set; }
        public int Confort { get; set; }
        public int Courtoisie { get; set; }

        // public virtual ApplicationUser User { get; set; }
        
        public virtual Trajet Trajet { get; set; }
        const int MAX_REVIEW = 5;

    }
}