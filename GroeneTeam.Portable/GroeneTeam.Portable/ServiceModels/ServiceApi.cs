using System;
using System.Collections.Generic;
using System.Text;
using JemId.Basis.RestProxy;

namespace GroeneTeam.ServiceModels
{
    public class ServiceApi : JemServiceApi
    {
        private static readonly string _baseUrl = "http://vmp.floraxchange.nl/api/";
        // Deze moet later naar api.floraxchange.nl gaan verwijzen

        public string User { get; private set; }

        public ServiceApi()
            : this(string.Empty, string.Empty)
        { }

        public ServiceApi(string user, string hashedPassword)
            : base(_baseUrl, user, hashedPassword)
        { User = user; }
    }
}
