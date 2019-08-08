using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkatersTricks.Startup))]
namespace SkatersTricks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
