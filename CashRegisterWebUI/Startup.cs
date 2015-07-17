using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CashRegisterWebUI.Startup))]
namespace CashRegisterWebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
