using Business.Constants;
using Core.Const;
using Core.Extension;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Aspects.Autofac.Secure;
using Core.Utilities.Generate;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.PhotoAggregate.ProductPhotos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.PhotoAggregate.ProductPhotos.Commands
{
    public class ProductPhotoCommandService : IProductPhotoCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<ProductPhoto> _productPhotoRepository;
        public ProductPhotoCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<ProductPhoto> productPhotoRepository)
        {
            _unitOfWork = unitOfWork;
            _productPhotoRepository = productPhotoRepository;
        }

        [CacheRemoveAspect("IProductPhoto", "ICombinationPhoto", "IShowcase")]
        [GenerateApiFromFromAttribute]
        [AuthAspect(RoleConst.Admin)]
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
        [CacheRemoveAspect("IProductPhoto", "ICombinationPhoto", "IShowcase", "IShowcase")]
        [AuthAspect(RoleConst.Admin)]
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
        [CacheRemoveAspect("IProductPhoto", "ICombinationPhoto", "IShowcase")]
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result<ProductPhoto>> AddProductPhoto(AddProductPhotoReqModel product)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = product.MapTo<ProductPhoto>();
                await _productPhotoRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
    }
}
