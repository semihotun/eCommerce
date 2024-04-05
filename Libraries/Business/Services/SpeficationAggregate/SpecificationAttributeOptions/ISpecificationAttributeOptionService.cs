using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.SpeficationAggregate;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions
{
    public interface ISpecificationAttributeOptionService
    {
        Task<Result<SpecificationAttributeOption>> InsertSpecificationAttributeOption(InsertSpecificationAttributeOptionReqModel specificationAttributeOption);
        Task<Result> UpdateSpecificationAttributeOption(UpdateSpecificationAttributeOptionReqModel specificationAttributeOption);
        Task<Result> DeleteSpecificationAttributeOption(DeleteSpecificationAttributeOptionReqModel specificationAttributeOption);
        Task<Result<SpecificationAttributeOption>> GetSpecificationAttributeOptionById(GetSpecificationAttributeOptionByIdReqModel request);
        Task<Result<List<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsByIds(GetSpecificationAttributeOptionsByIdsReqModel request);
        Task<Result<int[]>> GetNotExistingSpecificationAttributeOptions(GetNotExistingSpecificationAttributeOptionsReqModel request);
        Task<Result<IPagedList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsBySpecificationAttribute(GetSpecificationAttributeOptionsBySpecificationAttributeReqModel request);
    }
}
