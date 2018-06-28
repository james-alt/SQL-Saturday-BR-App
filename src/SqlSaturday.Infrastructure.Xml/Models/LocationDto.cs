using System.Xml.Serialization;

namespace SqlSaturday.Infrastructure.Xml.Models
{
    public class LocationDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
