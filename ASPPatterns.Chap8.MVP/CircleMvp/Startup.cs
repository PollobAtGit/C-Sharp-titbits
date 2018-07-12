using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CircleMvp.Startup))]
namespace CircleMvp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
