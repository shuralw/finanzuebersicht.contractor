﻿using Microsoft.EntityFrameworkCore;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tools.Pagination;
using System;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence
{
    public static class Pagination
    {
        public static IDbPagedResult<Tout> Filter<Tin, Tout>(
            IQueryable<Tin> query,
            IPaginationContext paginationContext,
            Func<Tin, Tout> dtoTransformation)
        {
            try
            {
                query = Filtering(query, paginationContext);
                query = Sorting(query, paginationContext);

                int totalCount = query.Count();
                query = query.Skip(paginationContext.Offset);
                query = query.Take(paginationContext.Limit);

                return new DbPagedResult<Tout>(paginationContext)
                {
                    Count = query.Count(),
                    Data = query.Select(dtoTransformation),
                    TotalCount = totalCount,
                };
            }
            catch (Exception ex)
            {
                throw new PaginationException("Error occurred in the pagination", ex);
            }
        }

        private static IQueryable<Tin> Filtering<Tin>(IQueryable<Tin> query, IPaginationContext paginationContext)
        {
            foreach (var filterKeyValuePair in paginationContext.Filter)
            {
                var filterElement = filterKeyValuePair.Value;
                if (filterElement.PropertyQuery != null)
                {
                    query = FilterQueries.FilterByStringAny(query, filterElement);
                }
                else
                {
                    string propertyName = char.ToUpper(filterElement.PropertyName[0]) + filterElement.PropertyName[1..];
                    string[] propertyValueSplit = filterElement.PropertyValue.Split('|');

                    if (filterElement.FilterType == FilterType.Equal)
                    {
                        Type propertyType = typeof(Tin).GetProperty(propertyName).PropertyType;
                        if (propertyType.IsGenericType)
                        {
                            propertyType = propertyType.GetGenericArguments().First();
                        }

                        switch (Type.GetTypeCode(propertyType))
                        {
                            case TypeCode.Boolean:
                                var propertyValueBool = propertyValueSplit.Select(propertyValue => bool.Parse(propertyValue));
                                query = query.Where(p => propertyValueBool.Contains(EF.Property<bool>(p, propertyName)));
                                break;

                            case TypeCode.DateTime:
                                var propertyValueDateTimes = propertyValueSplit.Select(propertyValue => DateTime.Parse(propertyValue));
                                query = query.Where(p => propertyValueDateTimes.Contains(EF.Property<DateTime>(p, propertyName)));
                                break;

                            case TypeCode.Int32:
                                var propertyValueInts = propertyValueSplit.Select(propertyValue => int.Parse(propertyValue));
                                query = query.Where(p => propertyValueInts.Contains(EF.Property<int>(p, propertyName)));
                                break;

                            case TypeCode.Double:
                                var propertyValueDoubles = propertyValueSplit.Select(propertyValue => double.Parse(propertyValue));
                                query = query.Where(p => propertyValueDoubles.Contains(EF.Property<double>(p, propertyName)));
                                break;

                            case TypeCode.String:
                                query = query.LikeAny(propertyName, propertyValueSplit);
                                break;

                            case TypeCode.Object:
                                if (propertyType == typeof(Guid))
                                {
                                    var propertyValueGuids = propertyValueSplit.Select(propertyValue => Guid.Parse(propertyValue));
                                    query = query.Where(p => propertyValueGuids.Contains(EF.Property<Guid>(p, propertyName)));
                                }

                                break;
                        }
                    }
                    else
                    {
                        if (int.TryParse(propertyValueSplit[0], out int propertyValueInt))
                        {
                            switch (filterElement.FilterType)
                            {
                                case FilterType.GreaterThan:
                                    query = query.Where(p => EF.Property<int>(p, propertyName) > propertyValueInt);
                                    break;

                                case FilterType.GreaterThanOrEqual:
                                    query = query.Where(p => EF.Property<int>(p, propertyName) >= propertyValueInt);
                                    break;

                                case FilterType.LessThan:
                                    query = query.Where(p => EF.Property<int>(p, propertyName) < propertyValueInt);
                                    break;

                                case FilterType.LessThanOrEqual:
                                    query = query.Where(p => EF.Property<int>(p, propertyName) <= propertyValueInt);
                                    break;
                            }
                        }
                        else if (double.TryParse(propertyValueSplit[0], out double propertyValueDouble))
                        {
                            switch (filterElement.FilterType)
                            {
                                case FilterType.GreaterThan:
                                    query = query.Where(p => EF.Property<double>(p, propertyName) > propertyValueDouble);
                                    break;

                                case FilterType.GreaterThanOrEqual:
                                    query = query.Where(p => EF.Property<double>(p, propertyName) >= propertyValueDouble);
                                    break;

                                case FilterType.LessThan:
                                    query = query.Where(p => EF.Property<double>(p, propertyName) < propertyValueDouble);
                                    break;

                                case FilterType.LessThanOrEqual:
                                    query = query.Where(p => EF.Property<double>(p, propertyName) <= propertyValueDouble);
                                    break;
                            }
                        }
                        else if (DateTime.TryParse(propertyValueSplit[0], out DateTime propertyValueDateTime))
                        {
                            switch (filterElement.FilterType)
                            {
                                case FilterType.GreaterThan:
                                    query = query.Where(p => EF.Property<DateTime>(p, propertyName) > propertyValueDateTime);
                                    break;

                                case FilterType.GreaterThanOrEqual:
                                    query = query.Where(p => EF.Property<DateTime>(p, propertyName) >= propertyValueDateTime);
                                    break;

                                case FilterType.LessThan:
                                    query = query.Where(p => EF.Property<DateTime>(p, propertyName) < propertyValueDateTime);
                                    break;

                                case FilterType.LessThanOrEqual:
                                    query = query.Where(p => EF.Property<DateTime>(p, propertyName) <= propertyValueDateTime);
                                    break;
                            }
                        }
                    }
                }
            }

            return query;
        }

        private static IQueryable<Tin> Sorting<Tin>(IQueryable<Tin> query, IPaginationContext paginationContext)
        {
            var sort = paginationContext.Sort;
            for (int i = 0; i < sort.Count; i++)
            {
                var sortElement = sort.ElementAt(i).Value;

                if (sortElement.PropertyQuery != null)
                {
                    query = SortQueries.SortByString(query, sortElement);
                }
                else
                {
                    string propertyName = char.ToUpper(sortElement.PropertyName[0]) + sortElement.PropertyName[1..];
                    if (i == 0)
                    {
                        if (sortElement.OrderBy == SortOrder.ASC)
                        {
                            query = query.OrderBy(p => EF.Property<object>(p, propertyName));
                        }
                        else
                        {
                            query = query.OrderByDescending(p => EF.Property<object>(p, propertyName));
                        }
                    }
                    else
                    {
                        var orderedQuery = query as IOrderedQueryable<Tin>;

                        if (sortElement.OrderBy == SortOrder.ASC)
                        {
                            query = orderedQuery.ThenBy(p => EF.Property<object>(p, propertyName));
                        }
                        else
                        {
                            query = orderedQuery.ThenByDescending(p => EF.Property<object>(p, propertyName));
                        }
                    }
                }
            }

            return query;
        }
    }
}