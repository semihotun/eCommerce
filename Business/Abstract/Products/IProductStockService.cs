using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Others;
using Entities.ViewModels.Admin.Products.ProductStock;
using X.PagedList;

namespace Business.Abstract.Products
{
    public interface IProductStockService
    {
        Task<IDataResult<IPagedList<ProductStock>>> GetAllProductStock(ProductStockFilter productStockFilter,
            DataTablesParam param);
        Task<IResult> AddProductStock(ProductStock productStock);
        Task<IResult> DeleteProductStock(int id);
    }
}
