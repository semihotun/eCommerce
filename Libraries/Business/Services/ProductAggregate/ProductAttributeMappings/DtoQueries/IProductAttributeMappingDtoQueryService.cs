using Core.Utilities.Results;
using Entities.Dtos.ProductAttributeMappingDALModels;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributeMappings.DtoQueries
{
    public interface IProductAttributeMappingDtoQueryService
    {
        Task<Result<IList<ProductDetailMappingDTO>>> GetProductDetailMappingJson(GetProductDetailMappingJsonReqModel request);
        Task<Result<MappingProductAttribute>> GetMappingProductAttributeList(GetMappingProductAttributeListReqModel request);
    }
}
