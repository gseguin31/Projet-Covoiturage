using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Projet_Covoiturage.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(Projet_Covoiturage.Startup))]
namespace Projet_Covoiturage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Task t = CreateRoles();
        }

        public async Task CreateRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Chauffeur"))
            {

                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Chauffeur";
                roleManager.Create(role);
                

                var user = new ApplicationUser();
                user.UserName = "chauffeur@chauffeur.chauffeur";
                user.Email = "chauffeur@chauffeur.chauffeur";

                string userPWD = "Password1!";

                var result = await UserManager.CreateAsync(user, userPWD);

                //Add default User to Role Admin   
                if (result.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "chauffeur");

                }
            }

            // creating Creating Membre role    
            if (!roleManager.RoleExists("Client"))
            {
                var role = new IdentityRole();
                role.Name = "Client";
                roleManager.Create(role);

            }

            //Create basic user for test purposes
            var user2 = new ApplicationUser();
            user2.Email = "client@client.client";
            user2.UserName = "client@client.client";
            string userPWD2 = "Password1!";
            var result2 = await UserManager.CreateAsync(user2, userPWD2);

            if (result2.Succeeded)
            {
                var result1 = UserManager.AddToRole(user2.Id, "Client");

            }

            List<Trajet> list = new List<Trajet>();
            Trajet voyage = new Trajet {Id="0", VilleDepart = "tamere", VilleDestination = "ton autre mere", DateDepart = DateTime.Now, HeureArrivee = DateTime.Now.AddHours(24) };
            list.Add(voyage);
            Chauffeur bob = new Chauffeur {DateEmbauche= DateTime.Now.AddDays(-10),DatePermis= DateTime.Now.AddDays(-10),Id="0",Trajets=list };
            voyage.Chauffeur = bob;
            ApplicationUser bobQuiChauffe= UserManager.Find("chauffeur@chauffeur.chauffeur", "Password1!");
            bobQuiChauffe.Chauffeur = bob;
            UserManager.Update(bobQuiChauffe);
            context.Chauffeurs.Add(bob);
            voyage.Chauffeur = bob;
            context.Trajets.Add(voyage);
            context.SaveChanges();
        }
    }
}
