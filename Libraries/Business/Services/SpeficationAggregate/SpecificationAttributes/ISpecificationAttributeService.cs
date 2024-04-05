using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.SpeficationAggregate;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.SpeficationAggregate.SpecificationAttributes
{
    public interface ISpecificationAttributeService
    {
        Task<Result> DeleteSpecificationAttribute(DeleteSpecificationAttributeReqModel specificationAttribute);
        Task<Result<SpecificationAttribute>> InsertSpecificationAttribute(InsertSpecificationAttributeReqModel specificationAttribute);
        Task<Result> UpdateSpecificationAttribute(UpdateSpecificationAttributeReqModel specificationAttribute);
        Task<Result<List<SpecificationAttribute>>> GetSpecificationAttributeByIds(GetSpecificationAttributeByIdsReqModel request);
        Task<Result<IPagedList<SpecificationAttribute>>> GetSpecificationAttributes(GetSpecificationAttributesReqModel request);
        Task<Result<SpecificationAttribute>> GetSpecificationAttributeById(GetSpecificationAttributeByIdReqModel request);
        Task<Result<IEnumerable<SelectListItem>>> GetProductSpeficationAttributeDropdwon(GetProductSpeficationAttributeDropdwonReqModel request);
    }
}
