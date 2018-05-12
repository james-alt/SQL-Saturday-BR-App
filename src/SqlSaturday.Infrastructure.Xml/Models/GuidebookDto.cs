﻿using System.Xml.Serialization;

namespace SqlSaturday.Infrastructure.Xml.Models
{
    [XmlRoot("GuidebookXML")]
    public class GuidebookDto
    {
        [XmlElement("guide")]
        public GuideDto Guide { get; set; }

        [XmlElement("sponsors")]
        public SponsorsDto Sponsors { get; set; }

        [XmlElement("speakers")]
        public SpeakersDto Speakers { get; set; }

        [XmlElement("events")]
        public EventsDto Events { get; set; }
    }
}
