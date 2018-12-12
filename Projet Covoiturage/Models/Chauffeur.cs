using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.Models
{
    public class Chauffeur 
    {
        public string Id { get; set; }
        [Display(Name = "LicenseDate", ResourceType = typeof(Ressources.langue))]
        public DateTime DatePermis { get; set; }
        [Display(Name = "HireDate", ResourceType = typeof(Ressources.langue))]
        public DateTime DateEmbauche { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        public virtual List<Trajet> Trajets { get; set; }
    }
}