using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.PhotoAggregate.ProductPhotos;
using System.Threading.Tasks;

namespace Business.Services.PhotoAggregate.ProductPhotos.Commands
{
    public interface IProductPhotoCommandService
    {
        Task<Result<ProductPhoto>> AddProductPhoto(AddProductPhotoReqModel product);
        Task<Result> DeleteProductPhoto(DeleteProductPhotoReqModel request);
        Task<Result> AddRangeProductPhotoInsert(AddRangeProductPhotoInsertReqModel request);
    }
}
