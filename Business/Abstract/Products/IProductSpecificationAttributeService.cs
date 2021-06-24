using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Abstract.Products
{
    public interface IProductSpecificationAttributeService
    {
        Task<IResult> DeleteProductSpecificationAttribute(int id);
        Task<IDataResult<IPagedList<ProductSpecificationAttribute>>> GetProductSpecificationAttributes(int productId = 0,
            string specificationAttributeName = null,
            int specificationAttributeOptionId = 0, bool? allowFiltering = null, bool? showOnProductPage = null,
            int pageIndex = 1, int pageSize = int.MaxValue);
        Task<IDataResult<ProductSpecificationAttribute>> GetProductSpecificationAttributeById(int productSpecificationAttributeId);
        Task<IResult> InsertProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute);
        Task<IResult> UpdateProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute);
        Task<IDataResult<int>> GetProductSpecificationAttributeCount(int productId = 0, int specificationAttributeOptionId = 0);
    }
}
