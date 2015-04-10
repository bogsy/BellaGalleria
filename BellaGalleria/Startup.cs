using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BellaGalleria.Startup))]
namespace BellaGalleria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
