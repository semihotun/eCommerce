﻿using Business.Services.BrandAggregate.CatalogBrands.CatalogBrandModels;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.CatalogBrands;
using Entities.Concrete.BrandAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.BrandAggregate.CatalogBrands
{
    public class CatalogBrandService : ICatalogBrandService
    {
        private readonly ICatalogBrandDAL _catalogBrandDAL;
        public CatalogBrandService(ICatalogBrandDAL catalogBrandDAL)
        {
            _catalogBrandDAL = catalogBrandDAL;
        }
        public async Task<Result<IEnumerable<CatalogBrand>>> GetCatalogBrand(GetCatalogBrand request)
        {
            var data = await _catalogBrandDAL.Query().Where(x => x.CategoryId == request.CategoryId).ToListAsync();
            return Result.SuccessDataResult<IEnumerable<CatalogBrand>>(data);
        }
    }
}
