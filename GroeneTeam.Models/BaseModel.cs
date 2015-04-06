using System.Runtime.Serialization;

namespace GroeneTeam.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int ID { get; set; }
    }
}
