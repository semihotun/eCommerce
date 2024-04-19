using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductAttributes;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributes.Commands
{
    public interface IProductAttributeCommandService
    {
        Task<Result> DeleteProductAttribute(DeleteProductAttributeReqModel productAttribute);
        Task<Result<ProductAttribute>> InsertProductAttribute(InsertProductAttributeReqModel productAttribute);
        Task<Result> UpdateProductAttribute(UpdateProductAttributeReqModel productAttribute);
    }
}
