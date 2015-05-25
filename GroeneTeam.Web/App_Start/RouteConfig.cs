using JemId.Basis.Mvc4.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GroeneTeam.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            JemRouting.JemRegisterRoutes("Site", "Index").ToList().ForEach(r => routes.Add(r));
        }
    }
}