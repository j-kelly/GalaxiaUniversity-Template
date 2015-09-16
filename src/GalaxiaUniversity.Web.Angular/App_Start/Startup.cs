using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GalaxiaUniversity.Web.Angular.Startup))]

namespace GalaxiaUniversity.Web.Angular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            UnityConfig.RegisterComponents();
        }
    }
}
