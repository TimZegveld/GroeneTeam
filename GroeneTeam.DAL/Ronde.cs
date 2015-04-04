using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JemId.Basis.DAL;

namespace GroeneTeam.DAL
{
    public class Ronde : DALTable
    {
        [DatabaseField(IsPrimaryKey = true)]
        public int RondeID { get; set; }

        [DatabaseField]
        public int Volgorde { get; set; }

        [DatabaseField]
        public int DoorlooptijdInMinuten { get; set; }

        [DatabaseField]
        public int EvenementID { get; set; }
    }
}
