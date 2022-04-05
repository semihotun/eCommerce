using Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.SpeficationAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions
{
    public interface ISpecificationAttributeOptionService
    {
        Task<IDataResult<SpecificationAttributeOption>> GetSpecificationAttributeOptionById(GetSpecificationAttributeOptionById request);
        Task<IDataResult<IList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsByIds(GetSpecificationAttributeOptionsByIds request);
        Task<IDataResult<int[]>> GetNotExistingSpecificationAttributeOptions(GetNotExistingSpecificationAttributeOptions request);
        Task<IDataResult<IPagedList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsBySpecificationAttribute(GetSpecificationAttributeOptionsBySpecificationAttribute request);
        Task<IResult> DeleteSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption);
        Task<IResult> InsertSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption);
        Task<IResult> UpdateSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption);
    }
}
