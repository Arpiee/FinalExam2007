using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(comp2007w2018finalB.Startup))]
namespace comp2007w2018finalB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
