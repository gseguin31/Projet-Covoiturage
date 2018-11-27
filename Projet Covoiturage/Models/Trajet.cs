using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.Models
{
    public class Trajet
    {
        public int Id { get; set; }
        public string VilleDepart { get; set; }
        public string VilleDestination { get; set; }
        public DateTime DateDepart { get; set; }
        public DateTime HeureArrivee { get; set; }
        public virtual List<Reservation>  Reservations {get; set;}
        public virtual List<Appreciation> Appreciations { get; set; }    
        public virtual Chauffeur Chauffeur { get; set; }
    }
}