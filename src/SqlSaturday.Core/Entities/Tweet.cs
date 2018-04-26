using System;
using SqlSaturday.Core.Shared;

namespace SqlSaturday.Core.Entities
{
    public class Tweet
        : BaseEntity<string>
    {
        public string Message { get; set; }
        public string Username { get; set; }
    }
}
