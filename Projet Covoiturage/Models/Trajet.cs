using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.Models
{
    public class Trajet
    {
        public string Id { get; set; }
        [Display(Name = "StartTown", ResourceType = typeof(Ressources.langue))]
        public string VilleDepart { get; set; }
        [Display(Name = "ArrivalTown", ResourceType = typeof(Ressources.langue))]
        public string VilleDestination { get; set; }
        [Display(Name = "Distance", ResourceType = typeof(Ressources.langue))]
        public int Distance { get; set; }
        [Display(Name = "StartDate", ResourceType = typeof(Ressources.langue))]
        public DateTime DateDepart { get; set; }
        [Display(Name = "ArrivalTime", ResourceType = typeof(Ressources.langue))]
        public DateTime HeureArrivee { get; set; }
        public int NombreDePlaceDuVehicule { get; set; }
        public virtual List<Reservation>  Reservations {get; set;}
        public virtual List<Appreciation> Appreciations { get; set; }    
        public virtual Chauffeur Chauffeur { get; set; }
    }
}