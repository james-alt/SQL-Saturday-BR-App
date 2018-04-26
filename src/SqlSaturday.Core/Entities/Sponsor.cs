using System;
using SqlSaturday.Core.Shared;

namespace SqlSaturday.Core.Entities
{
    public class Sponsor
        : BaseEntity<string>
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string ImageUrl { get; set; }
    }
}
