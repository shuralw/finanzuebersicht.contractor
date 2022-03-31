using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tools.Pagination
{
    public static class ExpressionHelper
    {
        public static Expression<Func<T, bool>> LikeAny<T>(string propertyName, params string[] propertyValues)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var prop = Expression.Property(parameter, typeof(T).GetProperty(propertyName));

            return Expression.Lambda<Func<T, bool>>(LikeAnyBody<T>(prop, propertyValues), parameter);
        }

        public static Expression LikeAnyBody<T>(Expression prop, params string[] propertyValues)
        {
            Expression body = propertyValues
                .Select(word => Expression.Call(
                    typeof(DbFunctionsExtensions).GetMethod(
                        nameof(DbFunctionsExtensions.Like),
                        new[] { typeof(DbFunctions), typeof(string), typeof(string) }),
                    Expression.Constant(EF.Functions),
                    prop,
                    Expression.Constant(word)))
                .Aggregate<MethodCallExpression, Expression>(
                    null,
                    (current, call) => current != null ? Expression.OrElse(current, call) : (Expression)call);

            return body;
        }
    }
}
