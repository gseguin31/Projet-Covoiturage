using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projet_Covoiturage.Startup))]
namespace Projet_Covoiturage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
