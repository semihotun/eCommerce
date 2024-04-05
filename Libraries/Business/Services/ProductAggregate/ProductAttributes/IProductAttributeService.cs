using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.RequestModel.ProductAggregate.ProductAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributes
{
    public interface IProductAttributeService
    {
        Task<Result> DeleteProductAttribute(DeleteProductAttributeReqModel productAttribute);
        Task<Result<ProductAttribute>> InsertProductAttribute(InsertProductAttributeReqModel productAttribute);
        Task<Result> UpdateProductAttribute(UpdateProductAttributeReqModel productAttribute);
        Task<Result<List<ProductAttribute>>> GetAllProductAttribute();
        Task<Result<IPagedList<ProductAttribute>>> GetAllProductAttributes(GetAllProductAttributesReqModel request);
        Task<Result<ProductAttribute>> GetProductAttributeById(GetProductAttributeByIdReqModel request);
        Task<Result<int[]>> GetNotExistingAttributes(GetNotExistingAttributesReqModel request);
        Task<Result<IEnumerable<SelectListItem>>> GetProductAttributeDropdown(GetProductAttributeDropdownReqModel request);
    }
}
