﻿using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Covoiturage.DAL.Repository
{
    interface IClientRepository : IDisposable
    {
        ApplicationUser GetClientById(string clientId);
        void Save();
    }
}
