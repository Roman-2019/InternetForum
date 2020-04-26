using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternetForum.Startup))]
namespace InternetForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
