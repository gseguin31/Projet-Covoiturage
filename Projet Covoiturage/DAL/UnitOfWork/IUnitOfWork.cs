using Projet_Covoiturage.DAL.Repository;
using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Covoiturage.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Chauffeur> ChauffeurRepository { get; }
        GenericRepository<Client> ClientRepository { get; }
        GenericRepository<Trajet> TrajetRepository { get; }
        GenericRepository<Appreciation> AppreciationRepository { get; }
        GenericRepository<Reservation> ReservationRepository { get; }
        void Save();
        //void Dispose();
        //void Dispose(bool disposing);
    }
}
