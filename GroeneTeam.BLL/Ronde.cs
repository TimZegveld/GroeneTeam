using System;
using System.Collections.Generic;
using JemId.Basis.BLL;

namespace GroeneTeam.BLL
{
    public class Ronde : BusinessLogica
    {
        protected override string BllTypeNaamMeervoud { get { return "Rondes"; } }

        internal DAL.Ronde _dalObj;

        private Evenement _evenement;

        private List<Locatie> _locaties;

        #region Constructors

        public Ronde(int id)
        {
            _dalObj = JemId.Basis.DAL.DALManager.Get<DAL.Ronde>(id);
        }

        internal Ronde(DAL.Ronde dalObj)
        {
            _dalObj = dalObj;
        }

        public Ronde(Evenement evenement)
        {
            _dalObj = new DAL.Ronde();

            Evenement = evenement;
        }

        #endregion

        #region Properties

        public override int ID { get { return _dalObj.RondeID; } }

        public int Volgorde
        {
            get { return _dalObj.Volgorde; }
            private set { _dalObj.Volgorde = value; }
        }

        public int DoorlooptijdInMinuten
        {
            get { return _dalObj.DoorlooptijdInMinuten; }
            private set { _dalObj.DoorlooptijdInMinuten = value; }
        }

        public Evenement Evenement
        {
            get { return GeefEnCache(id => new Evenement(id), ref _evenement, _dalObj.EvenementID); }
            private set { _dalObj.EvenementID = (_evenement = value).IdOr0(); }
        }

        public List<Locatie> Locaties
        {
            get
            {
                if (_locaties == null)
                {
                    _locaties = ObjectProvider.GetChildren<Locatie>(this);

                    if (_locaties == null)
                    {
                        _locaties = Locatie.GeefLijst(this);
                        ObjectProvider.PreLoad<Locatie>(_locaties);
                    }
                }
                return _locaties;
            }
        }

        #endregion

        #region Statics

        public static List<Ronde> GeefLijst(Evenement evenement)
        {
            if (evenement.IsNull())
                return new List<Ronde>();

            return GeefLijst(string.Format("EvenementID = {0}", evenement.ID), string.Empty, 0);
        }

        private static List<Ronde> GeefLijst(string where, string orderBy, int aantal)
        {
            return JemId.Basis.DAL.DALManager.GetCollection<DAL.Ronde>(where, orderBy, aantal)
                .ConvertAll(dalObj => new Ronde(dalObj));
        }

        public static Dictionary<int, List<Ronde>> GeefDictionary(Type parentType, string where)
        {
            var dalObjList = JemId.Basis.DAL.DALManager.GetCollection<DAL.Ronde>(where);
            var retVal = new Dictionary<int, List<Ronde>>();

            foreach (var dalObj in dalObjList)
            {
                if (parentType == typeof(Evenement))
                {
                    if (!retVal.ContainsKey(dalObj.EvenementID))
                        retVal.Add(dalObj.EvenementID, new List<Ronde>());

                    retVal[dalObj.EvenementID].Add(new Ronde(dalObj));
                }
            };

            return retVal;
        }

        #endregion

        #region Methods

        public void Opslaan(int doorlooptijdInMinuten)
        {
            string defaultErrMsg = string.Format("Fout bij opslaan {0}: {1}", (BusinessLogica)this, Environment.NewLine);
            BLLFuncties.ValidateNotNull(Evenement, "Evenement", defaultErrMsg);

            DoorlooptijdInMinuten = doorlooptijdInMinuten;
            Volgorde = Evenement.Rondes.Count + 1;

            _dalObj.Save();
        }

        public void Verwijderen() { _dalObj.Delete(); }

        public void ZetVolgorder(int volgorde)
        {
            if (Volgorde == volgorde) return;

            Volgorde = volgorde;
            _dalObj.Save();
        }

        #endregion
    }
}
