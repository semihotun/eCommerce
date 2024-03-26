using Business.Services.PhotoAggregate.CombinationPhotos.CombinationPhotoServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.PhotoAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.PhotoAggregate.CombinationPhotos
{
    public interface ICombinationPhotoService
    {
        Task<Result<List<CombinationPhoto>>> GetAllCombinationPhotos(GetAllCombinationPhotos request);
        Task<Result> InsertCombinationPhotos(InsertCombinationPhotos request);
    }
}
