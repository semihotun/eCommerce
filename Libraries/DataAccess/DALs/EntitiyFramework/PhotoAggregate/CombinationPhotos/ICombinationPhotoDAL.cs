using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete.PhotoAggregate;
using Entities.Dtos.CombinationPhotoDALModels;
using Entities.Dtos.CommentDALModels;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos
{
    public interface ICombinationPhotoDAL : IEntityRepository<CombinationPhoto>
    {
        Task<Result<List<CombinationPhotoDTO>>> GetAllCombinationPhotosDTO(GetAllCombinationPhotosDTO request);
    }
}
