using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DongHo.Startup))]
namespace DongHo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
