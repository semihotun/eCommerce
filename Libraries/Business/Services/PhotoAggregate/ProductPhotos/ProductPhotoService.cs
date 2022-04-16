using Business.Services.PhotoAggregate.ProductPhotos.ProductPhotoServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Helper;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.ProductPhotos;
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
        #endregion
        #region Ctor
        public ProductPhotoService(IProductPhotoDAL productPhotoRepository)
        {
            _productPhotoRepository = productPhotoRepository;
        }
        #endregion
        #region Method

        [CacheAspect]
        public async Task<IDataResult<ProductPhoto>> GetProductPhotoById(GetProductPhotoById request)
        {
            var data = await _productPhotoRepository.GetAsync(x => x.Id == request.PhotoId);

            return new SuccessDataResult<ProductPhoto>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<ProductPhoto>>> GetProductPhoto(GetProductPhoto request)
        {
            var query = _productPhotoRepository.Query().Where(x => x.ProductId == request.Id);

            if (request.OrderByText != null)
                query = query.OrderBy(request.OrderByText);

            var data = await query.ToPagedListAsync(request.PageIndex, request.PageSize);

            return new SuccessDataResult<IPagedList<ProductPhoto>>(data);
        }

        [CacheRemoveAspect("IProductPhotoService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
            "IShowcaseDAL.GetShowCaseDto", "IShowcaseDAL.GetAllShowCaseDto")]
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> ProductPhotoInsert(ProductPhoto product)
        {
            if (product == null)
                return new ErrorResult();

            _productPhotoRepository.Add(product);
            await _productPhotoRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        [CacheRemoveAspect("IProductPhotoService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
         "IShowcaseDAL.GetShowCaseDto", "IShowcaseDAL.GetAllShowCaseDto")]
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> AddRangeProductPhotoInsert(AddRangeProductPhotoInsert request)
        {
            if (request.ProductPhotos == null)
                return new ErrorResult();

            var newProductPhotoList = new List<ProductPhoto>();
            foreach (var item in request.ProductPhotos)
            {
                var imageAdd = new PhotoHelper().Add(PhotoUrl.Product, item);
                var resim = new ProductPhoto();
                resim.ProductPhotoName = imageAdd.Data.Path;
                resim.ProductId = request.ProductId;
                newProductPhotoList.Add(resim);
            }
            _productPhotoRepository.AddRange(newProductPhotoList);

            await _productPhotoRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        [CacheRemoveAspect("IProductPhotoService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
         "IShowcaseDAL.GetShowCaseDto", "IShowcaseDAL.GetAllShowCaseDto")]
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> ProductPhotoDelete(ProductPhotoDelete request)
        {
            if (request.Id == 0)
                return new ErrorResult();

            _productPhotoRepository.Delete(_productPhotoRepository.GetById(request.Id));
            await _productPhotoRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion

    }
}
