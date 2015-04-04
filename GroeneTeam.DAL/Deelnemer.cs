using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JemId.Basis.DAL;

namespace GroeneTeam.DAL
{
    public class Deelnemer : Gebruiker
    {
        [DatabaseField]
        public bool MagHosten { get; set; }
    }
}
