using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Dtos.ProductSpecificationAttributeDALModels;
using Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.DtoQueries
{
    public interface IProductSpecificationAttributeDtoQueryService
    {
        Task<Result<IPagedList<ProductSpecificationAttributeDTO>>> GetProductSpecAttrList(
          GetProductSpecAttrListReqModel request);
        Task<Result<ProductSpecificationAttributeDTO>> GetProductSpeficationAttr();
    }
}
