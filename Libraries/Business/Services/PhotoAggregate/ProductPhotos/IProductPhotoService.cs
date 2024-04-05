using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.PhotoAggregate;
using Entities.RequestModel.PhotoAggregate.ProductPhotos;
using System.Threading.Tasks;
namespace Business.Services.PhotoAggregate.ProductPhotos
{
    public interface IProductPhotoService
    {
        Task<Result<ProductPhoto>> GetProductPhotoById(GetProductPhotoByIdReqModel request);
        Task<Result<IPagedList<ProductPhoto>>> GetProductPhoto(GetProductPhotoReqModel request);
        Task<Result<ProductPhoto>> AddProductPhoto(AddProductPhotoReqModel product);
        Task<Result> DeleteProductPhoto(DeleteProductPhotoReqModel request);
        Task<Result> AddRangeProductPhotoInsert(AddRangeProductPhotoInsertReqModel request);
    }
}
