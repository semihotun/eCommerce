using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dtos.CombinationPhotoDALModels;
using Entities.Dtos.CommentDALModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Business.Services.PhotoAggregate.CombinationPhotos.DtoQueries
{
    public class CombinationPhotoDtoQueryService : ICombinationPhotoDtoQueryService
    {
        private readonly ECommerceReadContext _readContext;
        public CombinationPhotoDtoQueryService(ECommerceReadContext readContext)
        {
            _readContext = readContext;
        }
        [CacheAspect]
        public async Task<Result<List<CombinationPhotoDTO>>> GetAllCombinationPhotosDTO(GetAllCombinationPhotosDTO request)
        {
            var query = from cp in _readContext.Query<CombinationPhoto>()
                        join pac in _readContext.Query<ProductAttributeCombination>() on cp.CombinationId equals pac.Id
                        join p in _readContext.Query<ProductPhoto>() on cp.PhotoId equals p.Id
                        where cp.PhotoId == request.PhotoId && p.ProductId == request.ProductId
                        select new CombinationPhotoDTO
                        {
                            CombinationId = cp.CombinationId,
                            PhotoId = cp.PhotoId,
                            Id = cp.Id,
                        };
            return Result.SuccessDataResult(await query.ToListAsync());
        }
    }
}
