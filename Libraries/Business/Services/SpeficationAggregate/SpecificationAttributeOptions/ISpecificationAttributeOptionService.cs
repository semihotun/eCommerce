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
        Task<Result<SpecificationAttributeOption>> GetSpecificationAttributeOptionById(GetSpecificationAttributeOptionById request);
        Task<Result<List<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsByIds(GetSpecificationAttributeOptionsByIds request);
        Task<Result<int[]>> GetNotExistingSpecificationAttributeOptions(GetNotExistingSpecificationAttributeOptions request);
        Task<Result<IPagedList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsBySpecificationAttribute(GetSpecificationAttributeOptionsBySpecificationAttribute request);
        Task<Result> DeleteSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption);
        Task<Result> InsertSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption);
        Task<Result> UpdateSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption);
    }
}
