using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.PhotoAggregate.ProductPhotos;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
namespace Business.Services.PhotoAggregate.ProductPhotos.Queries
{
    public class ProductPhotoQueryService : IProductPhotoQueryService
    {
        private readonly IReadDbRepository<ProductPhoto> _productPhotoRepository;
        public ProductPhotoQueryService(IReadDbRepository<ProductPhoto> productPhotoRepository)
        {
            _productPhotoRepository = productPhotoRepository;
        }

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
    }
}
