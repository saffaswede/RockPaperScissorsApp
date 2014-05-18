using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RockPaperScissorsWebApp.Startup))]
namespace RockPaperScissorsWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
