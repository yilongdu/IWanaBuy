using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IwanaBuy.Startup))]
namespace IwanaBuy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
