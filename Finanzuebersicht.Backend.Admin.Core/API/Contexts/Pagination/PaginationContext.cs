using Microsoft.AspNetCore.Http;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Finanzuebersicht.Backend.Admin.Core.API.Contexts.Pagination
{
    public class PaginationContext : IPaginationContext
    {
        private const int DefaultLimit = 10;

        private readonly IHttpContextAccessor httpContextAccessor;

        public PaginationContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public int Limit
        {
            get
            {
                try
                {
                    if (this.httpContextAccessor.HttpContext.Request.Query.ContainsKey("limit"))
                    {
                        string limitString = this.httpContextAccessor.HttpContext.Request.Query["limit"].First();
                        int limit = Convert.ToInt32(limitString);

                        if (limit <= 0)
                        {
                            return DefaultLimit;
                        }

                        return limit;
                    }
                }
                catch
                {
                }

                return DefaultLimit;
            }
        }

        public int Offset
        {
            get
            {
                try
                {
                    if (this.httpContextAccessor.HttpContext.Request.Query.ContainsKey("offset"))
                    {
                        string offsetString = this.httpContextAccessor.HttpContext.Request.Query["offset"].First();
                        int offset = Convert.ToInt32(offsetString);

                        if (offset < 0)
                        {
                            return 0;
                        }

                        return Convert.ToInt32(offsetString);
                    }
                }
                catch
                {
                }

                return 0;
            }
        }

        public IDictionary<string, IPaginationFilterItem> Filter
        {
            get
            {
                IEnumerable<PaginationField> paginationFilterFields = this.GetPaginationFilterFields();

                if (paginationFilterFields == null || !paginationFilterFields.Any())
                {
                    return new Dictionary<string, IPaginationFilterItem>();
                }

                return this.GetFilterItemsFromQuery()
                    .Where(paginationFilterItem => paginationFilterFields
                        .Select(filterField => filterField.PropertyName.ToLower())
                        .Contains(paginationFilterItem.Value.PropertyName.ToLower()))
                    .ToDictionary(
                        x => x.Key,
                        x =>
                        {
                            x.Value.PropertyQuery = paginationFilterFields
                                .Single(field => field.PropertyName.ToLower() == x.Value.PropertyName.ToLower())
                                .PropertyQuery;
                            return x.Value;
                        },
                        StringComparer.InvariantCultureIgnoreCase);
            }
        }

        public IDictionary<string, IPaginationFilterItem> CustomFilter
        {
            get
            {
                IEnumerable<string> paginationFilterFields = this.GetPaginationCustomFilterFields();

                if (paginationFilterFields == null || !paginationFilterFields.Any())
                {
                    return new Dictionary<string, IPaginationFilterItem>();
                }

                return this.GetFilterItemsFromQuery()
                    .Where(paginationFilterItem => paginationFilterFields
                        .Select(filterField => filterField.ToLower())
                        .Contains(paginationFilterItem.Value.PropertyName.ToLower()))
                    .ToDictionary(x => x.Key, x => x.Value, StringComparer.InvariantCultureIgnoreCase);
            }
        }

        public IDictionary<string, IPaginationSortItem> Sort
        {
            get
            {
                IEnumerable<PaginationField> paginationSortFields = this.GetPaginationSortFields();

                if (paginationSortFields == null || !paginationSortFields.Any())
                {
                    return new Dictionary<string, IPaginationSortItem>();
                }

                return this.GetSortItemsFromQuery()
                    .Where(paginationSortItem => paginationSortFields
                        .Select(sortField => sortField.PropertyName.ToLower())
                        .Contains(paginationSortItem.Value.PropertyName.ToLower()))
                    .ToDictionary(
                        x => x.Key,
                        x =>
                        {
                            x.Value.PropertyQuery = paginationSortFields
                                .Single(field => field.PropertyName.ToLower() == x.Value.PropertyName.ToLower())
                                .PropertyQuery;
                            return x.Value;
                        },
                        StringComparer.InvariantCultureIgnoreCase);
            }
        }

        public IDictionary<string, IPaginationSortItem> CustomSort
        {
            get
            {
                IEnumerable<string> paginationSortFields = this.GetPaginationCustomSortFields();

                if (paginationSortFields == null || !paginationSortFields.Any())
                {
                    return new Dictionary<string, IPaginationSortItem>();
                }

                return this.GetSortItemsFromQuery()
                    .Where(paginationSortItem => paginationSortFields
                        .Select(sortField => sortField.ToLower())
                        .Contains(paginationSortItem.Value.PropertyName.ToLower()))
                    .ToDictionary(x => x.Key, x => x.Value, StringComparer.InvariantCultureIgnoreCase);
            }
        }

        private IDictionary<string, IPaginationFilterItem> GetFilterItemsFromQuery()
        {
            return this.httpContextAccessor.HttpContext.Request.Query
                .Where((keyValue) => !string.IsNullOrWhiteSpace(keyValue.Value) && keyValue.Value.ToString().Trim() != "%%")
                .Where((keyValue) =>
                {
                    bool isEqualFilter = Regex.IsMatch(keyValue.Key, @"^filter\.[a-zA-Z0-9]+$", RegexOptions.IgnoreCase);
                    bool isAdvancedEqualFilter = Regex.IsMatch(keyValue.Key, @"^filter\.[a-zA-Z0-9]+\.(eq|gt|gte|lt|lte)$", RegexOptions.IgnoreCase);
                    return isEqualFilter || isAdvancedEqualFilter;
                })
                .Select(keyValue =>
                {
                    string[] filterSplit = keyValue.Key.Split(".");

                    PaginationFilterItem paginationFilterItem = new PaginationFilterItem()
                    {
                        FilterType = this.ExtractFilterType(filterSplit),
                        PropertyName = filterSplit[1],
                        PropertyValue = keyValue.Value,
                    };

                    return new KeyValuePair<string, IPaginationFilterItem>(paginationFilterItem.PropertyName, paginationFilterItem);
                })
                .ToDictionary(x => x.Key, x => x.Value, StringComparer.InvariantCultureIgnoreCase);
        }

        private FilterType ExtractFilterType(string[] filterSplit)
        {
            if (filterSplit.Length == 3)
            {
                switch (filterSplit[2].ToLower())
                {
                    case "lt":
                        return FilterType.LessThan;

                    case "lte":
                        return FilterType.LessThanOrEqual;

                    case "gt":
                        return FilterType.GreaterThan;

                    case "gte":
                        return FilterType.GreaterThanOrEqual;

                    case "eq":
                    default:
                        return FilterType.Equal;
                }
            }
            else
            {
                return FilterType.Equal;
            }
        }

        private IDictionary<string, IPaginationSortItem> GetSortItemsFromQuery()
        {
            return this.httpContextAccessor.HttpContext.Request.Query
                .Where((keyValue) =>
                {
                    bool isEqualFilter = keyValue.Key == "sort";
                    bool isAdvancedEqualFilter = Regex.IsMatch(keyValue.Key, @"^sort\.(asc|desc)$", RegexOptions.IgnoreCase);
                    return isEqualFilter || isAdvancedEqualFilter;
                })
                .Select(keyValue =>
                {
                    string[] sortSplit = keyValue.Key.Split(".");

                    PaginationSortItem paginationSort = new PaginationSortItem()
                    {
                        OrderBy = this.ExtractOrderBy(sortSplit),
                        PropertyName = keyValue.Value,
                    };

                    return new KeyValuePair<string, IPaginationSortItem>(paginationSort.PropertyName, paginationSort);
                })
                .ToDictionary(x => x.Key, x => x.Value);
        }

        private SortOrder ExtractOrderBy(string[] filterSplit)
        {
            if (filterSplit.Length == 2)
            {
                switch (filterSplit[1].ToLower())
                {
                    case "desc":
                        return SortOrder.DESC;

                    case "asc":
                    default:
                        return SortOrder.ASC;
                }
            }
            else
            {
                return SortOrder.ASC;
            }
        }

        private IEnumerable<PaginationField> GetPaginationFilterFields()
        {
            return this.httpContextAccessor.HttpContext
                .GetEndpoint().Metadata
                .GetMetadata<PaginationAttribute>()
                .FilterFields?
                .Select(customFilterField =>
                {
                    return new PaginationField()
                    {
                        PropertyName = customFilterField
                            .Split("=")
                            .First()
                            .Trim(),
                        PropertyQuery = customFilterField.Contains("=") ? customFilterField : null,
                    };
                });
        }

        private IEnumerable<string> GetPaginationCustomFilterFields()
        {
            return this.httpContextAccessor.HttpContext
                .GetEndpoint().Metadata
                .GetMetadata<PaginationAttribute>()
                .CustomFilterFields?
                .Select(customFilterField => customFilterField.Trim());
        }

        private IEnumerable<PaginationField> GetPaginationSortFields()
        {
            return this.httpContextAccessor.HttpContext
                .GetEndpoint().Metadata
                .GetMetadata<PaginationAttribute>()
                .SortFields?
                .Select(customFilterField =>
                {
                    return new PaginationField()
                    {
                        PropertyName = customFilterField
                            .Split("=")
                            .First()
                            .Trim(),
                        PropertyQuery = customFilterField.Contains("=") ? customFilterField : null,
                    };
                });
        }

        private IEnumerable<string> GetPaginationCustomSortFields()
        {
            return this.httpContextAccessor.HttpContext
                .GetEndpoint().Metadata
                .GetMetadata<PaginationAttribute>()
                .CustomSortFields?
                .Select(customFilterField => customFilterField.Trim());
        }
    }
}