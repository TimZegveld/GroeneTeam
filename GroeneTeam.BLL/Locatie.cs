using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JemId.Basis;
using JemId.Basis.BLL;

namespace GroeneTeam.BLL
{
    public class Locatie : BusinessLogica
    {
        protected override string BllTypeNaamMeervoud { get { return "Locaties"; } }

        internal DAL.Locatie _dalObj;

        private Ronde _ronde;

        #region Constructors

        public Locatie(int id)
        {
            _dalObj = JemId.Basis.DAL.DALManager.Get<DAL.Locatie>(id);
        }

        internal Locatie(DAL.Locatie dalObj)
        {
            _dalObj = dalObj;
        }

        public Locatie(Ronde ronde)
        {
            _dalObj = new DAL.Locatie();

            Ronde = ronde;
        }

        #endregion

        #region Properties

        public override int ID { get { return _dalObj.LocatieID; } }

        public string Naam
        {
            get { return _dalObj.Naam; }
            private set { _dalObj.Naam = value; }
        }

        public string Adres
        {
            get { return _dalObj.Adres; }
            private set { _dalObj.Adres = value; }
        }

        public string Postcode
        {
            get { return _dalObj.Postcode; }
            private set { _dalObj.Postcode = value; }
        }

        public string Plaats
        {
            get { return _dalObj.Plaats; }
            private set { _dalObj.Plaats = value; }
        }

        public double Latitude
        {
            get { return _dalObj.Latitude; }
            private set { _dalObj.Latitude = value; }
        }

        public double Longitude
        {
            get { return _dalObj.Longitude; }
            private set { _dalObj.Longitude = value; }
        }

        public Ronde Ronde
        {
            get { return GeefEnCache(id => new Ronde(id), ref _ronde, _dalObj.RondeID); }
            private set { _dalObj.RondeID = (_ronde = value).IdOr0(); }
        }


        #endregion

        #region Statics

        public static List<Locatie> GeefLijst(Ronde ronde)
        {
            if (ronde.IsNull())
                return new List<Locatie>();

            return GeefLijst(string.Format("RondeID = {0}", ronde.ID), string.Empty, 0);
        }

        private static List<Locatie> GeefLijst(string where, string orderBy, int aantal)
        {
            return JemId.Basis.DAL.DALManager.GetCollection<DAL.Locatie>(where, orderBy, aantal)
                .ConvertAll(dalObj => new Locatie(dalObj));
        }

        public static Dictionary<int, List<Locatie>> GeefDictionary(Type parentType, string where)
        {
            var dalObjList = JemId.Basis.DAL.DALManager.GetCollection<DAL.Locatie>(where);
            var retVal = new Dictionary<int, List<Locatie>>();

            foreach (var dalObj in dalObjList)
            {
                if (parentType == typeof(Ronde))
                {
                    if (!retVal.ContainsKey(dalObj.RondeID))
                        retVal.Add(dalObj.RondeID, new List<Locatie>());

                    retVal[dalObj.RondeID].Add(new Locatie(dalObj));
                }
            };

            return retVal;
        }

        #endregion

        #region Methods

        public void Opslaan(string naam, string adres, string postcode, string plaats)
        {
            string defaultErrMsg = string.Format("Fout bij opslaan {0}: {1}", (BusinessLogica)this, Environment.NewLine);
            BLLFuncties.ValidateNotNull(Ronde, "Ronde", defaultErrMsg);
            BLLFuncties.ValidateNotNullOrEmpty(naam, "Naam", defaultErrMsg);
            BLLFuncties.ValidateNotNullOrEmpty(adres, "Adres", defaultErrMsg);
            BLLFuncties.ValidateNotNullOrEmpty(plaats, "Plaats", defaultErrMsg);

            Naam = naam;
            Adres = adres;
            Postcode = postcode;
            Plaats = plaats;

            var latLong = JemLatLng.Geef(adres, postcode, plaats, SysteemParametersBasis.StandaardLand.Naam);
            Latitude = latLong.Latitude;
            Longitude = latLong.Longitude;

            _dalObj.Save();
        }

        public void Verwijderen() { _dalObj.Delete(); }

        #endregion
    }
}
