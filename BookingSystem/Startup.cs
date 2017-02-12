using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookingSystem.Startup))]
namespace BookingSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
