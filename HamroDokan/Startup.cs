using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HamroDokan.Startup))]
namespace HamroDokan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
