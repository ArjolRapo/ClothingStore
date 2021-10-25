using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreClothing2.Startup))]
namespace StoreClothing2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
