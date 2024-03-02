using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Others;
using Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel;
using Core.Utilities.Nuget.X.PagedList;
using X.PagedList;
using Entities.Concrete.ProductAggregate;
namespace Business.Services.ProductAggregate.ProductAttributeMappings
{
    public interface IProductAttributeMappingService
    {
        Task<IResult> DeleteProductAttributeMapping(DeleteProductAttributeMapping request);
        Task<IDataResult<IList<ProductAttributeMapping>>> GetProductAttributeMappingsByProductId(GetProductAttributeMappingsByProductId request);
        Task<IDataResult<ProductAttributeMapping>> GetProductAttributeMappingById(GetProductAttributeMappingById request);
        Task<IResult> InsertProductAttributeMapping(ProductAttributeMapping productAttributeMapping);
        Task<IResult> UpdateProductAttributeMapping(ProductAttributeMapping productAttributeMapping);
        Task<IDataResult<IPagedList<ProductAttributeMapping>>> GetAllProductAttributeMapping(GetAllProductAttributeMapping request);
    }
}
