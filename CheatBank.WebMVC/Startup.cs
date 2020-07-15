using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheatBank.WebMVC.Startup))]
namespace CheatBank.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
