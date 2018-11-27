using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Projet_Covoiturage.Models;
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
            user2.Email = "Client@Client.Client";
            user2.UserName = "Client@Client.Client";
            string userPWD2 = "Password1!";
            var result2 = await UserManager.CreateAsync(user2, userPWD2);

            if (result2.Succeeded)
            {
                var result1 = UserManager.AddToRole(user2.Id, "Client");

            }
        }
    }
}
