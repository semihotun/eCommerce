using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributes.Queries
{
    public interface IProductAttributeQueryService
    {
        Task<Result<List<ProductAttribute>>> GetAllProductAttribute();
        Task<Result<IPagedList<ProductAttribute>>> GetAllProductAttributes(GetAllProductAttributesReqModel request);
        Task<Result<ProductAttribute>> GetProductAttributeById(GetProductAttributeByIdReqModel request);
        Task<Result<IEnumerable<SelectListItem>>> GetProductAttributeDropdown(GetProductAttributeDropdownReqModel request);
    }
}
