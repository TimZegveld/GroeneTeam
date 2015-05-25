using JemId.Basis.DAL;

namespace GroeneTeam.DAL
{
    public class Locatie : DALTable
    {
        [DatabaseField(IsPrimaryKey = true)]
        public int LocatieID { get; set; }

        [DatabaseField(Length = 250)]
        public string Naam { get; set; }

        [DatabaseField(Length = 250)]
        public string Adres { get; set; }

        [DatabaseField(Length = 250)]
        public string Postcode { get; set; }

        [DatabaseField(Length = 250)]
        public string Plaats { get; set; }

        [DatabaseField]
        public double Latitude { get; set; }

        [DatabaseField]
        public double Longitude { get; set; }
    }
}
