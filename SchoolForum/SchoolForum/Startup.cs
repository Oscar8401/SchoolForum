using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolForum.Startup))]
namespace SchoolForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
