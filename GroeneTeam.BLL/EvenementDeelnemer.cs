using System.Collections.Generic;
using JemId.Basis.DAL;

namespace GroeneTeam.BLL
{
    internal static class EvenementDeelnemer
    {
        internal static void Toevoegen(Evenement evenement, Deelnemer deelnemer)
        {
            var dalObj = DALManager.Get<DAL.EvenementDeelnemer>(GetWhere(evenement, deelnemer));

            if (dalObj.EvenementDeelnemerID != 0)
                return;

            dalObj.EvenementID = evenement.ID;
            dalObj.DeelnemerID = deelnemer.ID;
            dalObj.Save();
        }

        internal static void Verwijderen(Evenement evenement, Deelnemer deelnemer)
        {
            var dalObj = DALManager.Get<DAL.EvenementDeelnemer>(GetWhere(evenement, deelnemer));

            if (dalObj.EvenementDeelnemerID > 0)
                dalObj.Delete();
        }

        private static string GetWhere(Evenement evenement, Deelnemer deelnemer)
        {
            return string.Format("EvenementID = {0} AND DeelnemerID = {1}", evenement.ID, deelnemer.ID);
        }

        internal static List<Deelnemer> GeefLijst(Evenement evenement)
        {
            string where = string.Format("DeelnemerID IN (SELECT DeelnemerID FROM EvenementDeelnemer WHERE EvenementID = {0})", evenement.ID);
            return Deelnemer.GeefLijst(where);
        }
    }
}
