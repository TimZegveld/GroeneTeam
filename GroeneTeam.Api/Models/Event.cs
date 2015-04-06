using System.Runtime.Serialization;
using JemId.Basis;
using JemId.Basis.BLL;

namespace GroeneTeam.Api.Models
{
    [DataContract, KnownType(typeof(Event))]
    public class Event : GroeneTeam.Models.Event, IBusinessLogica
    {
        public Event(BLL.Evenement evenement)
        {
            if (evenement == null) return;

            ID = evenement.ID;
            Name = evenement.Naam;
            Description = evenement.Omschrijving;
            StartTime = evenement.StartTijd;
            EndTime = evenement.EindTijd;
            IsPublic = evenement.IsOpenbaar;
            AllowInvitations = evenement.MagUitnodigen;
            // TODO: Hier een lijst van echte deelnemers van maken
            Participants = evenement.Deelnemer.ConvertToList().ConvertAll(d => new User(d));
        }
    }
}
