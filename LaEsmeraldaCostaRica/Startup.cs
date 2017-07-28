using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaEsmeraldaCostaRica.Startup))]
namespace LaEsmeraldaCostaRica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
