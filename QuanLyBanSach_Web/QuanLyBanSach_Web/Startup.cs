using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyBanSach_Web.Startup))]
namespace QuanLyBanSach_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
