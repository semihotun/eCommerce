using Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.SpeficationAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.SpeficationAggregate.SpecificationAttributes
{
    public interface ISpecificationAttributeService
    {
        Task<Result<List<SpecificationAttribute>>> GetSpecificationAttributeByIds(GetSpecificationAttributeByIds request);
        Task<Result<IPagedList<SpecificationAttribute>>> GetSpecificationAttributes(GetSpecificationAttributes request);
        Task<Result<SpecificationAttribute>> GetSpecificationAttributeById(GetSpecificationAttributeById request);
        Task<Result> DeleteSpecificationAttribute(SpecificationAttribute specificationAttribute);
        Task<Result> InsertSpecificationAttribute(SpecificationAttribute specificationAttribute);
        Task<Result> UpdateSpecificationAttribute(SpecificationAttribute specificationAttribute);
        Task<Result<IEnumerable<SelectListItem>>> GetProductSpeficationAttributeDropdwon(GetProductSpeficationAttributeDropdwon request);
    }
}
