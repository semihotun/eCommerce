using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Extension;
using Core.Utilities.Generate;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.ProductPhotos;
using DataAccess.UnitOfWork;
using Entities.Concrete.PhotoAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.PhotoAggregate.ProductPhotos;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
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
        #region Command
        [CacheRemoveAspect("IProductPhoto", "ICombinationPhoto","IShowcase")]
        [GenerateApiFromFromAttribute]
        public async Task<Result> AddRangeProductPhotoInsert(AddRangeProductPhotoInsertReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var newProductPhotoList = new List<ProductPhoto>();
                foreach (var item in request.ProductPhotos)
                {
                    var image = new ProductPhoto
                    {
                        ProductPhotoName = item.ConvertImageToBase64(),
                        ProductId = request.ProductId
                    };
                    newProductPhotoList.Add(image);
                }
                await _productPhotoRepository.AddRangeAsync(newProductPhotoList);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// DeleteProductPhoto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductPhoto", "ICombinationPhoto","IShowcase", "IShowcase")]
        public async Task<Result> DeleteProductPhoto(DeleteProductPhotoReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productPhotoRepository.GetByIdAsync(request.Id);
                if (data == null)
                    return Result.ErrorResult(Messages.IdNotFound);
                _productPhotoRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// AddProductPhoto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductPhoto", "ICombinationPhoto","IShowcase")]
        public async Task<Result<ProductPhoto>> AddProductPhoto(AddProductPhotoReqModel product)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = product.MapTo<ProductPhoto>();
                await _productPhotoRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        #endregion
        #region Query
        /// <summary>
        /// GetProductPhotoById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ProductPhoto>> GetProductPhotoById(GetProductPhotoByIdReqModel request)
        {
            return Result.SuccessDataResult(await _productPhotoRepository.GetAsync(x => x.Id == request.PhotoId));
        }
        /// <summary>
        /// GetProductPhoto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<ProductPhoto>>> GetProductPhoto(GetProductPhotoReqModel request)
        {
            var query = _productPhotoRepository.Query().Where(x => x.ProductId == request.Id);
            if (request.OrderByText != null)
                query = query.OrderBy(request.OrderByText);
            return Result.SuccessDataResult(await query.ToPagedListAsync(request.Param.PageIndex, request.Param.PageSize));
        }
        #endregion
        #endregion
    }
}
