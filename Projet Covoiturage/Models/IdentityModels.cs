using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Projet_Covoiturage.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
        [Display(Name = "LastName", ResourceType = typeof(Ressources.langue))]
        public string Nom { get; set; }
        [Display(Name = "FirstName", ResourceType = typeof(Ressources.langue))]
        public string Prenom { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Ressources.langue))]
        public string Courriel { get; set; }
        [Display(Name = "Telephone", ResourceType = typeof(Ressources.langue))]
        public string Telephone { get; set; }
        [Display(Name = "Town", ResourceType = typeof(Ressources.langue))]
        public string Ville { get; set; }
        [Display(Name = "Age", ResourceType = typeof(Ressources.langue))]
        public int Age { get; set; }
        public virtual Chauffeur Chauffeur { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Trajet> Trajets { get; set; }
        public virtual DbSet<Vehicule> Vehicules { get; set; }
        public virtual DbSet<Chauffeur> Chauffeurs { get; set; }
        public virtual DbSet<Appreciation> Appreciations { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
    }
}