using Business.Constants;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
using System.Threading.Tasks;

namespace Business.Services.CategoriesAggregate.CategorySpefications.Commands
{
    public class CategorySpeficationCommandService : ICategorySpeficationCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<CategorySpefication> _categorySpeficationRepository;
        public CategorySpeficationCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<CategorySpefication> categorySpeficationRepository)
        {
            _unitOfWork = unitOfWork;
            _categorySpeficationRepository = categorySpeficationRepository;
        }
        /// <summary>
        /// DeleteCategorySpefication
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategorySpeficationService")]
        public async Task<Result> DeleteCategorySpefication(DeleteCategorySpeficationReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var categorySpefication = await _categorySpeficationRepository.GetByIdAsync(request.Id);
                if (categorySpefication == null)
                    return Result.ErrorResult(Messages.IdNotFound);
                _categorySpeficationRepository.Remove(categorySpefication);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// InsertCategorySpefication
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategorySpeficationService")]
        public async Task<Result<CategorySpefication>> InsertCategorySpefication(InsertCategorySpeficationReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = request.MapTo<CategorySpefication>();
                await _categorySpeficationRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateCategorySpefication
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategorySpeficationService")]
        public async Task<Result> UpdateCategorySpefication(UpdateCategorySpeficationReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var categorySpefication = await _categorySpeficationRepository.GetByIdAsync(request.Id);
                if (categorySpefication != null)
                    return Result.ErrorResult();
                var data = request.MapTo(categorySpefication);
                _categorySpeficationRepository.Update(categorySpefication);
                return Result.SuccessResult();
            });
        }
    }
}
