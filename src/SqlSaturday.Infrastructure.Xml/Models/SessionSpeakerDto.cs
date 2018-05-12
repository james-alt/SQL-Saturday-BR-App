using System.Xml.Serialization;

namespace SqlSaturday.Infrastructure.Xml.Models
{
    public class SessionSpeakerDto
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }
}
