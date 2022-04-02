using Business.Services.PhotoAggregate.CombinationPhotos.CombinationPhotoServiceModel;
using Business.Services.PhotoAggregate.ProductPhotos;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos;
using Entities.Concrete.PhotoAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.PhotoAggregate.CombinationPhotos
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
            _combinationPhotoRepository = combinationPhotoRepository;
            _productPhotoService = productPhotoService;
        }
        #endregion

        [CacheAspect]
        public async Task<IDataResult<List<CombinationPhoto>>> GetAllCombinationPhotos(GetAllCombinationPhotos request)
        {
            var query = _combinationPhotoRepository.Query();

            var data = await query.ToListAsync();

            return new SuccessDataResult<List<CombinationPhoto>>(data);
        }

        [CacheRemoveAspect("ICombinationPhotoService.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> InsertCombinationPhotos(InsertCombinationPhotos request)
        {

            var combinationData = new List<string>();
            if (request.Combinations != null)
            {
                combinationData = request.Combinations.Split(',').ToList();
                foreach (var item in combinationData)
                {
                    var combinationPhoto = new CombinationPhoto();
                    combinationPhoto.PhotoId = request.PhotoId;
                    combinationPhoto.CombinationId = int.Parse(item);
                    _combinationPhotoRepository.Add(combinationPhoto);
                }
            }
            if (request.NotCombinations != null)
            {
                var notcombinationdata = request.NotCombinations.Split(',');
                foreach (var item in notcombinationdata)
                {
                    var control = await _combinationPhotoRepository.GetAsync(x => x.PhotoId == request.PhotoId
                        && x.CombinationId == int.Parse(item));
                    _combinationPhotoRepository.Delete(control);
                }
            }

            await _combinationPhotoRepository.SaveChangesAsync();
            return new SuccessResult();

        }
    }
}
