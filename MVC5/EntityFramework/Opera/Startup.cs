using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Opera.Startup))]
namespace Opera
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
