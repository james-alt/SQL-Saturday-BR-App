using SqlSaturday.Core.Shared;

namespace SqlSaturday.Core.Entities
{
    public class Track
        : BaseEntity<string>
    {
        public string Title { get; set; }
    }
}
