using Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductAttributeMappings
{
    public interface IProductAttributeMappingService
    {
        Task<IResult> DeleteProductAttributeMapping(DeleteProductAttributeMapping request);
        Task<IDataResult<IList<ProductAttributeMapping>>> GetProductAttributeMappingsByProductId(GetProductAttributeMappingsByProductId request);
        Task<IDataResult<ProductAttributeMapping>> GetProductAttributeMappingById(GetProductAttributeMappingById request);
        Task<IResult> InsertProductAttributeMapping(ProductAttributeMapping productAttributeMapping);
        Task<IResult> UpdateProductAttributeMapping(ProductAttributeMapping productAttributeMapping);
        Task<IDataResult<IPagedList<ProductAttributeMapping>>> GetAllProductAttributeMapping(GetAllProductAttributeMapping request);
    }
}
