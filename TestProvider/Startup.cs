using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestProvider.Startup))]
namespace TestProvider
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
