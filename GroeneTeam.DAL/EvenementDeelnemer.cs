using System;
using JemId.Basis.DAL;

namespace GroeneTeam.DAL
{
    public class EvenementDeelnemer : DALTable
    {
        [DatabaseField(IsPrimaryKey = true)]
        public int EvenementDeelnemerID { get; set; }

        [DatabaseField]
        public int EvenementID { get; set; }

        [DatabaseField]
        public int DeelnemerID { get; set; }
    }
}