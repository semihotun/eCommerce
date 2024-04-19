using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributeMappings.Queries
{
    public interface IProductAttributeMappingQueryService
    {
        Task<Result<List<ProductAttributeMapping>>> GetProductAttributeMappingsByProductId(GetProductAttributeMappingsByProductIdReqModel request);
        Task<Result<ProductAttributeMapping>> GetProductAttributeMappingById(GetProductAttributeMappingByIdReqModel request);
        Task<Result<IPagedList<ProductAttributeMapping>>> GetAllProductAttributeMapping(GetAllProductAttributeMappingReqModel request);
    }
}
