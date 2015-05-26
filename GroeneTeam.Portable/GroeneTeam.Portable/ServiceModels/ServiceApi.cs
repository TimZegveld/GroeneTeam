using System;
using System.Collections.Generic;
using System.Text;
using JemId.Basis.RestProxy.Portable;

namespace GroeneTeam.ServiceModels
{
    public class ServiceApi : JemServiceApi
    {
        private static readonly string _baseUrl = "http://localhost:61951/api";

        public string User { get; private set; }

        public ServiceApi()
            : this(string.Empty, string.Empty)
        { }

        public ServiceApi(string user, string hashedPassword)
            : base(_baseUrl, user, hashedPassword)
        { User = user; }
    }
}
