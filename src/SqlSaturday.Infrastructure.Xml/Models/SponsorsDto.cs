using System.Collections.Generic;
using System.Xml.Serialization;

namespace SqlSaturday.Infrastructure.Xml.Models
{
    public class SponsorsDto
    {
        [XmlElement("sponsor")]
        public List<SponsorDto> Sponsors { get; set; }
    }
}
