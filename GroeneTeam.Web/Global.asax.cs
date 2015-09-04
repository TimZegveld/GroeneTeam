using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GroeneTeam.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            JemId.Basis.BLL.AutoDbUpdater.UpdateDatabaseTables("JemId.Basis.DAL", "GroeneTeam.DAL");
        }
    }
}
