using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Covoiturage.DAL.Services.Interface
{
    public interface IServiceReservation
    {
        Reservation GetReservation(string reservationId);
        IEnumerable<Reservation> GetAllReservations();
        IEnumerable<Reservation> GetReservationsFor(string clientId);
        void CreateReservation(Reservation reservation);
        void DeleteReservation(string reservationId);
        void UpdateReservation(Reservation reservation);
    }
}
