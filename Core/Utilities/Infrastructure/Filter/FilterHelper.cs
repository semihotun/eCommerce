using Core.Utilities.DataTable;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;


namespace Core.Utilities.Infrastructure.Filter
{
    public static class FilterHelper
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> contex, IFilterable filtermodel)
        {
            Expression finalExpression = Expression.Constant(true);
            var type = filtermodel.GetType();
            var parameter = Expression.Parameter(typeof(T), "x");
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                try
                {
                    Filter attr = (Filter)propertyInfo.GetCustomAttributes<Filter>().First();
                    Expression expression = null;
                    var columnName = string.IsNullOrEmpty(attr.queryColumn) ? propertyInfo.Name : attr.queryColumn;
                    var member = Expression.Property(parameter, columnName);
                    var constantValue = propertyInfo.GetValue(filtermodel, null);
                    var constant = Expression.Constant(constantValue);

                    if (constantValue != null && !string.IsNullOrEmpty(constantValue.ToString()) && constantValue.ToString() != "0")
                    {
                        switch (attr.filters)
                        {
                            case FilterOperators.Equals:
                                expression = Expression.Equal(member, constant);
                                break;
                            case FilterOperators.Contains:
                                //Muamma
                                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                                var someValue = Expression.Constant(constantValue, typeof(string));
                                expression = Expression.Call(member, method, someValue);
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
            var data = contex.Where(Expression.Lambda<Func<T, bool>>(finalExpression, parameter));
            return data;
        }

        public class DataTableValueModel
        {
            public string Value { get; set; }
            public string FilterType { get; set; }
        }

        public static IQueryable<T> ApplyDataTableFilter<T>(this IQueryable<T> contex, DTParameters filtermodel)
        {

            Expression finalExpression = Expression.Constant(true);
            var parameter = Expression.Parameter(typeof(T), "x");
            var filters = filtermodel.Columns.Where(x => x.Search.Value != null);
            foreach (var item in filters)
            {
                if (item.Search.Value != null)
                {
                    Expression expression = null;
                    if (item.Search.Regex == true)
                    {
                        var filterValue = JsonConvert.DeserializeObject<DataTableValueModel>(item.Search.Value);
                        if (!string.IsNullOrEmpty(filterValue.Value))
                        {
                            var propertyInfo = contex.GetType().GetGenericArguments()[0].GetProperty(item.Name);
                            var member = Expression.Property(parameter, item.Name);
                            object value = TypeDescriptor.GetConverter(member.Type).ConvertFromString(filterValue.Value);
                            var constant = Expression.Constant(value, member.Type);

                            switch (Int32.Parse(filterValue.FilterType))
                            {
                                case (int)FilterOperators.Equals:
                                    expression = Expression.Equal(member, constant);
                                    break;
                                case (int)FilterOperators.Contains:
                                    //Muamma
                                    MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                                    //var someValue = Expression.Constant(constantValue, typeof(string));
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
                        var member = Expression.Property(parameter, item.Name);
                        var constant = Expression.Constant(item.Search.Value);
                        expression = Expression.Equal(member, constant);
                    }
                    if(expression != null)
                         finalExpression = Expression.AndAlso(finalExpression, expression);
                }
            }
            var data = contex.Where(Expression.Lambda<Func<T, bool>>(finalExpression, parameter));
            return data;
        }
    }
}