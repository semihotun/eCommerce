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
        Task<Result> DeleteProductAttribute(ProductAttribute productAttribute);
        Task<Result<IPagedList<ProductAttribute>>> GetAllProductAttributes(GetAllProductAttributes request);
        Task<Result<List<ProductAttribute>>> GetAllProductAttribute();
        Task<Result<ProductAttribute>> GetProductAttributeById(GetProductAttributeById request);
        Task<Result> InsertProductAttribute(ProductAttribute productAttribute);
        Task<Result> UpdateProductAttribute(ProductAttribute productAttribute);
        Task<Result<int[]>> GetNotExistingAttributes(GetNotExistingAttributes request);
        Task<Result<IEnumerable<SelectListItem>>> GetProductAttributeDropdown(GetProductAttributeDropdown request);
    }
}
