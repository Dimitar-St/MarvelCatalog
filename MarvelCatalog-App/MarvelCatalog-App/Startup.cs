using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarvelCatalog_App.Startup))]
namespace MarvelCatalog_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
