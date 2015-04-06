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
        public int DeelnemerID { get; set; }

        [DatabaseField]
        public bool MagHosten { get; set; }

        public override List<TabelMutatieLog> Save()
        {
            if (GebruikerID == 0)
            {
                var retValue = base.Save();
                DeelnemerID = GebruikerID;
                retValue.AddRange(base.Save());

                return retValue;
            }
            else
            {
                return base.Save();
            }
        }
    }
}
