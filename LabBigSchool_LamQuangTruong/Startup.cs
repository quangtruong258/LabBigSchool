using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LabBigSchool_LamQuangTruong.Startup))]
namespace LabBigSchool_LamQuangTruong
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
