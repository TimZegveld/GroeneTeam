using System.Web.Http;
using JemId.Basis.BLL;

namespace GroeneTeam.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UpdateDatabase();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private static void UpdateDatabase()
        {
            AutoDbUpdater.UpdateDatabaseTables("JemId.Basis.DAL", "GroeneTeam.DAL");
            new JemId.Basis.BLL.Updater().Update();
        }
    }
}
