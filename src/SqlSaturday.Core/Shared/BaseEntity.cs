using System;

namespace SqlSaturday.Core.Shared
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
