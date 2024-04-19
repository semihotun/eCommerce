using Core.Utilities.DataTable;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
namespace Core.Utilities.Infrastructure.Filter
{
    public static class FilterHelper
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> contex, IFilterable filtermodel)
        {
            Expression finalExpression = Expression.Constant(true);
            var type = filtermodel.GetType();
            var parameter = Expression.Parameter(typeof(T), "x");
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                try
                {
                    var attr = propertyInfo.GetCustomAttribute<Filter>();
                    if (attr == null) continue;
                    Expression expression = null;
                    var member = Expression.Property(parameter, string.IsNullOrEmpty(attr.queryColumn) ? propertyInfo.Name : attr.queryColumn);
                    var constantValue = propertyInfo.GetValue(filtermodel, null);
                    var constant = Expression.Constant(constantValue);
                    if (!string.IsNullOrEmpty(constantValue?.ToString()) && constantValue?.ToString() != default(int).ToString() &&
                        Guid.Empty.ToString() != constantValue?.ToString())
                    {
                        switch (attr.filters)
                        {
                            case FilterOperators.Equals:
                                expression = Expression.Equal(member, constant);
                                break;
                            case FilterOperators.Contains:
                                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                                expression = Expression.Call(member, method, Expression.Constant(constantValue, typeof(string)));
                                break;
                            case FilterOperators.GreaterThan:
                                expression = Expression.GreaterThanOrEqual(member, constant);
                                break;
                            case FilterOperators.LessThan:
                                expression = Expression.LessThanOrEqual(member, constant);
                                break;
                            case FilterOperators.NotEquals:
                                expression = Expression.NotEqual(member, constant);
                                break;
                        }
                        finalExpression = Expression.AndAlso(finalExpression, expression);
                    }
                }
                catch { }
            }
            if (finalExpression == null)
                return contex;
            return contex.Where(Expression.Lambda<Func<T, bool>>(finalExpression, parameter));
        }
        public static IQueryable<T> ApplyDataTableFilter<T>(this IQueryable<T> contex, DTParameters filtermodel)
        {
            Expression finalExpression = Expression.Constant(true);
            var parameter = Expression.Parameter(typeof(T), "x");
            foreach (var item in filtermodel.Columns.Where(x => x.Search.Value != null))
            {
                if (item.Search.Value != null)
                {
                    Expression expression = null;
                    if (item.Search.Regex)
                    {
                        var filterValue = JsonConvert.DeserializeObject<DataTableValueModel>(item.Search.Value);
                        if (!string.IsNullOrEmpty(filterValue.Value))
                        {
                            var member = Expression.Property(parameter, item.Name);
                            var constant = Expression.Constant(TypeDescriptor.GetConverter(member.Type).ConvertFromString(filterValue.Value), member.Type);
                            switch (Int32.Parse(filterValue.FilterType))
                            {
                                case (int)FilterOperators.Equals:
                                    expression = Expression.Equal(member, constant);
                                    break;
                                case (int)FilterOperators.Contains:
                                    MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                                    expression = Expression.Call(member, method, constant);
                                    break;
                                case (int)FilterOperators.GreaterThan:
                                    expression = Expression.GreaterThanOrEqual(member, constant);
                                    break;
                                case (int)FilterOperators.LessThan:
                                    expression = Expression.LessThanOrEqual(member, constant);
                                    break;
                                case (int)FilterOperators.NotEquals:
                                    expression = Expression.NotEqual(member, constant);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        expression = Expression.Equal(Expression.Property(parameter, item.Name), Expression.Constant(item.Search.Value));
                    }
                    if (expression != null)
                        finalExpression = Expression.AndAlso(finalExpression, expression);
                }
            }
            if (finalExpression == null)
                return contex;
            return contex.Where(Expression.Lambda<Func<T, bool>>(finalExpression, parameter));
        }
    }
}