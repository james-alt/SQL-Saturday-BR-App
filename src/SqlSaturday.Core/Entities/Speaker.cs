using System;
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
    }
}
