using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewBlogPlatform.Startup))]
namespace NewBlogPlatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
