using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmpresaNavidadORM.Startup))]
namespace EmpresaNavidadORM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
