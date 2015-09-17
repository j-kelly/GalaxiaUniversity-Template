using GalaxiaUniversity.Core.Logging;
using Microsoft.Owin;
using Owin;
using Utility.Logging.NLog;

[assembly: OwinStartup(typeof(GalaxiaUniversity.Web.Angular.App_Start.Startup))]

namespace GalaxiaUniversity.Web.Angular.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            LogManager.SetFactory(new NLogLoggerFactory());

            UnityConfig.RegisterComponents();
        }
    }
}
