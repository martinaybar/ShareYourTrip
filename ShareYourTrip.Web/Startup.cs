using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShareYourTrip.Web.Startup))]
namespace ShareYourTrip.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
