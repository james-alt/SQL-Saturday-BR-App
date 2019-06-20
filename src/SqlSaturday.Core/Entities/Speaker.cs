using System;
using System.Collections.Generic;
using SqlSaturday.Core.Shared;

namespace SqlSaturday.Core.Entities
{
    public class Speaker
        : BaseEntity<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string Website { get; set; }
        public string ImageUrl { get; set; }

        public List<string> SpeakerIds { get; set; }

        public string SpeakerIdString
        {
            get
            {
                return String.Join(", ", SpeakerIds);
            }
        }

        public string FirstName
        {
            get
            {
                var nameItems = Name.Split(' ');
                return nameItems[0];
            }
        }

        public string LastName
		{
			get
			{
				var nameItems = Name.Split(' ');
				return nameItems[nameItems.Length - 1];
			}
		}

        public string NameKey
		{
			get 
			{
				return LastName.Substring(0, 1);
			}
		}
    }
}