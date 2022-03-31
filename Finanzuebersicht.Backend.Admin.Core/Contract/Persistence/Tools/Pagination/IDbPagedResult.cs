using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination
{
    public interface IDbPagedResult<T>
    {
        int Count { get; set; }

        IEnumerable<T> Data { get; set; }

        int Limit { get; set; }

        int Offset { get; set; }

        int TotalCount { get; set; }
    }
}