﻿using System.Web;
using System.Web.Mvc;

namespace Projet_Covoiturage
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
