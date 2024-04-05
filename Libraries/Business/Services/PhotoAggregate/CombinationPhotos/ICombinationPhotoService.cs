using Core.Utilities.Results;
using Entities.Concrete.PhotoAggregate;
using Entities.RequestModel.PhotoAggregate.CombinationPhotos;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.PhotoAggregate.CombinationPhotos
{
    public interface ICombinationPhotoService
    {
        Task<Result<List<CombinationPhoto>>> GetAllCombinationPhotos(GetAllCombinationPhotosReqModel request);
        Task<Result> InsertCombinationPhotos(InsertCombinationPhotosReqModel request);
    }
}
