using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions.Queries
{
    public interface ISpecificationAttributeOptionQueryService
    {
        Task<Result<SpecificationAttributeOption>> GetSpecificationAttributeOptionById(GetSpecificationAttributeOptionByIdReqModel request);
        Task<Result<List<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsByIds(GetSpecificationAttributeOptionsByIdsReqModel request);
        Task<Result<Guid[]>> GetNotExistingSpecificationAttributeOptions(GetNotExistingSpecificationAttributeOptionsReqModel request);
        Task<Result<IPagedList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsBySpecificationAttribute(GetSpecificationAttributeOptionsBySpecificationAttributeReqModel request);
    }
}
