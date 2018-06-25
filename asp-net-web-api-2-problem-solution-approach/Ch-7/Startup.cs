using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Ch_7.Startup))]

namespace Ch_7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
