using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VR.Startup))]
namespace VR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
