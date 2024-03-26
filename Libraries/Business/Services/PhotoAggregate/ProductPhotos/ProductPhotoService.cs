using Business.Services.PhotoAggregate.ProductPhotos.ProductPhotoServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Generate;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.ProductPhotos;
using DataAccess.UnitOfWork;
using Entities.Concrete.PhotoAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Utilities.Constants;
using X.PagedList;
namespace Business.Services.PhotoAggregate.ProductPhotos
{
    public class ProductPhotoService : IProductPhotoService
    {
        #region Field
        private readonly IProductPhotoDAL _productPhotoRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public ProductPhotoService(IProductPhotoDAL productPhotoRepository, IUnitOfWork unitOfWork)
        {
            _productPhotoRepository = productPhotoRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Method
        [CacheAspect]
        public async Task<Result<ProductPhoto>> GetProductPhotoById(GetProductPhotoById request)
        {
            return Result.SuccessDataResult(await _productPhotoRepository.GetAsync(x => x.Id == request.PhotoId));
        }
        [CacheAspect]
        public async Task<Result<IPagedList<ProductPhoto>>> GetProductPhoto(GetProductPhoto request)
        {
            var query = _productPhotoRepository.Query().Where(x => x.ProductId == request.Id);
            if (request.OrderByText != null)
                query = query.OrderBy(request.OrderByText);
            return Result.SuccessDataResult(await query.ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        [CacheRemoveAspect("IProductPhotoService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
            "IShowcaseDAL.GetShowCaseDto", "IShowcaseDAL.GetAllShowCaseDto")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> AddProductPhoto(ProductPhoto product)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                await _productPhotoRepository.AddAsync(product);
                return Result.SuccessResult();
            });
        }
        [CacheRemoveAspect("IProductPhotoService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
         "IShowcaseDAL.GetShowCaseDto", "IShowcaseDAL.GetAllShowCaseDto")]
        [LogAspect(typeof(MsSqlLogger))]
        [GenerateApiFromFromAttribute]
        public async Task<Result> AddRangeProductPhotoInsert(AddRangeProductPhotoInsert request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var newProductPhotoList = new List<ProductPhoto>();
                foreach (var item in request.ProductPhotos)
                {
                    var image = new ProductPhoto
                    {
                        ProductPhotoName = PhotoHelper.Add(PhotoUrl.Product, item).Data.Path,
                        ProductId = request.ProductId
                    };
                    newProductPhotoList.Add(image);
                }
                await _productPhotoRepository.AddRangeAsync(newProductPhotoList);
                return Result.SuccessResult();
            });
        }
        [CacheRemoveAspect("IProductPhotoService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
         "IShowcaseDAL.GetShowCaseDto", "IShowcaseDAL.GetAllShowCaseDto")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> DeleteProductPhoto(DeleteProductPhoto request)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                if (request.Id == 0)
                    return Result.ErrorResult();
                _productPhotoRepository.Remove(await _productPhotoRepository.GetByIdAsync(request.Id));
                return Result.SuccessResult();
            });
        }
        #endregion
    }
}
