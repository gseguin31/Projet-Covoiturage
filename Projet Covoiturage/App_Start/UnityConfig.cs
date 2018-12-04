using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Projet_Covoiturage.Controllers;
using Projet_Covoiturage.DAL.Services;
using Projet_Covoiturage.DAL.Services.Interface;
using Projet_Covoiturage.DAL.UnitOfWork;
using Projet_Covoiturage.Models;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;

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
            container.RegisterType<IServiceTrajet, ServiceTrajet>();
            container.RegisterType<IServiceReservation, ServiceReservation>();
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            //container.RegisterType<UserManager<ApplicationUser>>();
            //container.RegisterType<IdentityDbContext<ApplicationUser>, ApplicationDbContext>();
            //container.RegisterType<ApplicationUserManager>();
            //container.RegisterType<AccountController>(new InjectionConstructor());

            container.RegisterType<IdentityDbContext<ApplicationUser>, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}