using System.Threading.Tasks;
using Business.Abstract.Photos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete.Photos
{
    public class ProductPhotoService : IProductPhotoService
    {
        #region Field
        private readonly IProductPhotoDAL _productPhotoRepository;
        #endregion
        #region Ctor
        public ProductPhotoService(IProductPhotoDAL productPhotoRepository)
        {
            this._productPhotoRepository = productPhotoRepository;
        }
        #endregion
        #region Method
        public async Task<IDataResult<ProductPhoto>> GetById(int photoId)
        {
            var data =await _productPhotoRepository.GetAsync(x=>x.Id==photoId);

            return new SuccessDataResult<ProductPhoto>(data);
        }
        #endregion

    }
}
