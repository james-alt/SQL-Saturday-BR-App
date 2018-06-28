using System;
using SqlSaturday.Core.Shared;

namespace SqlSaturday.Core.Entities
{
    public class SavedSession
        : BaseEntity<string>
    {
        public Session Session { get; set; }
    }
}
