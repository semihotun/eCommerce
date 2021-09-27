using eCommerce.Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using System.Linq;
using Entities.DTO.Category;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.ViewModels.Admin;

namespace DataAccess.Abstract
{
    public interface ICategoryDAL : IEntityRepository<Category>
    {
        Task<IDataResult<IList<CategoryDTO>>> GetAllCategoryTreeList();

        Task<IDataResult<CategorySpeficationDTO>> GetCategorySpefication(int categoryId);

        Task<IDataResult<CategorySpeficationOptionDTO>> GetCategorySpeficationOptionDTO(int categoryId);

        Task<IDataResult<IList<HierarchyViewModel>>> GetHierarchy();

    }
}
