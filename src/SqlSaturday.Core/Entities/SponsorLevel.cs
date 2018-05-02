using System;
using SqlSaturday.Core.Shared;
namespace SqlSaturday.Core.Entities
{
    public class SponsorLevel
        : BaseEntity<int>
    {
        public string Label { get; set; }
    }
}
