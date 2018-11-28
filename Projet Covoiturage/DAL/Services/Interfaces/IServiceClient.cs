using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Covoiturage.DAL.Services.Interfaces
{
    public interface IServiceClient
    {
        Client GetClientById(string clientId);

    }
}