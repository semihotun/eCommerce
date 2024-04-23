using Business.Constants;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductStockTypes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductStockTypes.Queries
{
    public class ProductStockTypeQueryService : IProductStockTypeQueryService
    {
        private readonly IReadDbRepository<ProductStockType> _productStockTypeDal;
        public ProductStockTypeQueryService(IReadDbRepository<ProductStockType> productStockTypeDal)
        {
            _productStockTypeDal = productStockTypeDal;
        }
        [CacheAspect]
        public async Task<Result<IEnumerable<SelectListItem>>> GetAllProductStockType(GetAllProductStockTypeReqModel request)
        {
            var query = from pst in _productStockTypeDal.Query()
                        select new SelectListItem
                        {
                            Text = pst.Name,
                            Value = pst.Id.ToString(),
                            Selected = pst.Id == request.SelectedId
                        };
            var result = await query.ToListAsync();
            result.Insert(0, new SelectListItem(Messages.DropdownFirstItem, "0", request.SelectedId == Guid.Empty));
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(result);
        }
    }
}
