using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.PhotoAggregate.CombinationPhotos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.PhotoAggregate.CombinationPhotos.Queries
{
    public interface ICombinationPhotoQueryService
    {
        Task<Result<List<CombinationPhoto>>> GetAllCombinationPhotos(GetAllCombinationPhotosReqModel request);
    }
}
