using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks.ProductStockDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.ProductAggregate;
using Entities.DTO.Product;
using Entities.Others;
using X.PagedList;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks
{
    public interface IProductStockDAL : IEntityRepository<ProductStock>
    {
        Task<IDataResult<IPagedList<ProductStockDto>>> GetAllProductStockDto(GetAllProductStockDto request);
    }
}
