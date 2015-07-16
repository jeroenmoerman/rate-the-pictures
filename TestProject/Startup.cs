using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Testproject.Startup))]
namespace Testproject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
