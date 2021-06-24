using Business.Abstract.Categories;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Business.Concrete.Categories
{
    public class CategorySpeficationService : ICategorySpeficationService
    {
        #region Field
        private readonly ICategorySpeficationDAL _categorySpeficationRepository;
        #endregion

        #region Ctor
        public CategorySpeficationService(ICategorySpeficationDAL categorySpeficationRepository)
        {
            this._categorySpeficationRepository = categorySpeficationRepository;
        }
        #endregion

        #region Method
        public async Task<IDataResult<CategorySpefication>> GetByCategorySpeficationId(int speficationId,int categoryId)
        {
            var data =await _categorySpeficationRepository.GetAsync(x=>x.CategoryId== categoryId && x.SpeficationAttributeId== speficationId);

            return new SuccessDataResult<CategorySpefication>(data);
        }

        public async Task<IResult> DeleteCategorySpefication(CategorySpefication categorySpefication)
        {
            if (categorySpefication == null)
                return new ErrorResult();

            _categorySpeficationRepository.Delete(categorySpefication);
            await _categorySpeficationRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        public async Task<IResult> InsertCategorySpefication(CategorySpefication categorySpefication)
        {
            if (categorySpefication == null)
                return new ErrorResult();

            _categorySpeficationRepository.Add(categorySpefication);
            await _categorySpeficationRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateCategorySpefication(CategorySpefication categorySpefication)
        {
            if (categorySpefication == null)
                return new ErrorResult();

            _categorySpeficationRepository.Update(categorySpefication);
            await _categorySpeficationRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        public async  Task<IDataResult<List<CategorySpefication>>> GetAllCategorySpefication(int categoryId = 0)
        {
            var query = _categorySpeficationRepository.Query();

            if (categoryId != 0)
                query = query.Where(x => x.CategoryId == categoryId);

            var data =await query.ToListAsync();

            return new SuccessDataResult<List<CategorySpefication>>(data);
        }

        #endregion
    }
}
