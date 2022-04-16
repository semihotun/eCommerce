﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Core.Utilities.Results;
using Business.Services.ProductAggregate.ProductStockTypes.ProductStockTypeServiceModel;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStockTypes;
using Core.Aspects.Autofac.Caching;

namespace Business.Services.ProductAggregate.ProductStockTypes
{
    public class ProductStockTypeService : IProductStockTypeService
    {

        #region Field

        private readonly IProductStockTypeDAL _productStockTypeDal;

        #endregion

        #region Ctor

        public ProductStockTypeService(IProductStockTypeDAL productStockTypeDal)
        {
            _productStockTypeDal = productStockTypeDal;
        }


        #endregion
        #region Method
        [CacheAspect]
        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetAllProductStockType(GetAllProductStockType request)
        {
            var query = from pst in _productStockTypeDal.Query()
                        select new SelectListItem
                        {
                            Text = pst.Name,
                            Value = pst.Id.ToString(),
                            Selected = pst.Id == request.SelectedId ? true : false
                        };
            var result = await query.ToListAsync();
            result.Insert(0, new SelectListItem("Seçiniz", "0", request.SelectedId == 0));

            return new SuccessDataResult<IEnumerable<SelectListItem>>(result);
        }


        #endregion
    }

}
