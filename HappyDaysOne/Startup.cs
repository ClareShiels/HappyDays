using Microsoft.Owin;
using Owin;
 

[assembly: OwinStartupAttribute(typeof(HappyDaysOne.Startup))]
namespace HappyDaysOne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

       
    }
}
