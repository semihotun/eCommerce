using Core.Utilities.Results;
using Entities.Concrete.ShowcaseAggregate;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ShowcaseAggregate.ShowcaseServices
{
    public interface IShowcaseService
    {
        Task<Result<ShowCase>> InsertShowcase(InsertShowcaseReqModel showCase);
        Task<Result> UpdateShowcase(UpdateShowcaseReqModel showCase);
        Task<Result> DeleteShowCase(DeleteShowCaseReqModel request);
        Task<Result<ShowCase>> GetShowcase(GetShowcaseReqModel request);
        Task<Result<IList<ShowCase>>> GetAllShowcase();
    }
}
