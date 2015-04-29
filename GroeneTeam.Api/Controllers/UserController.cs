using System.Collections.Generic;
using JemId.Basis.WebApi.Controllers;
using User = GroeneTeam.Api.Models.User;

namespace GroeneTeam.Api.Controllers
{
    public class UserController : JemApiController
    {
        //test

        public IEnumerable<User> Get()
        {
            return BLL.Deelnemer.GeefLijst(string.Empty).ConvertAll(d => new User(d));
        }

        public User Get(int id)
        {
            return new User(new BLL.Deelnemer(id));
        }
    }
}