using Business.Services.ProductAggregate.ProductAttributes.ProductAttributeServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductAttributes
{
    public partial interface IProductAttributeService
    {
        Task<IResult> DeleteProductAttribute(ProductAttribute productAttribute);
        Task<IDataResult<IPagedList<ProductAttribute>>> GetAllProductAttributes(GetAllProductAttributes request);
        Task<IDataResult<IList<ProductAttribute>>> GetAllProductAttribute();
        Task<IDataResult<ProductAttribute>> GetProductAttributeById(GetProductAttributeById request);
        Task<IResult> InsertProductAttribute(ProductAttribute productAttribute);
        Task<IResult> UpdateProductAttribute(ProductAttribute productAttribute);
        Task<IDataResult<int[]>> GetNotExistingAttributes(GetNotExistingAttributes request);
        Task<IDataResult<IEnumerable<SelectListItem>>> GetProductAttributeDropdown(GetProductAttributeDropdown request);
    }
}
