using System.Collections.Generic;
using JemId.Basis.BLL;
using JemId.Basis.DAL;

namespace GroeneTeam.BLL
{
    internal static class RondeLocatie
    {
        internal static void Toevoegen(Ronde ronde, Locatie locatie)
        {
            var dalObj = DALManager.Get<DAL.RondeLocatie>(GetWhere(ronde, locatie));

            if (dalObj.RondeLocatieID != 0)
                return;

            dalObj.RondeID = ronde.ID;
            dalObj.LocatieID = locatie.ID;
            dalObj.Save();
        }

        internal static void Verwijderen(Ronde ronde, Locatie locatie)
        {
            var dalObj = DALManager.Get<DAL.RondeLocatie>(GetWhere(ronde, locatie));

            if (dalObj.RondeLocatieID > 0)
                dalObj.Delete();
        }

        internal static void Verwijderen(Ronde ronde)
        {
            var dalObjecten = DALManager.GetCollection<DAL.RondeLocatie>(DALFuncties.Format("RondeID = {0}", ronde.ID));

            foreach (var dalObj in dalObjecten)
                if (dalObj.RondeLocatieID > 0)
                    dalObj.Delete();
        }

        private static string GetWhere(Ronde ronde, Locatie locatie)
        {
            return DALFuncties.Format("RondeID = {0} AND LocatieID = {1}", ronde.ID, locatie.ID);
        }

        internal static List<Locatie> GeefLijst(Ronde ronde)
        {
            string where = string.Format("LocatieID IN (SELECT LocatieID FROM RondeLocatie WHERE RondeID = {0})", ronde.ID);
            return Locatie.GeefLijst(where);
        }
    }
}