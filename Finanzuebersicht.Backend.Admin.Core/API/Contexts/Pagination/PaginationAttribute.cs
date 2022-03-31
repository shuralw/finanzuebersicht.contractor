using System;

namespace Finanzuebersicht.Backend.Admin.Core.API.Contexts.Pagination
{
    public sealed class PaginationAttribute : Attribute
    {
        public PaginationAttribute()
        {
        }

        public string[] FilterFields { get; set; }

        public string[] CustomFilterFields { get; set; }

        public string[] SortFields { get; set; }

        public string[] CustomSortFields { get; set; }
    }
}