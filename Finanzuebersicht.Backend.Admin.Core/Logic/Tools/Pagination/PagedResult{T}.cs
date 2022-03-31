﻿using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Pagination
{
    internal class PagedResult<T> : IPagedResult<T>
    {
        public int Count { get; set; }

        public IEnumerable<T> Data { get; set; }

        public int Limit { get; set; }

        public int Offset { get; set; }

        public int TotalCount { get; set; }
    }
}