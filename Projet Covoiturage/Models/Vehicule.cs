using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.Models
{
    public class Vehicule
    {
        public string Id { get; set; }
        [Display(Name = "Model", ResourceType = typeof(Ressources.langue))]
        public string Modele { get; set; }
        [Display(Name = "RoadDate", ResourceType = typeof(Ressources.langue))]
        public DateTime DateMiseEnRoute { get; set; }
        [Display(Name = "Places", ResourceType = typeof(Ressources.langue))]
        public int NombrePlace{ get; set; }

    }
}