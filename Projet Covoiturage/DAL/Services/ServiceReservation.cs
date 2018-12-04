using Projet_Covoiturage.DAL.Services.Interface;
using Projet_Covoiturage.DAL.UnitOfWork;
using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.DAL.Services
{
    public class ServiceReservation : IServiceReservation
    {

        private IUnitOfWork uow;

        public ServiceReservation(IUnitOfWork uw)
        {
            uow = uw;
        }

        public void CreateReservation(Reservation reservation)
        {
            uow.ReservationRepository.Insert(reservation);
        }

        public void DeleteReservation(string reservationid)
        {
            uow.ReservationRepository.Delete(reservationid);
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return uow.ReservationRepository.Get();
        }

        public Reservation GetReservation(string reservationId)
        {
            return uow.ReservationRepository.GetByID(reservationId);
        }

        public IEnumerable<Reservation> GetReservationsFor(string clientId)
        {
            return uow.ReservationRepository.Get().Where(x => x.ClientId == clientId).ToList();
        }

        public void UpdateReservation(Reservation reservation)
        {
            uow.ReservationRepository.Update(reservation);
        }
        public void AnnulerReservation(Reservation reservation)
        {
            uow.ReservationRepository.dbSet.Remove(reservation);
        }
    }
}