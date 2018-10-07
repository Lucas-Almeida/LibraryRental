using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryRental.Startup))]
namespace LibraryRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
