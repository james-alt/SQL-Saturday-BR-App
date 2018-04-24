using System;
using SqlSaturday.Core.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SqlSaturday.Core.Interfaces
{
    public interface IRepository<T, TId>
        where T : BaseEntity<TId>
    {
        Task<T> GetById(TId id);
        Task<IEnumerable<T>> List();
    }
}