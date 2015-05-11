using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Guido.Startup))]
namespace Guido
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);//hraste whyyy
        }
    }
}
