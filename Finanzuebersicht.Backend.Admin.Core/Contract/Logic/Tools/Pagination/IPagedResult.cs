using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination
{
    public interface IPagedResult<T>
    {
        int Count { get; set; }

        IEnumerable<T> Data { get; set; }

        int Limit { get; set; }

        int Offset { get; set; }

        int TotalCount { get; set; }
    }
}