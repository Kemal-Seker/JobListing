using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobListing.UI.Startup))]
namespace JobListing.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
