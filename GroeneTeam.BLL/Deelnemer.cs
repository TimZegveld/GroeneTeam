using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JemId.Basis.BLL;
using JemId.Basis.BLL.StamGegevens;

namespace GroeneTeam.BLL
{
    public class Deelnemer : Gebruiker
    {
        protected override string BllTypeNaamMeervoud { get { return "Deelnemers"; } }

        #region Constructors

        public Deelnemer()
            : this(new DAL.Deelnemer()) { }

        public Deelnemer(int id)
            : base(JemId.Basis.DAL.DALManager.Get<DAL.Deelnemer>(id)) { }

        public Deelnemer(DAL.Deelnemer dalObj)
            : base(dalObj) { }

        #endregion

        #region Properties

        protected DAL.Deelnemer GroeneTeamDalObj
        {
            get { return (DAL.Deelnemer)GroeneTeamDalObj; }
        }

        public bool MagHosten
        {
            get { return GroeneTeamDalObj.MagHosten; }
            set { GroeneTeamDalObj.MagHosten = value; }
        }

        #endregion

        #region Statics

        public static Deelnemer Registreren(string naam, string email, string wachtwoord)
        {
            if (Gebruiker.Bestaat(email))
                throw new BusinessRuleException("Er bestaat al een account voor '{0}'.", email);

            var deelnemer = new Deelnemer();

            deelnemer.Code = deelnemer.GeefVerwachtID().ToString();
            deelnemer.Naam = naam;
            deelnemer.EmailAdres = email;
            deelnemer.MagHosten = false;

            deelnemer.Bedrijven.Add(new Bedrijf(1));
            deelnemer.Opslaan(email, wachtwoord, naam, email);

            return deelnemer;
        }

        private void ZetMagHosten(bool magHosten)
        {
            if (GroeneTeamDalObj.MagHosten == magHosten) return;

            GroeneTeamDalObj.MagHosten = magHosten;
            GroeneTeamDalObj.Save();
        }

        #endregion
    }
}
