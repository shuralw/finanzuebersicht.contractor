using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;

namespace Finanzuebersicht.Backend.Admin.Core.API.Contexts.Pagination
{
    internal class PaginationSortItem : IPaginationSortItem
    {
        public string PropertyName { get; set; }

        public string PropertyQuery { get; set; }

        public SortOrder OrderBy { get; set; }
    }
}