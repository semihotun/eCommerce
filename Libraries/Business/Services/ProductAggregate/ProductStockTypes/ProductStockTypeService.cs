using Business.Constants;
using Business.Services.ProductAggregate.ProductStockTypes.ProductStockTypeServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStockTypes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<Result<IEnumerable<SelectListItem>>> GetAllProductStockType(GetAllProductStockType request)
        {
            var query = from pst in _productStockTypeDal.Query()
                        select new SelectListItem
                        {
                            Text = pst.Name,
                            Value = pst.Id.ToString(),
                            Selected = pst.Id == request.SelectedId
                        };
            var result = await query.ToListAsync();
            result.Insert(0, new SelectListItem(Messages.DropdownFirstItem, "0", request.SelectedId == 0));
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(result);
        }
        #endregion
    }
}
