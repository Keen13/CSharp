using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SearchMovies.Startup))]
namespace SearchMovies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
