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

        #region Constructors

        public Locatie(int id)
        {
            _dalObj = JemId.Basis.DAL.DALManager.Get<DAL.Locatie>(id);
        }

        internal Locatie(DAL.Locatie dalObj)
        {
            _dalObj = dalObj;
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

        #endregion

        #region Statics

        public static List<Locatie> GeefLijst()
        { return GeefLijst(string.Empty); }

        public static List<Locatie> GeefLijst(string where)
        { return GeefLijst(where, string.Empty, 0); }

        private static List<Locatie> GeefLijst(string where, string orderBy, int aantal)
        {
            return JemId.Basis.DAL.DALManager.GetCollection<DAL.Locatie>(where, orderBy, aantal)
                .ConvertAll(dalObj => new Locatie(dalObj));
        }

        #endregion

        #region Methods

        public void Opslaan(string naam, string adres, string postcode, string plaats)
        {
            string defaultErrMsg = string.Format("Fout bij opslaan {0}: {1}", (BusinessLogica)this, Environment.NewLine);
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
