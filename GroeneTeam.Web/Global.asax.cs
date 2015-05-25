using System.Web.Mvc;
using System.Web.Routing;
using JemId.Basis.Mvc4.Web;

namespace GroeneTeam.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : JemHttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            JemApplication_Start();

            //new Cargoboss.Website.BLL.Updater().Update();
            //new JemId.RelatieBeheer.BLL.Updater().Update();
        }
    }

}