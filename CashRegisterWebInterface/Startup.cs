using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CashRegisterWebInterface.Startup))]
namespace CashRegisterWebInterface
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
