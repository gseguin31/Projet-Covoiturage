using Projet_Covoiturage.DAL.Services;
using Projet_Covoiturage.DAL.Services.Interface;
using Projet_Covoiturage.DAL.UnitOfWork;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace Projet_Covoiturage
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IServiceChauffeur, ServiceChauffeur>();
            container.RegisterType<IServiceClient, ServiceClient>();
            container.RegisterType<IServiceTrajet, IServiceTrajet>();
        }
    }
}