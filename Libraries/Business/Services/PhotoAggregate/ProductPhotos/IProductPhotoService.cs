using Business.Services.PhotoAggregate.ProductPhotos.ProductPhotoServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.PhotoAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.PhotoAggregate.ProductPhotos
{
    public interface IProductPhotoService
    {
        Task<Result<ProductPhoto>> GetProductPhotoById(GetProductPhotoById request);
        Task<Result<IPagedList<ProductPhoto>>> GetProductPhoto(GetProductPhoto request);
        Task<Result> AddProductPhoto(ProductPhoto product);
        Task<Result> DeleteProductPhoto(DeleteProductPhoto request);
        Task<Result> AddRangeProductPhotoInsert(AddRangeProductPhotoInsert request);
    }
}
