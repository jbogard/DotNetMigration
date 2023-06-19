using ContosoUniversity;
using ContosoUniversity.DependencyResolution;
using Hangfire;
using Hangfire.StructureMap;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace ContosoUniversity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

            GlobalConfiguration.Configuration
                .UseSqlServerStorage("SchoolContext")
                .UseStructureMapActivator(IoC.Container)
                //.UseIgnoredAssemblyVersionTypeResolver()
                ;


            app.UseHangfireDashboard();
            app.UseHangfireServer();

            ConfigureAuth(app);
        }
    }
}