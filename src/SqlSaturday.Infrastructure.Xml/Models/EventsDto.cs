using System.Collections.Generic;
using System.Xml.Serialization;

namespace SqlSaturday.Infrastructure.Xml.Models
{
    public class EventsDto
    {
        [XmlElement("event")]
        public List<EventDto> Events { get; set; }
    }
}
