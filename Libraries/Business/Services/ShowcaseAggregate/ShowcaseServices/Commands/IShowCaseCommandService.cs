using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseServices;
using System.Threading.Tasks;

namespace Business.Services.ShowcaseAggregate.ShowcaseServices.Commands
{
    public interface IShowCaseCommandService
    {
        Task<Result<ShowCase>> InsertShowcase(InsertShowcaseReqModel showCase);
        Task<Result> UpdateShowcase(UpdateShowcaseReqModel showCase);
        Task<Result> DeleteShowCase(DeleteShowCaseReqModel request);
    }
}
