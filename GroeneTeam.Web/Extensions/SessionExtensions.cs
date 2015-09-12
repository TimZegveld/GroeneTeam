using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using JemId.Basis.BLL;

namespace GroeneTeam.Web.Extensions
{
    public static class SessionExtensions
    {
        #region Geef

        public static Gebruiker GeefGebruiker(this HttpSessionState session) { return new HttpSessionStateWrapper(session).GeefGebruiker(); }
        public static Gebruiker GeefGebruiker(this HttpSessionStateBase session) { return session.GeefBllObject(i => new Gebruiker(i)); }

        /// <summary>Haalt het betreffende bll object op</summary>
        public static TBll GeefBllObject<TBll>(this HttpSessionStateBase session, Func<int, TBll> creator)
            where TBll : class, IBusinessLogica
        {
            string sessionKey = SessionKey<TBll>();
            if (session[sessionKey] == null)
                return null;

            int id = (int)session[sessionKey];

            if (id == 0)
                return null;

            return creator(id);
        }

        #endregion Geef

        #region Zet

        public static void ZetGebruiker(this HttpSessionState session, Gebruiker gebruiker) { new HttpSessionStateWrapper(session).ZetGebruiker(gebruiker); }
        public static void ZetGebruiker(this HttpSessionStateBase session, Gebruiker gebruiker) { session.ZetBllObject(gebruiker); }

        public static void ZetBllObject<TBll>(this HttpSessionStateBase session, TBll bllObject)
            where TBll : IBusinessLogica
        {
            string sessionKey = SessionKey<TBll>();
            session[sessionKey] = bllObject.IdOr0();
        }

        private static string SessionKey<TBll>() where TBll : IBusinessLogica
        {
            return typeof(TBll).Name + "ID";
        }

        #endregion Zet
    }
}
