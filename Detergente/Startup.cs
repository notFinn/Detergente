using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Detergente.Startup))]
namespace Detergente
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
