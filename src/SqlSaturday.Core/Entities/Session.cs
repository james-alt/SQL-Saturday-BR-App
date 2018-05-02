using System;
using SqlSaturday.Core.Shared;
using System.Collections.Generic;

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
                return SessionStartTime.ToShortTimeString();
            }
        }
    }
}