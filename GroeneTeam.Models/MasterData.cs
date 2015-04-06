using System.Runtime.Serialization;

namespace GroeneTeam.Models
{
    [DataContract]
    public class MasterData : BaseModel
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
