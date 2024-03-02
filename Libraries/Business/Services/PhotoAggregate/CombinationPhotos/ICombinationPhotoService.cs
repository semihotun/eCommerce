using Business.Services.PhotoAggregate.CombinationPhotos.CombinationPhotoServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.PhotoAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.PhotoAggregate.CombinationPhotos
{
    public interface ICombinationPhotoService
    {
        Task<IDataResult<List<CombinationPhoto>>> GetAllCombinationPhotos(GetAllCombinationPhotos request);
        Task<IResult> InsertCombinationPhotos(InsertCombinationPhotos request);
    }
}
