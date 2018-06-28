using System.Collections.Generic;
using System.Xml.Serialization;

namespace SqlSaturday.Infrastructure.Xml.Models
{
    public class SessionSpeakersDto
    {
        [XmlElement("speaker")]
        public List<SessionSpeakerDto> Speakers { get; set; }
    }
}
