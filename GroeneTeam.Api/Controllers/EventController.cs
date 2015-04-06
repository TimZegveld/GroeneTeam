using System.Collections.Generic;
using System.Web.Mvc;
using JemId.Basis.WebApi.Controllers;
using Event = GroeneTeam.Api.Models.Event;

namespace GroeneTeam.Api.Controllers
{
    public class EventController : JemApiController
    {
        public IEnumerable<Event> Get()
        {
            return BLL.Evenement.GeefLijst(string.Empty).ConvertAll(e => new Event(e));
        }

        public Event Get(int id)
        {
            return new Event(new BLL.Evenement(id));
        }
    }
}