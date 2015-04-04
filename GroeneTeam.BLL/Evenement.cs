using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JemId.Basis.BLL;

namespace GroeneTeam.BLL
{
    public class Evenement : BusinessLogica
    {
        private DAL.Evenement _dalObj;

        private Deelnemer _deelnemer;

        private List<Ronde> _rondes;

        #region Constructors

        public Evenement(int id)
        {
            _dalObj = JemId.Basis.DAL.DALManager.Get<DAL.Evenement>(id);
        }

        protected internal Evenement(DAL.Evenement dalObj)
        {
            _dalObj = dalObj;
        }

        public Evenement(Deelnemer deelnemer)
        {
            _dalObj = new DAL.Evenement();

            Deelnemer = deelnemer;
        }

        #endregion

        #region Properties

        public override int ID { get { return _dalObj.EvenementID; } }

        public string Naam
        {
            get { return _dalObj.Naam; }
            private set { _dalObj.Naam = value; }
        }

        public string Omschrijving
        {
            get { return _dalObj.Omschrijving; }
            private set { _dalObj.Omschrijving = value; }
        }

        public DateTime StartTijd
        {
            get { return _dalObj.StartTijd; }
            private set { _dalObj.StartTijd = value; }
        }

        public DateTime EindTijd
        {
            get { return _dalObj.EindTijd; }
            private set { _dalObj.EindTijd = value; }
        }

        public bool IsOpenbaar
        {
            get { return _dalObj.IsOpenbaar; }
            private set { _dalObj.IsOpenbaar = value; }
        }

        public bool MagUitnodigen
        {
            get { return _dalObj.MagUitnodigen; }
            private set { _dalObj.MagUitnodigen = value; }
        }

        //Welke deelnemer is de host van het event
        public Deelnemer Deelnemer
        {
            get { return GeefEnCache(id => new Deelnemer(id), ref _deelnemer, _dalObj.DeelnemerID); }
            private set { _dalObj.DeelnemerID = (_deelnemer = value).IdOr0(); }
        }

        public List<Ronde> Rondes
        {
            get
            {
                if (_rondes == null)
                {
                    _rondes = ObjectProvider.GetChildren<Ronde>(this);

                    if (_rondes == null)
                    {
                        _rondes = Ronde.GeefLijst(this);
                        ObjectProvider.PreLoad<Ronde>(_rondes);
                    }
                }
                return _rondes;
            }
        }

        #endregion

        #region Statics

        public static List<Evenement> GeefLijst(string where)
        {
            return GeefLijst(where, string.Empty, 0);
        }

        private static List<Evenement> GeefLijst(string where, string orderBy, int aantal)
        {
            return JemId.Basis.DAL.DALManager.GetCollection<DAL.Evenement>(where, orderBy, aantal)
                .ConvertAll(dalObj => new Evenement(dalObj));
        }

        #endregion

        #region Methods

        public void Opslaan(string naam, string omschrijving, DateTime startTijd, DateTime eindTijd, bool isOpenbaar, bool magUitnodigen)
        {
            string defaultErrMsg = string.Format("Fout bij opslaan {0}: {1}", (BusinessLogica)this, Environment.NewLine);
            BLLFuncties.ValidateNotNull(Deelnemer, "Deelnemer", defaultErrMsg);

            Naam = naam;
            Omschrijving = omschrijving;

            StartTijd = startTijd;
            EindTijd = eindTijd;

            IsOpenbaar = isOpenbaar;
            MagUitnodigen = magUitnodigen;

            _dalObj.Save();
        }

        public void Verwijderen() { _dalObj.Delete(); }

        public void ZetToegankelijkheid(bool isOpenbaar)
        {
            if (IsOpenbaar == isOpenbaar) return;

            IsOpenbaar = isOpenbaar;
            _dalObj.Save();
        }

        public void ZetMagUitnodigen(bool magUitnodigen)
        {
            if (MagUitnodigen == magUitnodigen) return;

            MagUitnodigen = magUitnodigen;
            _dalObj.Save();
        }

        #endregion
    }
}
