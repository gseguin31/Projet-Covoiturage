using Projet_Covoiturage.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.DAL.Services
{
    public class ServiceTrajet
    {
        private IUnitOfWork uow;

        public ServiceTrajet(IUnitOfWork uw)
        {
            uow = uw;
        }
    }
}