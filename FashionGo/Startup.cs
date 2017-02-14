using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FashionGo.Startup))]
namespace FashionGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
