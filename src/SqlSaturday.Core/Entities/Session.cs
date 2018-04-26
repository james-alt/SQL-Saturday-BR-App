using System;
using SqlSaturday.Core.Shared;

namespace SqlSaturday.Core.Entities
{
    public class Session
        : BaseEntity<string>
    {
        public string Title { get; set; }
        public string Abstract { get; set; }
    }
}