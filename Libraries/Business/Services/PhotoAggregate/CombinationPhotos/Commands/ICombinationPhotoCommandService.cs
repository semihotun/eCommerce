using Core.Utilities.Results;
using Entities.RequestModel.PhotoAggregate.CombinationPhotos;
using System.Threading.Tasks;

namespace Business.Services.PhotoAggregate.CombinationPhotos.Commands
{
    public interface ICombinationPhotoCommandService
    {
        Task<Result> InsertCombinationPhotos(InsertCombinationPhotosReqModel request);
    }
}
