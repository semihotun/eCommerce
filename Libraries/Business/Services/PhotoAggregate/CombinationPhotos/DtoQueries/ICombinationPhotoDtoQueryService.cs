using Core.Utilities.Results;
using Entities.Dtos.CombinationPhotoDALModels;
using Entities.Dtos.CommentDALModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.PhotoAggregate.CombinationPhotos.DtoQueries
{
    public interface ICombinationPhotoDtoQueryService
    {
        Task<Result<List<CombinationPhotoDTO>>> GetAllCombinationPhotosDTO(GetAllCombinationPhotosDTO request);
    }
}
