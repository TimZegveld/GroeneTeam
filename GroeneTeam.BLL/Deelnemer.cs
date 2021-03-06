﻿using System;
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

        private static Deelnemer _currentDeelnemer;
        private List<Evenement> _evenementen;

        #region Constructors

        public Deelnemer()
            : this(new DAL.Deelnemer())
        { }

        public Deelnemer(int id)
            : base(JemId.Basis.DAL.DALManager.Get<DAL.Deelnemer>(id))
        { }

        public Deelnemer(DAL.Deelnemer dalObj)
            : base(dalObj)
        { }

        #endregion

        #region Properties

        protected DAL.Deelnemer GroeneTeamDalObj { get { return (DAL.Deelnemer)_dalObj; } }

        public new static Deelnemer Current
        {
            get
            {
                if (_currentDeelnemer != null)
                    return _currentDeelnemer;

                if (Gebruiker.Current.IsNull())
                    return null;

                return _currentDeelnemer = new Deelnemer(Gebruiker.Current.ID);
            }
        }

        public List<Evenement> Evenementen
        {
            get
            {
                if (_evenementen == null)
                    _evenementen = EvenementDeelnemer.GeefLijst(this);
                return _evenementen;
            }
        }

        public bool MagHosten
        {
            get { return GroeneTeamDalObj.MagHosten; }
            set { GroeneTeamDalObj.MagHosten = value; }
        }

        #endregion

        #region Statics

        public static List<Deelnemer> GeefLijst(Evenement evenement)
        { return GeefLijst(""); }

        public new static List<Deelnemer> GeefLijst()
        { return GeefLijst(string.Empty, string.Empty, 0); }

        public new static List<Deelnemer> GeefLijst(string where)
        { return GeefLijst(where, string.Empty, 0); }

        private static List<Deelnemer> GeefLijst(string where, string orderBy, int aantal)
        {
            return JemId.Basis.DAL.DALManager.GetCollection<DAL.Deelnemer>(where, orderBy, aantal)
                .ConvertAll(dalObj => new Deelnemer(dalObj));
        }

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
