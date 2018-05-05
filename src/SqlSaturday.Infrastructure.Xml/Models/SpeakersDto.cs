using System.Collections.Generic;
using System.Xml.Serialization;

namespace SqlSaturday.Infrastructure.Xml.Models
{
    public class SpeakersDto
    {
        [XmlElement("speaker")]
        public List<SpeakerDto> Speakers { get; set; }
    }
}
