using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributeMappings.Commands
{
    public interface IProductAttributeMappingCommandService
    {
        Task<Result<ProductAttributeMapping>> InsertProductAttributeMapping(InsertProductAttributeMappingReqModel productAttributeMapping);
        Task<Result> UpdateProductAttributeMapping(UpdateProductAttributeMappingReqModel productAttributeMapping);
        Task<Result> DeleteProductAttributeMapping(DeleteProductAttributeMappingReqModel request);
    }
}
