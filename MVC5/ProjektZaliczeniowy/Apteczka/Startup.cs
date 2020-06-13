using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Apteczka.Startup))]
namespace Apteczka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
