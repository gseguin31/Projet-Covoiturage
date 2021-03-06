﻿using Projet_Covoiturage.DAL.Services.Interface;
using Projet_Covoiturage.DAL.UnitOfWork;
using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.DAL.Services
{
    public class ServiceClient : IServiceClient
    {
        private IUnitOfWork uow;
        public ServiceClient(IUnitOfWork uw)
        {
            uow = uw;
        }

        public ApplicationUser GetClient(string clientId)
        {
            return uow.ClientRepository.GetByID(clientId);
        }
    }
}