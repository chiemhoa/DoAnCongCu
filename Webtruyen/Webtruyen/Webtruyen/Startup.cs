using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Webtruyen.Startup))]
namespace Webtruyen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
