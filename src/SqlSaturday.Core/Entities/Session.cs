using System;
using SqlSaturday.Core.Shared;
using System.Collections.Generic;
using System.Linq;

namespace SqlSaturday.Core.Entities
{
    public class Session
        : BaseEntity<string>
    {
        public string Title { get; set; }
        public string Abstract { get; set; }
        public DateTime SessionStartTime { get; set; }
        public DateTime SessionEndTime { get; set; }
        public string Track { get; set; }
        public string Room { get; set; }

        public IEnumerable<Speaker> Speakers { get; set; }

        public string DisplayTime 
        {
            get 
            {
                return $"{SessionStartTime.ToShortTimeString()} - {SessionEndTime.ToShortTimeString()}";
            }
        }

        public string SpeakerNames 
        {
            get 
            {
                if (Speakers == null)
                    return String.Empty;

                return String.Join(", ", Speakers.Select(p => p.Name));
            }
        }
    }
}