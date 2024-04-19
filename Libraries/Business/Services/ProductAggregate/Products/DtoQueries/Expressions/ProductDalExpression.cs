using Entities.ViewModels.WebViewModel.Home;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;
using Entities.Dtos.ProductDALModels;
using Entities.RequestModel.ProductAggregate.Catalog;
using Entities.Concrete;

namespace Business.Services.ProductAggregate.Products.DtoQueries.Expressions
{
    public static class ProductDalExpression
    {
        public static Expression<Func<ProductSpecificationAttribute, bool>> SpeficationExpression(string selectFilter)
        {
            var data = JsonConvert.DeserializeObject<IList<SelectFilterModel>>(selectFilter);
            var filterparameter = Expression.Parameter(typeof(ProductSpecificationAttribute), "x");
            Expression filterfinalExpression = Expression.Constant(true);
            foreach (var item in data.GroupBy(x => x.SpecificationAttributeId))
            {
                Expression filterExpression = Expression.Constant(false);
                Expression expression = null;
                var property = Expression.Property(filterparameter, typeof(ProductSpecificationAttribute).GetProperty("SpecificationAttributeOptionId").GetMethod);
                foreach (var item2 in item)
                {
                    var constant = Expression.Constant(Convert.ToInt32(item2.SpeficationAttributeOptionId));
                    expression = Expression.Equal(property, constant);
                    filterExpression = Expression.Or(filterExpression, expression);
                }
                filterfinalExpression = Expression.And(filterfinalExpression, filterExpression);
            }
            return Expression.Lambda<Func<ProductSpecificationAttribute, bool>>(filterfinalExpression, filterparameter);
        }
        public static IQueryable<CatalogProduct> CatalogBrandExpression(IQueryable<CatalogProduct> query, GetCatalogProductReqModel catalog)
        {
            var parameter = Expression.Parameter(typeof(CatalogProduct), "x");
            Expression finalExpression = Expression.Constant(false);
            foreach (var brand in catalog.SelectedBrand.Split(','))
            {
                Expression expression = null;
                var property = Expression.Property(parameter, typeof(CatalogProduct).GetProperty("BrandId").GetMethod);
                var constant = Expression.Constant(Convert.ToInt32(brand));
                expression = Expression.Equal(property, constant);
                finalExpression = Expression.Or(finalExpression, expression);
            }
            query = query.Where(Expression.Lambda<Func<CatalogProduct, bool>>(finalExpression, parameter));
            return query;
        }
    }
}
