using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyHoSoCongChung.Startup))]
namespace QuanLyHoSoCongChung
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
