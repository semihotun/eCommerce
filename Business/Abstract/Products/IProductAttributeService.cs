using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business.Abstract.Products
{
    public partial interface IProductAttributeService
    {

        Task<IResult> DeleteProductAttribute(ProductAttribute productAttribute);
        Task<IDataResult<IPagedList<ProductAttribute>>> GetAllProductAttributes(int pageIndex = 0, int pageSize = int.MaxValue,string name=null);
        Task<IDataResult<IList<ProductAttribute>>> GetAllProductAttribute();
        Task<IDataResult<ProductAttribute>> GetProductAttributeById(int productAttributeId);
        Task<IResult> InsertProductAttribute(ProductAttribute productAttribute);
        Task<IResult> UpdateProductAttribute(ProductAttribute productAttribute);
        Task<IDataResult<int[]>> GetNotExistingAttributes(int[] attributeId);
        Task<IDataResult<IEnumerable<SelectListItem>>> GetProductAttributeDropdown(int? selectedId = 0);

    }
}
