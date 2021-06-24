using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Business.Abstract.Spefications
{
    public partial interface ISpecificationAttributeService
    {
        Task<IDataResult<List<SpecificationAttribute>>> GetCatalogSpefication(int categoryId = 0);
        Task<IDataResult<IList<SpecificationAttribute>>> GetSpecificationAttributeByIds(int[] specificationAttributeIds);
        Task<IDataResult<IPagedList<SpecificationAttribute>>> GetSpecificationAttributes(int pageIndex = 1, int pageSize = int.MaxValue);
        Task<IDataResult<IList<SpecificationAttribute>>> GetSpecificationAttributesWithOptions();
        Task<IDataResult<SpecificationAttribute>> GetSpecificationAttributeById(int specificationAttributeId);
        Task<IResult> DeleteSpecificationAttribute(SpecificationAttribute specificationAttribute);
        Task<IResult> InsertSpecificationAttribute(SpecificationAttribute specificationAttribute);
        Task<IResult> UpdateSpecificationAttribute(SpecificationAttribute specificationAttribute);
        Task<IDataResult<IEnumerable<SelectListItem>>> GetProductSpeficationAttributeDropdwon(int selectedId = 0);

    }
}
