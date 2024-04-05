using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributeMappings
{
    public interface IProductAttributeMappingService
    {
        Task<Result<ProductAttributeMapping>> InsertProductAttributeMapping(InsertProductAttributeMappingReqModel productAttributeMapping);
        Task<Result> UpdateProductAttributeMapping(UpdateProductAttributeMappingReqModel productAttributeMapping);
        Task<Result> DeleteProductAttributeMapping(DeleteProductAttributeMappingReqModel request);
        Task<Result<List<ProductAttributeMapping>>> GetProductAttributeMappingsByProductId(GetProductAttributeMappingsByProductIdReqModel request);
        Task<Result<ProductAttributeMapping>> GetProductAttributeMappingById(GetProductAttributeMappingByIdReqModel request);
        Task<Result<IPagedList<ProductAttributeMapping>>> GetAllProductAttributeMapping(GetAllProductAttributeMappingReqModel request);
    }
}
