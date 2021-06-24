using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Abstract.Spefications
{
    public interface ISpecificationAttributeOptionService
    {
        Task<IDataResult<SpecificationAttributeOption>> GetSpecificationAttributeOptionById(int specificationAttributeOption);
        Task<IDataResult<IList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsByIds(int[] specificationAttributeOptionIds);
        Task<IDataResult<int[]>> GetNotExistingSpecificationAttributeOptions(int[] attributeOptionIds);
        Task<IDataResult<IPagedList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsBySpecificationAttribute(int specificationAttributeIdint = 0, int pageIndex = 1, int pageSize = int.MaxValue);
        Task<IResult> DeleteSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption);
        Task<IResult> InsertSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption);
        Task<IResult> UpdateSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption);
    }
}
