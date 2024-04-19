using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.PhotoAggregate.ProductPhotos;
using System.Threading.Tasks;

namespace Business.Services.PhotoAggregate.ProductPhotos.Queries
{
    public interface IProductPhotoQueryService
    {
        Task<Result<ProductPhoto>> GetProductPhotoById(GetProductPhotoByIdReqModel request);
        Task<Result<IPagedList<ProductPhoto>>> GetProductPhoto(GetProductPhotoReqModel request);
    }
}
