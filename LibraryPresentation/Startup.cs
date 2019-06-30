using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library.Presentation.Startup))]
namespace Library.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
