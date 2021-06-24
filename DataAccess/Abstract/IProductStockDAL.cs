using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using eCommerce.Core.DataAccess;
using Entities.Concrete;
using Entities.Others;
using Entities.ViewModels.Admin.Products.ProductStock;
using X.PagedList;

namespace DataAccess.Abstract
{
    public interface IProductStockDAL : IEntityRepository<ProductStock>
    {
        Task<IDataResult<IPagedList<ProductStockDto>>> GetAllProductStockDto(int productId, DataTablesParam param);
    }
}
