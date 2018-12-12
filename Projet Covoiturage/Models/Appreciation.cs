using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Projet_Covoiturage.Models
{
    public class Appreciation
    {
        public string Id{ get; set; }
        [Display(Name = "Commentary", ResourceType = typeof(Ressources.langue))]
        public string Commentaire { get; set; }
        [Display(Name = "Ponctuality", ResourceType = typeof(Ressources.langue))]
        public int Ponctualite { get; set; }
        [Display(Name = "Security", ResourceType = typeof(Ressources.langue))]
        public int Securite { get; set; }
        [Display(Name = "Viability", ResourceType = typeof(Ressources.langue))]
        public int Fiabilite { get; set; }
        [Display(Name = "Confort", ResourceType = typeof(Ressources.langue))]
        public int Confort { get; set; }
        [Display(Name = "Courtesy", ResourceType = typeof(Ressources.langue))]
        public int Courtoisie { get; set; }

        // public virtual ApplicationUser User { get; set; }
        
        public virtual Trajet Trajet { get; set; }
        const int MAX_REVIEW = 5;

    }
}