using System.Runtime.Serialization;

namespace GroeneTeam.Models
{
    [DataContract]
    public class User : BaseModel
    {
        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
    }
}
