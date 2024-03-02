using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel;
using Core.Utilities.Nuget.X.PagedList;
using X.PagedList;
using Entities.Concrete.SpeficationAggregate;
namespace Business.Services.SpeficationAggregate.SpecificationAttributes
{
    public partial interface ISpecificationAttributeService
    {
        Task<IDataResult<List<SpecificationAttribute>>> GetCatalogSpefication(GetCatalogSpefication request);
        Task<IDataResult<IList<SpecificationAttribute>>> GetSpecificationAttributeByIds(GetSpecificationAttributeByIds request);
        Task<IDataResult<IPagedList<SpecificationAttribute>>> GetSpecificationAttributes(GetSpecificationAttributes request);
        Task<IDataResult<SpecificationAttribute>> GetSpecificationAttributeById(GetSpecificationAttributeById request);
        Task<IResult> DeleteSpecificationAttribute(SpecificationAttribute specificationAttribute);
        Task<IResult> InsertSpecificationAttribute(SpecificationAttribute specificationAttribute);
        Task<IResult> UpdateSpecificationAttribute(SpecificationAttribute specificationAttribute);
        Task<IDataResult<IEnumerable<SelectListItem>>> GetProductSpeficationAttributeDropdwon(GetProductSpeficationAttributeDropdwon request);
    }
}
