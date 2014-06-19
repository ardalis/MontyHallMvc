using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MontyHall.Startup))]
namespace MontyHall
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
