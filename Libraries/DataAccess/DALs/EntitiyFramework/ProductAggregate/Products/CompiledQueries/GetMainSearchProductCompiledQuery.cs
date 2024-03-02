using DataAccess.Context;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.CompiledQueries
{
    public static class GetMainSearchProductCompiledQuery
    {
        public static readonly Func<eCommerceContext, int, string, IEnumerable<ProductSearch>> Get =
      EF.CompileQuery<eCommerceContext, int, string, IEnumerable<ProductSearch>>((Context, PageSize, SearchProductName) =>
              (from p in Context.Product.AsEnumerable()
               where p.ProductNameUpper.StartsWith(SearchProductName)                                  
               select new ProductSearch
               {
                   Id = p.Id,
                   ProductName = p.ProductName
               }).Skip(1).Take(PageSize)
              );
    }
}
