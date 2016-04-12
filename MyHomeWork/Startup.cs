using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyHomeWork.Startup))]
namespace MyHomeWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
