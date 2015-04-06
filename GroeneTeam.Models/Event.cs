using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GroeneTeam.Models
{
    [DataContract]
    public class Event : BaseModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public DateTime EndTime { get; set; }

        [DataMember]
        public bool IsPublic { get; set; }

        [DataMember]
        public bool AllowInvitations { get; set; }

        [DataMember]
        public IEnumerable<User> Participants { get; set; }
    }
}
