using Business.Services.PhotoAggregate.ProductPhotos.ProductPhotoServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.PhotoAggregate;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Services.PhotoAggregate.ProductPhotos
{
    public interface IProductPhotoService
    {
        Task<IDataResult<ProductPhoto>> GetProductPhotoById(GetProductPhotoById request);

        Task<IDataResult<IPagedList<ProductPhoto>>> GetProductPhoto(GetProductPhoto request);

        Task<IResult> ProductPhotoInsert(ProductPhoto product);

        Task<IResult> ProductPhotoDelete(ProductPhotoDelete request);

        Task<IResult> AddRangeProductPhotoInsert(AddRangeProductPhotoInsert request);
    }
}
