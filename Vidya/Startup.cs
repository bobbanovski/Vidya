using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidya.Startup))]
namespace Vidya
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
