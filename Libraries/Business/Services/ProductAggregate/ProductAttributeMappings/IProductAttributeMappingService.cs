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
        Task<Result> DeleteProductAttributeMapping(DeleteProductAttributeMapping request);
        Task<Result<List<ProductAttributeMapping>>> GetProductAttributeMappingsByProductId(GetProductAttributeMappingsByProductId request);
        Task<Result<ProductAttributeMapping>> GetProductAttributeMappingById(GetProductAttributeMappingById request);
        Task<Result<ProductAttributeMapping>> InsertProductAttributeMapping(ProductAttributeMapping productAttributeMapping);
        Task<Result> UpdateProductAttributeMapping(ProductAttributeMapping productAttributeMapping);
        Task<Result<IPagedList<ProductAttributeMapping>>> GetAllProductAttributeMapping(GetAllProductAttributeMapping request);
    }
}
