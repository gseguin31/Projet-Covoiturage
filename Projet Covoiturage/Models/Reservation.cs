using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.Models
{
    public class Reservation
    {
        [Key , Column(Order =1)]
        public string ClientId { get; set; }

        [Key, Column(Order = 2)]
        public string TrajetId { get; set; }
    }
}