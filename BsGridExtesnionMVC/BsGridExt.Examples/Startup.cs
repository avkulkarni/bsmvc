using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BsGridExt.Examples.Startup))]
namespace BsGridExt.Examples
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
