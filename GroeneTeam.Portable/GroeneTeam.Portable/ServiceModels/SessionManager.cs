using System;
using System.Collections.Generic;
using System.Text;

namespace GroeneTeam.ServiceModels
{
    public static class SessionManager
    {
        public static ServiceApi ServiceApi { get; set; }

        public static bool IsAuthenticated
        {
            get { return ServiceApi != null && ServiceApi.IsAuthenticated; }
        }
    }
}
