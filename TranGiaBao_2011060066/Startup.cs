using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TranGiaBao_2011060066.Startup))]
namespace TranGiaBao_2011060066
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
