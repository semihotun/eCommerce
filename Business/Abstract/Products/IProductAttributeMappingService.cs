using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Others;
using X.PagedList;

namespace Business.Abstract.Products
{
    public interface IProductAttributeMappingService
    {
        Task<IResult> DeleteProductAttributeMapping(int id);
        Task<IDataResult<IList<ProductAttributeMapping>>> GetProductAttributeMappingsByProductId(int productId);
        Task<IDataResult<ProductAttributeMapping>> GetProductAttributeMappingById(int productAttributeMappingId);
        Task<IResult> InsertProductAttributeMapping(ProductAttributeMapping productAttributeMapping);
        Task<IResult> UpdateProductAttributeMapping(ProductAttributeMapping productAttributeMapping);
        Task<IDataResult<IPagedList<ProductAttributeMapping>>> GetAllProductAttributeMapping(int productId,
            DataTablesParam param);

    }
}
