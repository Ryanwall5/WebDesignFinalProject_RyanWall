using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WedDesign_Final_RyanWall.Startup))]
namespace WedDesign_Final_RyanWall
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
