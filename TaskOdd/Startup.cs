using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskOdd.Startup))]
namespace TaskOdd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
