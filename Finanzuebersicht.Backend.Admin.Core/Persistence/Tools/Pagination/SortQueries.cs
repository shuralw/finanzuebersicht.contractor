using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts.Pagination;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tools.Pagination
{
    internal class SortQueries
    {
        internal static IQueryable<T> SortByString<T>(
            IQueryable<T> query,
            IPaginationSortItem sortItem)
        {
            if (sortItem == null)
            {
                return query;
            }

            PaginationQueryStep[] querySteps = PaginationQueryStep.Parse(sortItem.PropertyQuery);

            var param = Expression.Parameter(typeof(T), "x");
            Expression prop = param;
            foreach (var queryStep in querySteps)
            {
                if (queryStep.PaginationQueryStepType == PaginationQueryStepType.Any)
                {
                    throw new PaginationException("This QueryStepType ist not allowed for sorting: '<'");
                }

                prop = Expression.PropertyOrField(prop, queryStep.Name);
            }

            var expr = Expression.Lambda<Func<T, string>>(prop, param);

            if (sortItem.OrderBy == SortOrder.DESC)
            {
                return query.OrderByDescending(expr);
            }

            return query.OrderBy(expr);
        }
    }
}