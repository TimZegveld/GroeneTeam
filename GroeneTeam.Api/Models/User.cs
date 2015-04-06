using System.Runtime.Serialization;
using GroeneTeam.BLL;
using JemId.Basis.BLL;

namespace GroeneTeam.Api.Models
{
    [DataContract, KnownType(typeof(User))]
    public class User : GroeneTeam.Models.User, IBusinessLogica
    {
        public User(Deelnemer deelnemer)
        {
            if (deelnemer == null) return;

            ID = deelnemer.ID;
            FullName = deelnemer.VolledigeNaam;
            EmailAddress = deelnemer.EmailAdres;
        }
    }
}
