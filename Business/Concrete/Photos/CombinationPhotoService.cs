using Business.Abstract.Photos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete.Photos
{
    public class CombinationPhotoService : ICombinationPhotoService
    {
        #region Field
        private readonly ICombinationPhotoDAL _combinationPhotoRepository;
        private readonly IProductPhotoService _productPhotoService;
        #endregion
        #region Ctor
        public CombinationPhotoService(
            ICombinationPhotoDAL combinationPhotoRepository,
            IProductPhotoService productPhotoService)
        {
            this._combinationPhotoRepository = combinationPhotoRepository;
            this._productPhotoService = productPhotoService;
        }
        #endregion

        [CacheAspect]
        public async Task<IDataResult<List<CombinationPhoto>>> GetAllCombinationPhotos(int productId, int photoId)
        {
            var query = _combinationPhotoRepository.Query();

            var data = await query.ToListAsync();

            return new SuccessDataResult<List<CombinationPhoto>>(data);
        }
        [CacheRemoveAspect("ICombinationPhotoService.Get")]
        public async Task<IResult> InsertCombinationPhotos(int photoId, string combinations = "", string notCombinations = "")
        {

            var combinationData = new List<string>();
            if (combinations != null)
            {
                combinationData = combinations.Split(',').ToList();
                foreach (var item in combinationData)
                {
                    CombinationPhoto combinationPhoto = new CombinationPhoto();
                    combinationPhoto.PhotoId = photoId;
                    combinationPhoto.CombinationId = Int32.Parse(item);
                    _combinationPhotoRepository.Add(combinationPhoto);
                }
            }
            if (notCombinations != null)
            {
                var notcombinationdata = notCombinations.Split(',');
                foreach (var item in notcombinationdata)
                {
                    var control = await _combinationPhotoRepository.GetAsync(x => x.PhotoId == photoId
                        && x.CombinationId == Int32.Parse(item));
                    _combinationPhotoRepository.Delete(control);
                }
            }

            await _combinationPhotoRepository.SaveChangesAsync();
            return new SuccessResult();

        }
    }
}
