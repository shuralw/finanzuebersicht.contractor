using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Contexts
{
    public interface IPaginationContext
    {
        int Limit { get; }

        int Offset { get; }

        IDictionary<string, IPaginationFilterItem> Filter { get; }

        IDictionary<string, IPaginationFilterItem> CustomFilter { get; }

        IDictionary<string, IPaginationSortItem> Sort { get; }

        IDictionary<string, IPaginationSortItem> CustomSort { get; }
    }
}