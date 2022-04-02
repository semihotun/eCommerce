using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos.CombinationPhotoDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.PhotoAggregate;
using Entities.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos
{

    public interface ICombinationPhotoDAL : IEntityRepository<CombinationPhoto>
    {
        Task<IDataResult<List<CombinationPhotoDTO>>> GetAllCombinationPhotosDTO(GetAllCombinationPhotosDTO request);
    }


}
