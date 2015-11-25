using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiguelDesafioTecnico.Startup))]
namespace MiguelDesafioTecnico
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
