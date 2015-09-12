using System;
using System.Web;
using System.Web.Mvc;
using JemId.Basis.BLL;
using JemId.Basis.BLL.StamGegevens;
using GroeneTeam.Web.Extensions;

namespace GroeneTeam.Web.Attributes

{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute()
        { }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Gebruiker gebruiker = null;

            if (httpContext.Session == null)
                return false;

            gebruiker = httpContext.Session.GeefGebruiker();
            if (gebruiker != null)
            {
                gebruiker.Inloggen(gebruiker.GeefWachtwoord());
                HttpContext.Current.User = Principal.Current;
            }

            // Sessie bestaat niet of gebruiker is niet juist ingelogd
            if (gebruiker == null)
                return false;

            return true;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                // Als de gebruiker niet gerechtigd is de content te bekijken, naar inlogpagina verwijzen
                string returnPathStr = filterContext.HttpContext.Request.Url.PathAndQuery.Replace("&", "[AND]");
                filterContext.Result = new RedirectResult("/Account/Inloggen");
            }
        }
    }
}