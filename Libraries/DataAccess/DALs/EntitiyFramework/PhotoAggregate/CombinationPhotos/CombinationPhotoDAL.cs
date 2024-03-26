using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos.CombinationPhotoDALModels;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.PhotoAggregate;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos
{
    public class CombinationPhotoDAL : EfEntityRepositoryBase<CombinationPhoto, ECommerceContext>, ICombinationPhotoDAL
    {
        public CombinationPhotoDAL(ECommerceContext context) : base(context)
        {
        }
        [CacheAspect]
        public async Task<Result<List<CombinationPhotoDTO>>> GetAllCombinationPhotosDTO(GetAllCombinationPhotosDTO request)
        {
            var query = from cp in Context.CombinationPhoto
                        join pac in Context.ProductAttributeCombination on cp.CombinationId equals pac.Id
                        join p in Context.ProductPhoto on cp.PhotoId equals p.Id
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
