using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JemId.Basis.DAL;

namespace GroeneTeam.DAL
{
    public class Evenement : DALTable
    {
        [DatabaseField(IsPrimaryKey = true)]
        public int EvenementID { get; set; }

        [DatabaseField(Length = 250)]
        public string Naam { get; set; }

        [DatabaseField(Length = 500)]
        public string Omschrijving { get; set; }

        [DatabaseField]
        public DateTime StartTijd { get; set; }

        [DatabaseField]
        public DateTime EindTijd { get; set; }

        [DatabaseField]
        public bool IsOpenbaar { get; set; }

        [DatabaseField]
        public bool MagUitnodigen { get; set; }

        [DatabaseField]
        public int DeelnemerID { get; set; }
    }
}
