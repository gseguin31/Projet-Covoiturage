using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.Models
{
    public class Client : ApplicationUser
    {
        public virtual List<Reservation> Reservations { get; set; }
    }
}