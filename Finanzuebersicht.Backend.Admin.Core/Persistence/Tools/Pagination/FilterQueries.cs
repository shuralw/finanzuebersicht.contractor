using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tools.Pagination
{
    internal class FilterQueries
    {
        internal static IQueryable<T> FilterByStringAny<T>(
            IQueryable<T> query,
            IPaginationFilterItem filterItem)
        {
            if (filterItem == null)
            {
                return query;
            }

            PaginationQueryStep[] querySteps = PaginationQueryStep.Parse(filterItem.PropertyQuery);

            var param = Expression.Parameter(typeof(T), "x");

            var body = Recursive(querySteps, 0, param, filterItem);

            var expr = Expression.Lambda<Func<T, bool>>(body, param);
            return query.Where(expr);
        }

        private static Expression Recursive(
            PaginationQueryStep[] querySteps,
            int anyLevel,
            Expression prop,
            IPaginationFilterItem filterItem)
        {
            PaginationQueryStep currentQueryStep = querySteps[0];
            prop = Expression.PropertyOrField(prop, currentQueryStep.Name);
            if (currentQueryStep.PaginationQueryStepType == PaginationQueryStepType.Property)
            {
                return Recursive(querySteps[1..], anyLevel, prop, filterItem);
            }
            else if (currentQueryStep.PaginationQueryStepType == PaginationQueryStepType.Any)
            {
                return AnyFilterExpression(anyLevel, prop, (param, level) =>
                {
                    return Recursive(querySteps[1..], anyLevel + 1, param, filterItem);
                });
            }
            else
            {
                return FilterExpression(filterItem, prop);
            }
        }

        private static MethodCallExpression AnyFilterExpression(
            int level,
            Expression prop,
            Func<ParameterExpression, int, Expression> innerExprResolver)
        {
            // efFiliale.Kunden
            var propType = prop.Type.GenericTypeArguments.First();

            // Enumerable<EfKunde>.Any(
            var anyMethod =
                typeof(Enumerable)
                    .GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance)
                    .FirstOrDefault(x => x.Name == "Any" && x.GetParameters().Length == 2 && x.GetGenericArguments().Length == 1)
                    .MakeGenericMethod(propType);

            // efKunde
            var innerParam = Expression.Parameter(propType, "x" + level);

            // bankIds.Contains(efKunde.BankId)
            var innerBody = innerExprResolver(innerParam, level);

            // efKunde => bankIds.Contains(efKunde.BankId)
            var innerExpr = Expression.Lambda(innerBody, innerParam);

            // efFiliale.Kunden.Any(efKunde => bankIds.Contains(efKunde.BankId))
            var body = Expression.Call(null, anyMethod, prop, innerExpr);

            return body;
        }

        private static Expression FilterExpression(
            IPaginationFilterItem filterItem,
            Expression prop)
        {
            if (filterItem.PropertyValue.Contains("%") || filterItem.PropertyValue.Contains("_"))
            {
                return LikeFilterExpression(filterItem, prop);
            }
            else
            {
                return ContainsFilterExpression(filterItem, prop);
            }
        }

        private static Expression LikeFilterExpression(
            IPaginationFilterItem filterItem,
            Expression prop)
        {
            // bankIds
            string[] propertyValueSplit = filterItem.PropertyValue.Split('|');

            return ExpressionHelper.LikeAnyBody<string>(prop, propertyValueSplit);
        }

        private static MethodCallExpression ContainsFilterExpression(
            IPaginationFilterItem filterItem,
            Expression prop)
        {
            // bankIds
            var filterValues = GetFilterValues(prop.Type, filterItem);
            var valuesConstant = Expression.Constant(filterValues);

            // List<object>.Contains
            var containsMethod = filterValues.GetType().GetMethod(nameof(List<object>.Contains));

            // bankIds.Contains(efKunde.BankId)
            var body = Expression.Call(valuesConstant, containsMethod, prop);
            return body;
        }

        private static object GetFilterValues(
            Type type,
            IPaginationFilterItem filterItem)
        {
            string[] propertyValueSplit = filterItem.PropertyValue.Split('|');
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    return propertyValueSplit.Select(propertyValue => bool.Parse(propertyValue)).ToList();

                case TypeCode.DateTime:
                    return propertyValueSplit.Select(propertyValue => DateTime.Parse(propertyValue)).ToList();

                case TypeCode.Int32:
                    return propertyValueSplit.Select(propertyValue => int.Parse(propertyValue)).ToList();

                case TypeCode.Double:
                    return propertyValueSplit.Select(propertyValue => double.Parse(propertyValue)).ToList();

                case TypeCode.String:
                    return propertyValueSplit;

                case TypeCode.Object:
                    if (type == typeof(Guid))
                    {
                        return propertyValueSplit.Select(propertyValue => Guid.Parse(propertyValue)).ToList();
                    }

                    break;
            }

            return propertyValueSplit.ToList();
        }
    }
}