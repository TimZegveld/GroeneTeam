using System;
using JemId.Basis.DAL;

namespace GroeneTeam.DAL
{
    public class RondeLocatie : DALTable
    {
        [DatabaseField(IsPrimaryKey = true)]
        public int RondeLocatieID { get; set; }

        [DatabaseField]
        public int RondeID { get; set; }

        [DatabaseField]
        public int LocatieID { get; set; }
    }
}