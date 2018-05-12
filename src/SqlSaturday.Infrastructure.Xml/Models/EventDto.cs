using System;
using System.Xml.Serialization;

namespace SqlSaturday.Infrastructure.Xml.Models
{
    public class EventDto
    {
        [XmlElement("importID")]
        public string ImportID { get; set; }

        [XmlElement("speakers")]
        public SessionSpeakersDto Speakers { get; set; }

        [XmlElement("track")]
        public string Track { get; set; }

        [XmlElement("location")]
        public LocationDto Location { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("startTime")]
        public string StartTimeString
        {
            get { return StartTime.ToString("t"); }
            set { StartTime = DateTime.Parse(value); }
        }

        [XmlIgnore]
        public DateTime StartTime { get; set; }

        [XmlElement("endTime")]
        public string EndTimeString
        {
            get { return EndTime.ToString("t"); }
            set { EndTime = DateTime.Parse(value); }
        }

        [XmlIgnore]
        public DateTime EndTime { get; set; }
    }
}
